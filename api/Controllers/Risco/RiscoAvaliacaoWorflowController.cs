using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using api.Domain.Views.Output.Risco;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Risco
{
   // [Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/RiscoAvaliacaoWorkflow")]
    public class RiscoAvaliacaoWorkflowController : Controller
    {

        private readonly IRiscoAvaliacaoWorkflowRepository _RiscoAvaliacaoWorkflow;
        private readonly IRiscoAvaliacaoWorkflowAnexoRepository _RiscoAvaliacaoWorkflowAnexo;
        private readonly IRiscoAvaliacaoRepository _RiscoAvaliacao;

        public RiscoAvaliacaoWorkflowController(IRiscoAvaliacaoWorkflowRepository RiscoAvaliacaoWorkflow,
                                                IRiscoAvaliacaoWorkflowAnexoRepository RiscoAvaliacaoWorkflowAnexo,
                                                IRiscoAvaliacaoRepository RiscoAvaliacao)
        {
            _RiscoAvaliacaoWorkflow = RiscoAvaliacaoWorkflow;
            _RiscoAvaliacao = RiscoAvaliacao;
            _RiscoAvaliacaoWorkflowAnexo = RiscoAvaliacaoWorkflowAnexo;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] RiscoAvaliacaoWorkflowInput input)
        {
            if (input.Id_Risco_Avaliacao > 0) { _RiscoAvaliacao.UpdateStatusWorkFlow(input.Id_Risco_Avaliacao, input.Id_Risco_Avaliacao_Status);  }

            if (input.Id_Risco_Avaliacao_Workflow > 0) { _RiscoAvaliacaoWorkflow.Update(input); }

            if (input.Id_Risco_Avaliacao_Workflow == 0) { 

                input.Id_Risco_Avaliacao_Workflow = _RiscoAvaliacaoWorkflow.Create(input);

                if (input.Risco_Avaliacao_Workflow_Anexo_Nome != null)
                {
                    RiscoAvaliacaoWorkflowAnexoInput anexo = new RiscoAvaliacaoWorkflowAnexoInput();

                    anexo.Id_Risco_Avaliacao_Workflow           = input.Id_Risco_Avaliacao_Workflow;
                    anexo.Risco_Avaliacao_Workflow_Anexo_Nome   = input.Risco_Avaliacao_Workflow_Anexo_Nome;
                    anexo.Risco_Avaliacao_Workflow_Anexo_Byte   = input.Risco_Avaliacao_Workflow_Anexo_Byte;

                    _RiscoAvaliacaoWorkflowAnexo.Create(anexo);
                }


            } 

            return Response(true, "Sucesso", "base de dados atualizada com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] RiscoAvaliacaoWorkflowInput input)
        {
            var data = _RiscoAvaliacaoWorkflow.Update(input);
            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("GetAny")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAny([FromBody] RiscoAvaliacaoWorkflowInput input)
        {
            var data = _RiscoAvaliacaoWorkflow.GetAny((bool)input.Fl_Ativo).ProjectTo<RiscoOutput>();

            return Response(true, "Sucesso", "...", data, "success");
        }

        [HttpPost("GetByRiscoAvaliacao")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByRiscoAvaliacao([FromBody] RiscoAvaliacaoWorkflowInput input)
        {
            var data = _RiscoAvaliacaoWorkflow.GetByRiscoAvaliacao(input.Id_Risco_Avaliacao).ProjectTo<RiscoAvaliacaoWorkflowOutput>();

            return Response(true, "Sucesso", "...", data, "success");
        }


        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] RiscoAvaliacaoWorkflowInput input)
        {
            var data = _RiscoAvaliacaoWorkflow.UpdateStatus(input.Id_Risco_Avaliacao_Workflow);

            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] RiscoAvaliacaoWorkflowInput input)
        {
            var data = _RiscoAvaliacaoWorkflow.Remove(input.Id_Risco_Avaliacao_Workflow);
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
