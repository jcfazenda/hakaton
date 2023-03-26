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
    [Route("{tenant_database}/api/ControleDemonstracaoFinanceiraControle")]
    public class ControleDemonstracaoFinanceiraControleController : Controller
    {

        private readonly IControleDemonstracaoFinanceiraControleRepository _ControleDemonstracaoFinanceiraControle;

        public ControleDemonstracaoFinanceiraControleController(IControleDemonstracaoFinanceiraControleRepository ControleDemonstracaoFinanceiraControle)
        {
            _ControleDemonstracaoFinanceiraControle = ControleDemonstracaoFinanceiraControle;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] ControleDemonstracaoFinanceiraControleInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _ControleDemonstracaoFinanceiraControle.Create(input);

            return Response(true, "Sucesso", "Registro associado com sucesso", null, "success");
        }

        [HttpPost("GetByControle")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByControle([FromBody] ControleDemonstracaoFinanceiraControleInput input)
        {
            var data = _ControleDemonstracaoFinanceiraControle.GetByControle(input.Id_Controle).ProjectTo<ControleDemonstracaoFinanceiraControleOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] ControleDemonstracaoFinanceiraControleInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _ControleDemonstracaoFinanceiraControle.Remove(input.Id);
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
