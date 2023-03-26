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
    [Route("{tenant_database}/api/ControleAfirmacao")]
    public class ControleAfirmacaoController : Controller
    {

        private readonly IControleAfirmacaoRepository _ControleAfirmacao;

        public ControleAfirmacaoController(IControleAfirmacaoRepository ControleAfirmacao)
        {
            _ControleAfirmacao = ControleAfirmacao;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] ControleAfirmacaoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            input.Id_Controle_Afirmacao = input.Id;
            input.Controle_Afirmacao_Nome = input.Nome;

            if (input.Id_Controle_Afirmacao > 0) { _ControleAfirmacao.Update(input); }
            if (input.Id_Controle_Afirmacao == 0) { input.Id = _ControleAfirmacao.Create(input); }

            return Response(true, "Sucesso", "Registro associado com sucesso", input, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] ControleAfirmacaoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _ControleAfirmacao.Remove(input.Id);
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
