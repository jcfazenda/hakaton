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
    [Route("{tenant_database}/api/ComplianceNormaTrecho")]
    public class ComplianceNormaTrechoController : Controller
    {

        private readonly IComplianceNormaTrechoRepository _ComplianceNormaTrecho;

        public ComplianceNormaTrechoController(IComplianceNormaTrechoRepository ComplianceNormaTrecho)
        {
            _ComplianceNormaTrecho = ComplianceNormaTrecho;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] ComplianceNormaTrechoInput input)
        {
            try
            {
                if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

                if (input.Id_Compliance_Norma_Trecho > 0)  { _ComplianceNormaTrecho.Update(input); }
                if (input.Id_Compliance_Norma_Trecho == 0) { _ComplianceNormaTrecho.Create(input); }

                return Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
            }
            catch (System.Exception ex)
            {
                return Response(false, "Ops", ex.Message, null, "error");
            }
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] ComplianceNormaTrechoInput input)
        {
            var data = _ComplianceNormaTrecho.Update(input);
            return Response(true, "Sucesso", "Atualização realizada com sucesso", data, "success");
        }

        [HttpPost("GetByNorma")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByNorma([FromBody] ComplianceNormaTrechoInput input)
        {
            var data = _ComplianceNormaTrecho.GetByNorma(input.Id_Compliance_Norma).ProjectTo<ComplianceNormaTrechoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }


        [HttpPost("GetAny")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAny([FromBody] ComplianceNormaTrechoInput input)
        {
            var data = _ComplianceNormaTrecho.GetAny(true).ProjectTo<ComplianceNormaTrechoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] ComplianceNormaTrechoInput input)
        {
            var data = _ComplianceNormaTrecho.UpdateStatus(input.Id_Compliance_Norma_Trecho);

            return Response(true, "Sucesso", "Status atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] ComplianceNormaTrechoInput input)
        {
            var data = _ComplianceNormaTrecho.Remove(input.Id_Compliance_Norma_Trecho);
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
