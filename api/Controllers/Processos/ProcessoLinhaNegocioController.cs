using api.Domain.Repository.Interface.Processos;
using api.Domain.Views.Input.Processos;
using api.Domain.Views.Output.Processos;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Testes
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/ProcessoLinhaNegocio")]
    public class ProcessoLinhaNegocioController : Controller
    {

        private readonly IProcessoLinhaNegocioRepository _ProcessoLinhaNegocio;

        public ProcessoLinhaNegocioController(IProcessoLinhaNegocioRepository ProcessoLinhaNegocio)
        {
            _ProcessoLinhaNegocio = ProcessoLinhaNegocio;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] ProcessoLinhaNegocioInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Processo_Linha_Negocio == 0) { _ProcessoLinhaNegocio.Create(input); }

            return Response(true, "Sucesso", "Operação realizada com sucesso", null, "success");
        }
 

        [HttpPost("GetByProcesso")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByProcesso([FromBody] ProcessoLinhaNegocioInput input)
        {
            var data = _ProcessoLinhaNegocio.GetByProcesso((long)input.Id_Processo).ProjectTo<ProcessoLinhaNegocioOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] ProcessoLinhaNegocioInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _ProcessoLinhaNegocio.Remove(input.Id);
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
