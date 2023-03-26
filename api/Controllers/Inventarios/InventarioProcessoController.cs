using api.Domain.Repository.Interface.Inventarios;
using api.Domain.Repository.Interface.LGPD;
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
    [Route("{tenant_database}/api/InventarioProcesso")]
    public class InventarioProcessoController : Controller
    {

        private readonly IInventarioProcessoRepository _InventarioProcesso;

        public InventarioProcessoController(IInventarioProcessoRepository InventarioProcesso)
        {
            _InventarioProcesso = InventarioProcesso;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] InventarioProcessoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Inventario_Processo == 0) { _InventarioProcesso.Create(input); }
            if (input.Id_Inventario_Processo > 0) { _InventarioProcesso.Anexo(input); }

            return Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] InventarioProcessoInput input)
        {
            var data = _InventarioProcesso.Anexo(input);
            return Response(true, "Sucesso", "Atualização realizada com sucesso", data, "success");
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] InventarioProcessoInput input)
        {
            var data = _InventarioProcesso.GetAll(true).ProjectTo<InventarioProcessoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("GetByProcesso")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByProcesso([FromBody] InventarioProcessoInput input)
        {
            var data = _InventarioProcesso.GetByProcesso((long)input.Id_Processo).ProjectTo<InventarioProcessoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }


        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] InventarioProcessoInput input)
        {
            var data = _InventarioProcesso.Remove(input.Id_Inventario_Processo);
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
