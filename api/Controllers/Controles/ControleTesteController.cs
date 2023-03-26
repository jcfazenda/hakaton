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
    [Route("{tenant_database}/api/ControleTeste")]
    public class ControleTesteController : Controller
    {

        private readonly IControleTesteRepository _ControleTeste;

        public ControleTesteController(IControleTesteRepository ControleTeste)
        {
            _ControleTeste = ControleTeste;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] ControleTesteInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _ControleTeste.Create(input);

            return Response(true, "Sucesso", "Registro associado com sucesso", null, "success");
        }

        [HttpPost("GetByControle")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByControle([FromBody] ControleTesteInput input)
        {
            var data = _ControleTeste.GetByControle(input.Id_Controle).ProjectTo<ControleTesteOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("GetByTeste")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByTeste([FromBody] ControleTesteInput input)
        {
            var data = _ControleTeste.GetByTeste(input.Id_Teste).ProjectTo<ControleTesteOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }


        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] ControleTesteInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _ControleTeste.Remove(input.Id);
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
