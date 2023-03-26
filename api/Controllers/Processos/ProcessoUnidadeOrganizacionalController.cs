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
    [Route("{tenant_database}/api/ProcessoUnidadeOrganizacional")]
    public class ProcessoUnidadeOrganizacionalController : Controller
    {

        private readonly IProcessoUnidadeOrganizacionalRepository _ProcessoUnidadeOrganizacional;

        public ProcessoUnidadeOrganizacionalController(IProcessoUnidadeOrganizacionalRepository ProcessoUnidadeOrganizacional)
        {
            _ProcessoUnidadeOrganizacional = ProcessoUnidadeOrganizacional;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] ProcessoUnidadeOrganizacionalInput input)
        {  
            _ProcessoUnidadeOrganizacional.Create(input);
            var data = _ProcessoUnidadeOrganizacional.GetByProcesso(input.Id_Processo);

            return Response(true, "Sucesso", "processo realizado com sucesso", data, "success");
        }

        [HttpPost("GetByProcesso")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByProcesso([FromBody] ProcessoUnidadeOrganizacionalInput input)
        {
            var data = _ProcessoUnidadeOrganizacional.GetByProcesso((long)input.Id_Processo).ProjectTo<ProcessoUnidadeOrganizacionalOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] ProcessoUnidadeOrganizacionalInput input)
        {
            _ProcessoUnidadeOrganizacional.Remove(input.Id);
            var data = _ProcessoUnidadeOrganizacional.GetByProcesso(input.Id_Processo);

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
