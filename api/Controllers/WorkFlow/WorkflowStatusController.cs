using api.Domain.Repository.Interface.WorkFlow;
using api.Domain.Views.Input.WorkFlow;
using api.Domain.Views.Output.WorkFlow;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.WorkFlow
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/WorkFlowStatus")]
    public class WorkFlowStatusController : Controller
    {

        private readonly IWorkFlowStatusRepository _WorkFlowStatus; 

        public WorkFlowStatusController(IWorkFlowStatusRepository WorkFlowStatus)
        {
            _WorkFlowStatus = WorkFlowStatus;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] WorkFlowStatusInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Workflow_Status == 0) { _WorkFlowStatus.Create(input); }  
            if (input.Id_Workflow_Status  > 0) { _WorkFlowStatus.Update(input); }

            return Response(true, "Sucesso", "Registro atualizado com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] WorkFlowStatusInput input)
        {
            var data = _WorkFlowStatus.Update(input);
            return Response(true, "Sucesso", "Atualização realizada com sucesso", data, "success");
        }

        [HttpPost("GetAny")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAny([FromBody] WorkFlowStatusInput input)
        {
            var data = _WorkFlowStatus.GetAny(true).ProjectTo<WorkFlowStatusOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] WorkFlowStatusInput input)
        {
            var data = _WorkFlowStatus.UpdateStatus(input.Id_Workflow_Status);

            return Response(true, "Sucesso", "Status atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] WorkFlowStatusInput input)
        {
            var data = _WorkFlowStatus.Remove(input.Id_Workflow_Status);
            return Response(true, "Sucesso", "Registro removido com sucesso", data, "success");
        }

        protected new ActionResult Response(bool success, string Title, string Message, object result, string type)
        {
            return Ok(new
            {
                success,
                Title,
                Message,
                data = result,
                type
            });
        }

    }
}
