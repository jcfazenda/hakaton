using api.Domain.Repository.Interface.PlanosAcao;
using api.Domain.Views.Input.PlanosAcao;
using api.Domain.Views.Output.PlanosAcao;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.PlanosAcao
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/PlanoAcao")]
    public class PlanoAcaoController : Controller
    {

        private readonly IPlanoAcaoRepository _PlanoAcao;

        public PlanoAcaoController(IPlanoAcaoRepository PlanoAcao)
        {
            _PlanoAcao = PlanoAcao;
        }

        [HttpPost("UpdateStatusWorkflow")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatusWorkflow([FromBody] PlanoAcaoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _PlanoAcao.UpdatePlanoAcaoWorkflow(input);
            return Response(true, "Sucesso", "Registro alterado com sucesso", input, "success");
        }


        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] PlanoAcaoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Plano_Acao == 0)
            {
                _PlanoAcao.Create(input);
                Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
            }

            if (input.Id_Plano_Acao > 0)
            {
                _PlanoAcao.Update(input);
                Response(true, "Sucesso", "Registro alterado com sucesso", null, "success");
            }

            return Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] PlanoAcaoInput input)
        {
            var data = _PlanoAcao.Update(input);
            return Response(true, "Sucesso", "Atualização realizada com sucesso", data, "success");
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] PlanoAcaoInput input)
        {
            var data = _PlanoAcao.GetAll((bool)input.Fl_Ativo).ProjectTo<PlanoAcaoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] PlanoAcaoInput input)
        {
            var data = _PlanoAcao.UpdateStatus(input.Id_Plano_Acao);

            return Response(true, "Sucesso", "Status atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] PlanoAcaoInput input)
        {
            var data = _PlanoAcao.Remove(input.Id_Plano_Acao);
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
