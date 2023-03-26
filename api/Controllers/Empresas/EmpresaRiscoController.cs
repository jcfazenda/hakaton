using api.Domain.Repository.Interface.Empresas;
using api.Domain.Views.Input.Empresas;
using api.Domain.Views.Output.Empresas;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Empresas
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/EmpresaRisco")]
    public class EmpresaRiscoController : Controller
    {

        private readonly IEmpresaRiscoRepository _EmpresaRisco;

        public EmpresaRiscoController(IEmpresaRiscoRepository EmpresaRisco)
        {
            _EmpresaRisco = EmpresaRisco;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] EmpresaRiscoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _EmpresaRisco.Create(input);

            return Response(true, "Sucesso", "Registro associado com sucesso", null, "success");
        }

        [HttpPost("GetByEmpresa")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByEmpresa([FromBody] EmpresaRiscoInput input)
        {
            var data = _EmpresaRisco.GetByEmpresa((long)input.Id_Empresa, (bool)input.Fl_Ativo).ProjectTo<EmpresaRiscoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("GetByEmpresas")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByEmpresas([FromBody] EmpresaRiscoInput input)
        {
            var data = _EmpresaRisco.GetByEmpresas((long)input.Id_Empresa, (bool)input.Fl_Ativo).ProjectTo<EmpresaRiscoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }


        [HttpPost("GetByEmpresaList")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByEmpresaList([FromBody] EmpresaInput input)
        {
            var data = _EmpresaRisco.GetByEmpresaList(input.List, (bool)input.Fl_Ativo).ProjectTo<EmpresaRiscoOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }

        [HttpPost("GetByRiscoList")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByRiscoList([FromBody] EmpresaInput input)
        {
            var data = _EmpresaRisco.GetByRiscoList(input.List, (bool)input.Fl_Ativo).ProjectTo<EmpresaRiscoOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] EmpresaRiscoInput input)
        {
            var data = _EmpresaRisco.Remove((long)input.Id);
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
