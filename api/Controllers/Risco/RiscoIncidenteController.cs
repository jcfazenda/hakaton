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
    [Route("{tenant_database}/api/RiscoIncidente")]
    public class RiscoIncidenteController : Controller
    {

        private readonly IRiscoIncidenteRepository _RiscoIncidente;

        public RiscoIncidenteController(IRiscoIncidenteRepository RiscoIncidente)
        {
            _RiscoIncidente = RiscoIncidente;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] RiscoIncidenteInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _RiscoIncidente.Create(input);

            return Response(true, "Sucesso", "Registro associado com sucesso", null, "success");
        }

        [HttpPost("GetByRisco")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByRisco([FromBody] RiscoIncidenteInput input)
        {
            var data = _RiscoIncidente.GetByRisco((long)input.Id_Risco).ProjectTo<RiscoIncidenteOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("GetByIncidente")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByIncidente([FromBody] RiscoIncidenteInput input)
        {
            var data = _RiscoIncidente.GetByIncidente((long)input.Id_Incidente).ProjectTo<RiscoIncidenteOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }



        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] RiscoIncidenteInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _RiscoIncidente.Remove(input.Id);
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
