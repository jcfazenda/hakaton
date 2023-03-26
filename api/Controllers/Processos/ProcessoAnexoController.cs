using api.Domain.Repository.Interface.Processos;
using api.Domain.Views.Input.Processos;
using api.Domain.Views.Output.Processos;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace api.Controllers.Processos
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/ProcessoAnexo")]
    public class ProcessoAnexoController : Controller
    {

        private readonly IProcessoAnexoRepository _ProcessoAnexo;

        public ProcessoAnexoController(IProcessoAnexoRepository ProcessoAnexo)
        {
            _ProcessoAnexo = ProcessoAnexo;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] ProcessoAnexoInput input)
        {
            _ProcessoAnexo.Create(input);

            return Response(true, "Sucesso", "processo realizado com sucesso", null, "success");
        }

        [HttpPost("GetByProcesso")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByProcesso([FromBody] ProcessoAnexoInput input)
        {
            var data = _ProcessoAnexo.GetByProcesso((long)input.Id_Processo).ProjectTo<ProcessoAnexoOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] ProcessoAnexoInput input)
        {
            var data = _ProcessoAnexo.Remove(input.Id_Processo_Anexo);
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
