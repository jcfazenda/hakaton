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
    [Route("{tenant_database}/api/ControleCategoriaObjetivo")]
    public class ControleCategoriaObjetivoController : Controller
    {

        private readonly IControleCategoriaObjetivoRepository _ControleCategoriaObjetivo;

        public ControleCategoriaObjetivoController(IControleCategoriaObjetivoRepository ControleCategoriaObjetivo)
        {
            _ControleCategoriaObjetivo = ControleCategoriaObjetivo;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] ControleCategoriaObjetivoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            input.Id_Controle_Categoria_Objetivo = input.Id;
            input.Controle_Categoria_Objetivo_Nome = input.Nome;

            if (input.Id_Controle_Categoria_Objetivo > 0) { _ControleCategoriaObjetivo.Update(input); }
            if (input.Id_Controle_Categoria_Objetivo == 0) { input.Id = _ControleCategoriaObjetivo.Create(input); }

            return Response(true, "Sucesso", "Registro associado com sucesso", input, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] ControleCategoriaObjetivoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _ControleCategoriaObjetivo.Remove(input.Id);
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
