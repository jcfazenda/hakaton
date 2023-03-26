using api.Domain.Repository.Interface.Grafics;
using api.Domain.Views.Input.Grafics;
using api.Domain.Views.Output.Grafics;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Grafics
{
    [Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/Dashboard")]
    public class DashboardController : Controller
    {

        private readonly IDashboardRepository _Dashboard;

        public DashboardController(IDashboardRepository Dashboard)
        {
            _Dashboard = Dashboard;
        }

        [HttpPost("GetByUser")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByUser([FromBody] DashboardInput input)
        {
            var data = _Dashboard.GetAny((bool)input.Fl_Ativo).ProjectTo<DashboardOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] DashboardInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }
 
            if (input.Id_Dashboard == 0) {  _Dashboard.Create(input); }
            if (input.Id_Dashboard > 0) { _Dashboard.Update(input); }

            return Response(true, "Sucesso", "processo realizado com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] DashboardInput input)
        {
            var data = _Dashboard.Update(input);
            return Response(true, "Sucesso", "Atualização realizada com sucesso", data, "success");
        }

        [HttpPost("GetAny")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAny([FromBody] DashboardInput input)
        {
            var data = _Dashboard.GetAny((bool)input.Fl_Ativo).ProjectTo<DashboardOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] DashboardInput input)
        {
            var data = _Dashboard.UpdateStatus(input.Id_Dashboard);

            return Response(true, "Sucesso", "Status atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] DashboardInput input)
        {
            var data = _Dashboard.Remove(input.Id_Dashboard);
            return Response(true, "Sucesso", "Registro removido com sucesso", data, "success");
        }

        protected new ActionResult Response(bool success, string Title, string Message, object result, string type)
        {
            return Ok(new
            {
                success,
                Title,
                Message,
                data = result,
                type
            });
        }

    }
}
