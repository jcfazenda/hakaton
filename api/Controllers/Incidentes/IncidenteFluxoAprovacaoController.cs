using api.Domain.Repository.Interface.Incidentes;
using api.Domain.Views.Input.Incidentes;
using api.Domain.Views.Output.Incidentes;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Incidentes
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/IncidenteFluxoAprovacao")]
    public class IncidenteFluxoAprovacaoController : Controller
    {
        private readonly IIncidenteFluxoAprovacaoRepository _IncidenteFluxoAprovacao;

        public IncidenteFluxoAprovacaoController(IIncidenteFluxoAprovacaoRepository IncidenteFluxoAprovacao)
        {
            _IncidenteFluxoAprovacao = IncidenteFluxoAprovacao;
        }


        [HttpPost("GetByRiscoAvaliacaoIncidente")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByRiscoAvaliacaoIncidente([FromBody] IncidenteFluxoAprovacaoInput input)
        {
            var data = _IncidenteFluxoAprovacao.GetByRiscoAvaliacaoIncidente((long)input.Id_Risco_Avaliacao, (long)input.Id_Incidente).ProjectTo<IncidenteFluxoAprovacaoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("GetByIncidente")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByIncidente([FromBody] IncidenteFluxoAprovacaoInput input)
        {
            var data = _IncidenteFluxoAprovacao.GetByIncidente((long)input.Id_Incidente).ProjectTo<IncidenteFluxoAprovacaoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("UpdateStatusworkFlow")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatusworkFlow([FromBody] IncidenteFluxoAprovacaoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _IncidenteFluxoAprovacao.UpdateStatusworkFlow(input);

            return Response(true, "Sucesso", "Operação realizada com sucesso", null, "success");
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] IncidenteFluxoAprovacaoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _IncidenteFluxoAprovacao.Create(input);

            return Response(true, "Sucesso", "Operação realizada com sucesso", null, "success");
        }

        [HttpPost("SaveObservacao")]
        [EnableCors("CorsPolicy")]
        public IActionResult SaveObservacao([FromBody] IncidenteFluxoAprovacaoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _IncidenteFluxoAprovacao.SaveObservacao(input);

            return Response(true, "Sucesso", "Operação realizada com sucesso", null, "success");
        }

        [HttpPost("GetAny")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAny([FromBody] IncidenteFluxoAprovacaoInput input)
        {
            var data = _IncidenteFluxoAprovacao.GetAny((bool)input.Fl_Ativo).ProjectTo<IncidenteFluxoAprovacaoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] IncidenteFluxoAprovacaoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _IncidenteFluxoAprovacao.Remove((long)input.Id_Incidente_Fluxo_Aprovacao);
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
