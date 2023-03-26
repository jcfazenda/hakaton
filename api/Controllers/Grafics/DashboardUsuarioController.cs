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
    [Route("{tenant_database}/api/DashboardUsuario")]
    public class DashboardUsuarioController : Controller
    {

        private readonly IDashboardUsuarioRepository _DashboardUsuario;

        public DashboardUsuarioController(IDashboardUsuarioRepository DashboardUsuario)
        {
            _DashboardUsuario = DashboardUsuario;
        }

        [HttpPost("GetByUsuario")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByUsuario([FromBody] DashboardUsuarioInput input)
        {
            var data = _DashboardUsuario.GetByUsuario((long)input.Id_Usuario).ProjectTo<DashboardUsuarioOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] DashboardUsuarioInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _DashboardUsuario.Create(input);

            return Response(true, "Sucesso", "processo realizado com sucesso", null, "success");
        } 

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] DashboardUsuarioInput input)
        {
            var data = _DashboardUsuario.Remove((long)input.Id_Dashboard_Usuario);
            return Response(true, "Sucesso", "Registro removido com sucesso", data, "success");
        }
        [HttpPost("RemoveBy")]
        [EnableCors("CorsPolicy")]
        public IActionResult RemoveBy([FromBody] DashboardUsuarioInput input)
        {
            var data = _DashboardUsuario.RemoveBy((long)input.Id_Dashboard, (long)input.Id_Usuario);
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
