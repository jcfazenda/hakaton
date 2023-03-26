using api.Domain.Repository.Interface.Processos;
using api.Domain.Views.Input.Processos;
using api.Domain.Views.Output.Processos;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Processos
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/ProcessoProcesso")]
    public class ProcessoProcessoController : Controller
    {

        private readonly IProcessoProcessoRepository _ProcessoProcesso;

        public ProcessoProcessoController(IProcessoProcessoRepository ProcessoProcesso)
        {
            _ProcessoProcesso = ProcessoProcesso;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] ProcessoProcessoInput input)
        {
            input.Id_Processo_Associado = input.Id;

            _ProcessoProcesso.Create(input);
            var data = _ProcessoProcesso.GetByProcesso(input.Id_Processo);

            return Response(true, "Sucesso", "processo realizado com sucesso", data, "success");
        }

        [HttpPost("GetByProcesso")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByProcesso([FromBody] ProcessoProcessoInput input)
        {
            var data = _ProcessoProcesso.GetByProcesso((long)input.Id_Processo).ProjectTo<ProcessoProcessoOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] ProcessoProcessoInput input)
        {
            _ProcessoProcesso.Remove(input.Id);
            var data = _ProcessoProcesso.GetByProcesso(input.Id_Processo);

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
