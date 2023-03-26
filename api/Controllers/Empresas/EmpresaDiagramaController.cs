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
    [Route("{tenant_database}/api/EmpresaDiagrama")]
    public class EmpresaDiagramaController : Controller
    {

        private readonly IEmpresaDiagramaRepository _EmpresaDiagrama;

        public EmpresaDiagramaController(IEmpresaDiagramaRepository EmpresaDiagrama)
        {
            _EmpresaDiagrama = EmpresaDiagrama;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] EmpresaDiagramaInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); } 

            _EmpresaDiagrama.Create(input);

            return Response(true, "Sucesso", "Registro associado com sucesso", null, "success");
        }


        [HttpPost("GetByEmpresa")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByEmpresa([FromBody] EmpresaDiagramaInput input)
        {
            var data = _EmpresaDiagrama.GetByEmpresa((long)input.Id_Empresa).ProjectTo<EmpresaDiagramaOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] EmpresaDiagramaInput input)
        {
            var remove = _EmpresaDiagrama.GetByEmpresa((long)input.Id_Empresa).ProjectTo<EmpresaDiagramaOutput>();


            var data = _EmpresaDiagrama.Remove(input.Id);
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
