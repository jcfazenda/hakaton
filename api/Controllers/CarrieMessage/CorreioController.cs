using api.Domain.Repository.Interface.CarrieMessage;
using api.Domain.Views.Input.CarrieMessage;
using api.Domain.Views.Output.CarrieMessage;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Empresas
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/Correio")]
    public class CorreioController : Controller
    {

        private readonly ICorreioRepository _Correio;

        public CorreioController(ICorreioRepository Correio)
        {
            _Correio = Correio;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] CorreioInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _Correio.Create(input);

            return Response(true, "Sucesso", "Registro associado com sucesso", null, "success");
        }


        [HttpPost("GetByCorreio")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByCorreio([FromBody] CorreioInput input)
        {
            var data = _Correio.GetByCorreio((long)input.Id_Correio).ProjectTo<CorreioOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("GetByUsuarioReceive")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByUsuarioReceive([FromBody] CorreioInput input)
        {
            var data = _Correio.GetByUsuarioReceive((long)input.Id_Usuario_Receive, input.Fl_Lido).ProjectTo<CorreioOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("UpdateLidoByUsuarioReceive")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateLidoByUsuarioReceive([FromBody] CorreioInput input)
        {
            var data = _Correio.GetByUsuarioReceive((long)input.Id_Usuario_Receive, false).ProjectTo<CorreioOutput>();
            foreach (var item in data)
            {
                _Correio.UpdateLido(item.Id_Correio);
            }
           

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }
 
        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] CorreioInput input)
        {
            var data = _Correio.Remove(input.Id);
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
