using api.Domain.Repository.Interface.Apontamentos;
using api.Domain.Views.Input.Apontamentos;
using api.Domain.Views.Output.Apontamentos;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Risco
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/Apontamento")]
    public class ApontamentoController : Controller
    {

        private readonly IApontamentoRepository _Apontamento;

        public ApontamentoController(IApontamentoRepository Apontamento)
        {
            _Apontamento = Apontamento;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] ApontamentoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Apontamento == 0) { _Apontamento.Create(input); } 
            if (input.Id_Apontamento > 0) { _Apontamento.Update(input); }

            return Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] ApontamentoInput input)
        {
            var data = _Apontamento.Update(input);
            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] ApontamentoInput input)
        {
            var data = _Apontamento.GetAll((bool)input.Fl_Ativo).ProjectTo<ApontamentoOutput>();

            return Response(true, "Sucesso", "...", data, "success");
        }

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] ApontamentoInput input)
        {
            var data = _Apontamento.UpdateStatus(input.Id_Apontamento);

            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] ApontamentoInput input)
        {
            var data = _Apontamento.Remove(input.Id_Apontamento);
            return Response(true, "Sucesso", "Registro removido com sucesso", data, "success");
        }

        protected new ActionResult Response(bool success, string Title, string Message, object result, string type)
        {
            return Ok(new
            {
                success,
                Title,
                Message,
                data = result,
                type
            });
        }


    }
}
