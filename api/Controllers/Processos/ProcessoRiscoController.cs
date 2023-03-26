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
    [Route("{tenant_database}/api/ProcessoRisco")]
    public class ProcessoRiscoController : Controller
    {

        private readonly IProcessoRiscoRepository _ProcessoRisco;

        public ProcessoRiscoController(IProcessoRiscoRepository ProcessoRisco)
        {
            _ProcessoRisco = ProcessoRisco;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] ProcessoRiscoInput input)
        {
            var Exist = _ProcessoRisco.GetByProcessoRisco(input.Id_Processo, input.Id_Risco).ProjectTo<ProcessoRiscoOutput>().FirstOrDefault();
            if (Exist == null) { _ProcessoRisco.Create(input); } 

            return Response(true, "Sucesso", "processo realizado com sucesso", null, "success");
        }
         
        [HttpPost("GetByProcesso")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByProcesso([FromBody] ProcessoRiscoInput input)
        {
            var data = _ProcessoRisco.GetByProcesso((long)input.Id_Processo).ProjectTo<ProcessoRiscoOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        } 

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] ProcessoRiscoInput input)
        {
            var data = _ProcessoRisco.Remove(input.Id_Processo_Risco);
            return Response(true, "Sucesso", "Registro removido com sucesso", data, "success");
        }

        [HttpPost("RemoveByProcessoRisco")]
        [EnableCors("CorsPolicy")]
        public IActionResult RemoveByProcessoRisco([FromBody] ProcessoRiscoInput input)
        {
            var data = _ProcessoRisco.RemoveByProcessoRisco(input.Id_Processo, input.Id_Risco);
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
