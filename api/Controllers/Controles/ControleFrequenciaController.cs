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
    [Route("{tenant_database}/api/ControleFrequencia")]
    public class ControleFrequenciaController : Controller
    {

        private readonly IControleFrequenciaRepository _ControleFrequencia;

        public ControleFrequenciaController(IControleFrequenciaRepository ControleFrequencia)
        {
            _ControleFrequencia = ControleFrequencia;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] ControleFrequenciaInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            input.Id_Controle_Frequencia = input.Id;
            input.Controle_Frequencia_Nome = input.Nome;

            if (input.Id_Controle_Frequencia > 0) { _ControleFrequencia.Update(input); }
            if (input.Id_Controle_Frequencia == 0) { input.Id = _ControleFrequencia.Create(input); }

            return Response(true, "Sucesso", "Registro associado com sucesso", input, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] ControleFrequenciaInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _ControleFrequencia.Remove(input.Id);
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
