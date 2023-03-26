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
    [Route("{tenant_database}/api/ComplianceNormaEmpresaContraparte")]
    public class ComplianceNormaEmpresaContraparteController : Controller
    {

        private readonly IComplianceNormaEmpresaContraparteRepository _ComplianceNormaEmpresaContraparte;

        public ComplianceNormaEmpresaContraparteController(IComplianceNormaEmpresaContraparteRepository ComplianceNormaEmpresaContraparte)
        {
            _ComplianceNormaEmpresaContraparte = ComplianceNormaEmpresaContraparte;
        }


        [HttpPost("GetByNormaEmpresa")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByNormaEmpresa([FromBody] ComplianceNormaEmpresaContraparteInput input)
        {
            var data = _ComplianceNormaEmpresaContraparte.GetByNormaEmpresa(input.Id_Compliance_Norma_Empresa).ProjectTo<ComplianceNormaEmpresaContraparteOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] ComplianceNormaEmpresaContraparteInput input)
        {
            try
            {
                if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

                var data = _ComplianceNormaEmpresaContraparte.GetByEmpresaComNormaEmpresa(input.Id_Compliance_Norma_Empresa,
                                                                                           input.Id_Empresa).FirstOrDefault();

                if (data != null) { _ComplianceNormaEmpresaContraparte.RemoveEmpresaComNormaEmpresa(input.Id_Compliance_Norma_Empresa, input.Id_Empresa); }
                if (data == null) { input.Id_Compliance_Norma_Empresa = _ComplianceNormaEmpresaContraparte.Create(input); }

                return Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
            }
            catch (System.Exception ex)
            {
                return Response(false, "Ops", ex.Message, null, "error");
            }
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] ComplianceNormaEmpresaContraparteInput input)
        {
            var data = _ComplianceNormaEmpresaContraparte.Update(input);
            return Response(true, "Sucesso", "Atualização realizada com sucesso", data, "success");
        }

        [HttpPost("GetAny")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAny([FromBody] ComplianceNormaEmpresaContraparteInput input)
        {
            var data = _ComplianceNormaEmpresaContraparte.GetAny(true).ProjectTo<ComplianceNormaEmpresaContraparteOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] ComplianceNormaEmpresaContraparteInput input)
        {
            var data = _ComplianceNormaEmpresaContraparte.UpdateStatus(input.Id_Compliance_Norma_Empresa_Contraparte);

            return Response(true, "Sucesso", "Status atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] ComplianceNormaEmpresaContraparteInput input)
        {
            var data = _ComplianceNormaEmpresaContraparte.Remove(input.Id_Compliance_Norma_Empresa_Contraparte);
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
