using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using api.Domain.Views.Output.Risco;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Risco
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/RiscoFator")]
    public class RiscoFatorController : Controller
    {

        private readonly IRiscoFatorRepository _RiscoFator;

        public RiscoFatorController(IRiscoFatorRepository RiscoFator)
        {
            _RiscoFator = RiscoFator;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] RiscoFatorInput input)
        {

            _RiscoFator.Create(input);
            return Response(true, "Sucesso", "Operação realizada com sucesso", null, "success");

        }

        [HttpPost("GetByRisco")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByRisco([FromBody] RiscoFatorInput input)
        {
            var data = _RiscoFator.GetByRisco((long)input.Id_Risco).ProjectTo<RiscoFatorOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] RiscoFatorInput input)
        {
            var data = _RiscoFator.Remove(input.Id);
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
