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
    [Route("{tenant_database}/api/ControleResponsavel")]
    public class ControleResponsavelController : Controller
    {

        private readonly IControleResponsavelRepository _ControleResponsavel;

        public ControleResponsavelController(IControleResponsavelRepository ControleResponsavel)
        {
            _ControleResponsavel = ControleResponsavel;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] ControleResponsavelInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _ControleResponsavel.Create(input);

            return Response(true, "Sucesso", "Registro associado com sucesso", null, "success");
        }

        [HttpPost("GetByControle")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByControle([FromBody] ControleResponsavelInput input)
        {
            var data = _ControleResponsavel.GetByControle(input.Id_Controle).ProjectTo<ControleResponsavelOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] ControleResponsavelInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _ControleResponsavel.Remove(input.Id);
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
