using api.Domain.Repository.Interface.Compliances;
using api.Domain.Views.Input.Compliances;
using api.Domain.Views.Output.Compliances;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Compliances
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/ComplianceNormaTipo")]
    public class ComplianceNormaTipoController : Controller
    {

        private readonly IComplianceNormaTipoRepository _ComplianceNormaTipo;

        public ComplianceNormaTipoController(IComplianceNormaTipoRepository ComplianceNormaTipo)
        {
            _ComplianceNormaTipo = ComplianceNormaTipo;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] ComplianceNormaTipoInput input)
        {
            try
            {
                if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

                if (input.Id_Compliance_Norma_Tipo > 0) { _ComplianceNormaTipo.Update(input); }
                if (input.Id_Compliance_Norma_Tipo == 0) { _ComplianceNormaTipo.Create(input); }

                return Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
            }
            catch (System.Exception ex)
            {
                return Response(false, "Ops", ex.Message, null, "error");
            }
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] ComplianceNormaTipoInput input)
        {
            var data = _ComplianceNormaTipo.Update(input);
            return Response(true, "Sucesso", "Atualização realizada com sucesso", data, "success");
        }

        [HttpPost("GetAny")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAny([FromBody] ComplianceNormaTipoInput input)
        {
            var data = _ComplianceNormaTipo.GetAny(true).ProjectTo<ComplianceNormaTipoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] ComplianceNormaTipoInput input)
        {
            var data = _ComplianceNormaTipo.UpdateStatus(input.Id_Compliance_Norma_Tipo);

            return Response(true, "Sucesso", "Status atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] ComplianceNormaTipoInput input)
        {
            var data = _ComplianceNormaTipo.Remove(input.Id_Compliance_Norma_Tipo);
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
