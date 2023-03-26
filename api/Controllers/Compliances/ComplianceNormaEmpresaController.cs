using api.Domain.Repository.Interface.Compliances;
using api.Domain.Views.Input.Compliances;
using api.Domain.Views.Output.Compliances;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace api.Controllers.Compliances
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/ComplianceNormaEmpresa")]
    public class ComplianceNormaEmpresaController : Controller
    {

        private readonly IComplianceNormaEmpresaRepository _ComplianceNormaEmpresa;

        public ComplianceNormaEmpresaController(IComplianceNormaEmpresaRepository ComplianceNormaEmpresa)
        {
            _ComplianceNormaEmpresa = ComplianceNormaEmpresa;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] ComplianceNormaEmpresaInput input)
        {
            try
            {
                if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

                var data = _ComplianceNormaEmpresa.GetByNormaComEmpresa(input.Id_Compliance_Norma,
                                                                        input.Id_Empresa).FirstOrDefault();

                if (data != null) { _ComplianceNormaEmpresa.RemoveNormaComEmpresa(input.Id_Compliance_Norma, input.Id_Empresa); }
                if (data == null) { input.Id_Compliance_Norma_Empresa = _ComplianceNormaEmpresa.Create(input); }

                return Response(true, "Sucesso", "Registro criado com sucesso", input, "success");
            }
            catch (System.Exception ex)
            {
                return Response(false, "Ops", ex.Message, null, "error");
            }
        }
 
        [HttpPost("GetByNorma")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByNorma([FromBody] ComplianceNormaEmpresaInput input)
        {
            var data = _ComplianceNormaEmpresa.GetByNorma(input.Id_Compliance_Norma).ProjectTo<ComplianceNormaEmpresaOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("GetAny")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAny([FromBody] ComplianceNormaEmpresaInput input)
        {
            var data = _ComplianceNormaEmpresa.GetAny(true).ProjectTo<ComplianceNormaEmpresaOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }


        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] ComplianceNormaEmpresaInput input)
        {
            var data = _ComplianceNormaEmpresa.UpdateStatus(input.Id_Compliance_Norma_Empresa);

            return Response(true, "Sucesso", "Status atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] ComplianceNormaEmpresaInput input)
        {
            var data = _ComplianceNormaEmpresa.Remove(input.Id_Compliance_Norma_Empresa);
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
