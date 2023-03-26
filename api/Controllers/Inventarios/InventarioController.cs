using api.Domain.Repository.Interface.Inventarios;
using api.Domain.Views.Input.Inventarios;
using api.Domain.Views.Output.Inventarios;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Inventarios
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/Inventario")]
    public class InventarioController : Controller
    {

        private readonly IInventarioRepository _Inventario;

        public InventarioController(IInventarioRepository Inventario)
        {
            _Inventario = Inventario;
        }

        [HttpPost("Anexo")]
        [EnableCors("CorsPolicy")]
        public IActionResult Anexo([FromBody] InventarioInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _Inventario.Anexo(input);

            return Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
        }

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] InventarioInput input)
        {
            var data = _Inventario.UpdateStatus(input.Id_Inventario);

            return Response(true, "Sucesso", "Status atualizado com sucesso", data, "success");
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] InventarioInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Inventario == 0) { _Inventario.Create(input); } 
            if (input.Id_Inventario > 0) { _Inventario.Update(input); }

            return Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] InventarioInput input)
        {
            var data = _Inventario.Update(input);
            return Response(true, "Sucesso", "Atualização realizada com sucesso", data, "success");
        }

        [HttpPost("GetAny")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAny([FromBody] InventarioInput input)
        {
            var data = _Inventario.GetAll((bool)input.Fl_Ativo).ProjectTo<InventarioOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] InventarioInput input)
        {
            var data = _Inventario.Remove(input.Id_Inventario);
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
