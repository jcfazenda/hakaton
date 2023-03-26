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
    [Route("{tenant_database}/api/ProcessoResponsavel")]
    public class ProcessoResponsavelController : Controller
    {

        private readonly IProcessoResponsavelRepository _ProcessoResponsavel;

        public ProcessoResponsavelController(IProcessoResponsavelRepository ProcessoResponsavel)
        {
            _ProcessoResponsavel = ProcessoResponsavel;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] ProcessoResponsavelInput input)
        {
            var Exist = _ProcessoResponsavel.GetByProcessoResponsavel(input.Id_Processo, input.Id_Usuario).ProjectTo<ProcessoResponsavelOutput>().FirstOrDefault();
            if (Exist == null) { _ProcessoResponsavel.Create(input); }

            return Response(true, "Sucesso", "processo realizado com sucesso", null, "success");
        }

        [HttpPost("GetByProcesso")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByProcesso([FromBody] ProcessoResponsavelInput input)
        {
            var data = _ProcessoResponsavel.GetByProcesso((long)input.Id_Processo).ProjectTo<ProcessoResponsavelOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] ProcessoResponsavelInput input)
        {
            var data = _ProcessoResponsavel.Remove(input.Id_Processo_Responsavel);
            return Response(true, "Sucesso", "Registro removido com sucesso", data, "success");
        }

        [HttpPost("RemoveByProcessoResponsavel")]
        [EnableCors("CorsPolicy")]
        public IActionResult RemoveByProcessoResponsavel([FromBody] ProcessoResponsavelInput input)
        {
            var data = _ProcessoResponsavel.RemoveByProcessoResponsavel(input.Id_Processo, input.Id_Usuario);
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
