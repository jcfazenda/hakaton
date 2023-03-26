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
    [Route("{tenant_database}/api/ControleGrauAutomacao")]
    public class ControleGrauAutomacaoController : Controller
    {

        private readonly IControleGrauAutomacaoRepository _ControleGrauAutomacao;

        public ControleGrauAutomacaoController(IControleGrauAutomacaoRepository ControleGrauAutomacao)
        {
            _ControleGrauAutomacao = ControleGrauAutomacao;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] ControleGrauAutomacaoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            input.Id_Controle_Grau_Automacao   = input.Id;
            input.Controle_Grau_Automacao_Nome = input.Nome;

            if (input.Id_Controle_Grau_Automacao > 0)  { _ControleGrauAutomacao.Update(input); }
            if (input.Id_Controle_Grau_Automacao == 0) { input.Id = _ControleGrauAutomacao.Create(input); } 

            return Response(true, "Sucesso", "Registro associado com sucesso", input, "success");
        } 

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] ControleGrauAutomacaoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _ControleGrauAutomacao.Remove(input.Id);
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
