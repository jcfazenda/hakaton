using api.Domain.Repository.Interface.Incidentes;
using api.Domain.Views.Input.Incidentes;
using api.Domain.Views.Output.Incidentes;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Incidentes
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/Incidente")]
    public class IncidenteController : Controller
    {

        private readonly IIncidenteRepository _incidente;

        public IncidenteController(IIncidenteRepository incidente)
        {
            _incidente = incidente;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] IncidenteInput input)
        {
            if (input == null ) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Incidente == 0) { 
                _incidente.Create(input);
                Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
            }

            if (input.Id_Incidente > 0) { 
                _incidente.Update(input);
                Response(true, "Sucesso", "Registro alterado com sucesso", null, "success");
            }

            return Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] IncidenteInput input)
        {
            var data = _incidente.Update(input);
            return Response(true, "Sucesso", "Atualização realizada com sucesso", data, "success");
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] IncidenteInput input)
        {
            var data = _incidente.GetAll((bool)input.Fl_Ativo).ProjectTo<IncidenteOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] IncidenteInput input)
        {
            var data = _incidente.UpdateStatus(input.Id_Incidente);

            return Response(true, "Sucesso", "Status atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] IncidenteInput input)
        {
            var data = _incidente.Remove(input.Id_Incidente);
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
