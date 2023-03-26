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
    [Route("{tenant_database}/api/IncidenteCategoria")]
    public class IncidenteCategoriaController : Controller
    {

        private readonly IIncidenteCategoriaRepository _IncidenteCategoria;

        public IncidenteCategoriaController(IIncidenteCategoriaRepository IncidenteCategoria)
        {
            _IncidenteCategoria = IncidenteCategoria;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] IncidenteCategoriaInput input)
        {

            if (input.Id_Incidente_Categoria == 0) { _IncidenteCategoria.Create(input); }
            if (input.Id_Incidente_Categoria > 0) { _IncidenteCategoria.Update(input); }

            return Response(true, "sucess", null);
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] IncidenteCategoriaInput input)
        {
            var data = _IncidenteCategoria.Update(input);
            return Response(true, "sucess", data);
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] IncidenteCategoriaInput input)
        {
            var data = _IncidenteCategoria.GetAll((bool)input.Fl_Ativo).ProjectTo<IncidenteCategoriaOutput>();

            return Response(true, "sucess", data);
        }

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] IncidenteCategoriaInput input)
        {
            var data = _IncidenteCategoria.UpdateStatus(input.Id_Incidente_Categoria);

            return Response(true, "sucess", data);
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] IncidenteCategoriaInput input)
        {
            var data = _IncidenteCategoria.Remove(input.Id_Incidente_Categoria);
            return Response(true, "sucess", data);
        }

        protected new IActionResult Response(bool Success, string Messsage, object result = null)
        {
            return Ok(new
            {
                Success,
                Messsage,
                data = result
            });
        }

    }
}
