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
    [Route("{tenant_database}/api/ProcessoEmpresa")]
    public class ProcessoEmpresaController : Controller
    {

        private readonly IProcessoEmpresaRepository _ProcessoEmpresa;

        public ProcessoEmpresaController(IProcessoEmpresaRepository ProcessoEmpresa)
        {
            _ProcessoEmpresa = ProcessoEmpresa;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] ProcessoEmpresaInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Processo_Empresa == 0) { _ProcessoEmpresa.Create(input); }

            return Response(true, "Sucesso", "Operação realizada com sucesso", null, "success");
        }

        [HttpPost("GetByEmpresa")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByEmpresa([FromBody] ProcessoEmpresaInput input)
        {
            var data = _ProcessoEmpresa.GetByEmpresa((long)input.Id_Empresa).ProjectTo<ProcessoEmpresaOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }

        [HttpPost("GetByEmpresas")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByEmpresas([FromBody] ProcessoEmpresaInput input)
        {
            var data = _ProcessoEmpresa.GetByEmpresas((long)input.Id_Empresa, 
                                                      (bool)input.Fl_Ativo).ProjectTo<ProcessoEmpresaOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }


        [HttpPost("GetByProcesso")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByProcesso([FromBody] ProcessoEmpresaInput input)
        {
            var data = _ProcessoEmpresa.GetByProcesso((long)input.Id_Processo).ProjectTo<ProcessoEmpresaOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] ProcessoEmpresaInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _ProcessoEmpresa.Remove(input.Id);
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
