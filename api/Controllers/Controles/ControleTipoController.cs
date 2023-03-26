using api.Domain.Repository.Interface.Controles;
using api.Domain.Views.Input.Controles;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Controles
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/ControleTipo")]
    public class ControleTipoController : Controller
    {

        private readonly IControleTipoRepository _ControleTipo;

        public ControleTipoController(IControleTipoRepository ControleTipo)
        {
            _ControleTipo = ControleTipo;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] ControleTipoInput input)
        {
            try
            {
                if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); } 

                if (input.Id_Controle_Tipo > 0) { _ControleTipo.Update(input); }
                if (input.Id_Controle_Tipo == 0) { _ControleTipo.Create(input); }


                return Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
            }
            catch (System.Exception ex)
            {
                return Response(false, "Ops", ex.Message, null, "error");
            }

        }
 

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] ControleTipoInput input)
        {
            var data = _ControleTipo.UpdateStatus(input.Id_Controle_Tipo);

            return Response(true, "Sucesso", "Status atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] ControleTipoInput input)
        {
            var data = _ControleTipo.Remove(input.Id_Controle_Tipo);
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
