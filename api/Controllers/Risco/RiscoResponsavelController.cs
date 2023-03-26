using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using api.Domain.Views.Output.Risco;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Risco
{

    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/RiscoResponsavel")]
    public class RiscoResponsavelController : Controller
    {

        private readonly IRiscoResponsavelRepository _RiscoResponsavel;

        public RiscoResponsavelController(IRiscoResponsavelRepository RiscoResponsavel)
        {
            _RiscoResponsavel = RiscoResponsavel;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] RiscoResponsavelInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _RiscoResponsavel.Create(input);

            return Response(true, "Sucesso", "Registro associado com sucesso", null, "success");
        }

        [HttpPost("GetByRisco")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByRisco([FromBody] RiscoResponsavelInput input)
        {
            var data = _RiscoResponsavel.GetByRisco(input.Id_Risco).ProjectTo<RiscoResponsavelOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] RiscoResponsavelInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _RiscoResponsavel.Remove(input.Id);
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
