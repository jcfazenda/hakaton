using api.Domain.Repository.Interface.PlanosAcao;
using api.Domain.Views.Input.PlanosAcao;
using api.Domain.Views.Output.PlanosAcao;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.PlanoAcaos
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/PlanoAcaoFluxoAprovacao")]
    public class PlanoAcaoFluxoAprovacaoController : Controller
    {

        private readonly IPlanoAcaoFluxoAprovacaoRepository _PlanoAcaoFluxoAprovacao;

        public PlanoAcaoFluxoAprovacaoController(IPlanoAcaoFluxoAprovacaoRepository PlanoAcaoFluxoAprovacao)
        {
            _PlanoAcaoFluxoAprovacao = PlanoAcaoFluxoAprovacao;
        }

        [HttpPost("GetByPlanoAcao")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByPlanoAcao([FromBody] PlanoAcaoFluxoAprovacaoInput input)
        {
            var data = _PlanoAcaoFluxoAprovacao.GetByPlanoAcao((long)input.Id_Plano_Acao).ProjectTo<PlanoAcaoFluxoAprovacaoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }


        [HttpPost("UpdateStatusworkFlow")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatusworkFlow([FromBody] PlanoAcaoFluxoAprovacaoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _PlanoAcaoFluxoAprovacao.UpdateStatusworkFlow(input);

            return Response(true, "Sucesso", "Operação realizada com sucesso", null, "success");
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] PlanoAcaoFluxoAprovacaoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _PlanoAcaoFluxoAprovacao.Create(input);

            return Response(true, "Sucesso", "Operação realizada com sucesso", null, "success");
        }

        [HttpPost("SaveObservacao")]
        [EnableCors("CorsPolicy")]
        public IActionResult SaveObservacao([FromBody] PlanoAcaoFluxoAprovacaoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _PlanoAcaoFluxoAprovacao.SaveObservacao(input);

            return Response(true, "Sucesso", "Operação realizada com sucesso", null, "success");
        }


        [HttpPost("GetAny")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAny([FromBody] PlanoAcaoFluxoAprovacaoInput input)
        {
            var data = _PlanoAcaoFluxoAprovacao.GetAny((bool)input.Fl_Ativo).ProjectTo<PlanoAcaoFluxoAprovacaoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] PlanoAcaoFluxoAprovacaoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _PlanoAcaoFluxoAprovacao.Remove((long)input.Id_Plano_Acao_Fluxo_Aprovacao);
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
