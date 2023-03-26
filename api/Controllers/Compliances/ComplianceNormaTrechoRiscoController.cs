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
    [Route("{tenant_database}/api/ComplianceNormaTrechoRisco")]
    public class ComplianceNormaTrechoRiscoController : Controller
    {

        private readonly IComplianceNormaTrechoRiscoRepository _ComplianceNormaTrechoRisco;

        public ComplianceNormaTrechoRiscoController(IComplianceNormaTrechoRiscoRepository ComplianceNormaTrechoRisco)
        {
            _ComplianceNormaTrechoRisco = ComplianceNormaTrechoRisco;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] ComplianceNormaTrechoRiscoInput input)
        {
            try
            {
                if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); } 

                var data = _ComplianceNormaTrechoRisco.GetByNormaTrechoRisco(input.Id_Compliance_Norma_Trecho,
                                                                            input.Id_Risco).FirstOrDefault();

                if (data != null) { _ComplianceNormaTrechoRisco.RemoveNormaTrechoRisco(input.Id_Compliance_Norma_Trecho, input.Id_Risco); }
                if (data == null) { input.Id_Compliance_Norma_Trecho_Risco = _ComplianceNormaTrechoRisco.Create(input); }



                return Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
            }
            catch (System.Exception ex)
            {
                return Response(false, "Ops", ex.Message, null, "error");
            }
        } 
 

        [HttpPost("GetByNormaTrecho")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByNormaTrecho([FromBody] ComplianceNormaTrechoRiscoInput input)
        {
            var data = _ComplianceNormaTrechoRisco.GetByNormaTrecho(input.Id_Compliance_Norma_Trecho).ProjectTo<ComplianceNormaTrechoRiscoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }


        [HttpPost("GetAny")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAny([FromBody] ComplianceNormaTrechoRiscoInput input)
        {
            var data = _ComplianceNormaTrechoRisco.GetAny(true).ProjectTo<ComplianceNormaTrechoRiscoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }
 
        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] ComplianceNormaTrechoRiscoInput input)
        {
            var data = _ComplianceNormaTrechoRisco.Remove(input.Id_Compliance_Norma_Trecho_Risco);
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
