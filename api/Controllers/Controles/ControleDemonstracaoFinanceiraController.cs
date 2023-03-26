using api.Domain.Repository.Interface.Controles;
using api.Domain.Views.Input.Controles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Controles
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/ControleDemonstracaoFinanceira")]
    public class ControleDemonstracaoFinanceiraController : Controller
    {

        private readonly IControleDemonstracaoFinanceiraRepository _ControleDemonstracaoFinanceira;

        public ControleDemonstracaoFinanceiraController(IControleDemonstracaoFinanceiraRepository ControleDemonstracaoFinanceira)
        {
            _ControleDemonstracaoFinanceira = ControleDemonstracaoFinanceira;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] ControleDemonstracaoFinanceiraInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            input.Id_Controle_Demonstracao_Financeira = input.Id;
            input.Controle_Demonstracao_Financeira_Nome = input.Nome;

            if (input.Id_Controle_Demonstracao_Financeira > 0) { _ControleDemonstracaoFinanceira.Update(input); }
            if (input.Id_Controle_Demonstracao_Financeira == 0) { input.Id = _ControleDemonstracaoFinanceira.Create(input); }

            return Response(true, "Sucesso", "Registro associado com sucesso", input, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] ControleDemonstracaoFinanceiraInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _ControleDemonstracaoFinanceira.Remove(input.Id);
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
