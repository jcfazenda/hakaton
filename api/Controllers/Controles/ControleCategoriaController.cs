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
    [Route("{tenant_database}/api/ControleCategoria")]
    public class ControleCategoriaController : Controller
    {

        private readonly IControleCategoriaRepository _ControleCategoria;

        public ControleCategoriaController(IControleCategoriaRepository ControleCategoria)
        {
            _ControleCategoria = ControleCategoria;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] ControleCategoriaInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            input.Id_Controle_Categoria = input.Id;
            input.Controle_Categoria_Nome = input.Nome;

            if (input.Id_Controle_Categoria > 0) { _ControleCategoria.Update(input); }
            if (input.Id_Controle_Categoria == 0) { input.Id = _ControleCategoria.Create(input); }

            return Response(true, "Sucesso", "Registro associado com sucesso", input, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] ControleCategoriaInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _ControleCategoria.Remove(input.Id);
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
