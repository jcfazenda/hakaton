using api.Domain.Repository.Interface.Controles;
using api.Domain.Views.Input.Controles;
using api.Domain.Views.Output.Controles;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Controles
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/Controle")]
    public class ControleController : Controller
    {

        private readonly IControleRepository _Controle;

        public ControleController(IControleRepository Controle)
        {
            _Controle = Controle;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] ControleInput input)
        {
            try
            {
                if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

                input.Controle_Valor_Custo.ToString().Replace(".","").Replace(",", "");

                if (input.Id_Controle > 0)  { _Controle.Update(input); }
                if (input.Id_Controle == 0) { _Controle.Create(input); }
             

                return Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
            }
            catch (System.Exception ex)
            {
                return Response(false, "Ops", ex.Message, null, "error");
            }

        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] ControleInput input)
        {
            var data = _Controle.Update(input);
            return Response(true, "Sucesso", "Atualização realizada com sucesso", data, "success");
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] ControleInput input)
        {
            var data = _Controle.GetAll((bool)input.Fl_Ativo).ProjectTo<ControleOutput>();

            
            
            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] ControleInput input)
        {
            var data = _Controle.UpdateStatus(input.Id_Controle);

            return Response(true, "Sucesso", "Status atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] ControleInput input)
        {
            var data = _Controle.Remove(input.Id_Controle);
            return Response(true, "Sucesso", "Registro removido com sucesso", data, "success");
        }

        protected new ActionResult Response(bool success, string Title, string Message, object data, string type)
        {
            return Ok(new
            {
                success,
                Title,
                Message,
                data,
                type
            });
        }

    }
}
