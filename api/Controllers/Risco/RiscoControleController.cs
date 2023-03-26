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
    [Route("{tenant_database}/api/RiscoControle")]
    public class RiscoControleController : Controller
    {

        private readonly IRiscoControleRepository _RiscoControle;

        public RiscoControleController(IRiscoControleRepository RiscoControle)
        {
            _RiscoControle = RiscoControle;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] RiscoControleInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _RiscoControle.Create(input);

            return Response(true, "Sucesso", "Registro associado com sucesso", null, "success");
        }         

        [HttpPost("GetByRisco")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByRisco([FromBody] RiscoControleInput input)
        {
            var data = _RiscoControle.GetByRisco((long)input.Id_Risco).ProjectTo<RiscoControleOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }
 
        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] RiscoControleInput input)
        {
            var data = _RiscoControle.Remove(input.Id);
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
