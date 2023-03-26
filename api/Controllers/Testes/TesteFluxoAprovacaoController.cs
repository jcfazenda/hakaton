using api.Domain.Repository.Interface.Testes;
using api.Domain.Views.Input.Testes;
using api.Domain.Views.Output.Testes;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Testes
{

    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/TesteFluxoAprovacao")]
    public class TesteFluxoAprovacaoController : Controller
    {

        private readonly ITesteFluxoAprovacaoRepository _TesteFluxoAprovacao;

        public TesteFluxoAprovacaoController(ITesteFluxoAprovacaoRepository TesteFluxoAprovacao)
        {
            _TesteFluxoAprovacao = TesteFluxoAprovacao;
        }

        [HttpPost("GetByTeste")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByTeste([FromBody] TesteFluxoAprovacaoInput input)
        {
            var data = _TesteFluxoAprovacao.GetByTeste((long)input.Id_Teste).ProjectTo<TesteFluxoAprovacaoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }
        

        [HttpPost("UpdateStatusworkFlow")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatusworkFlow([FromBody] TesteFluxoAprovacaoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _TesteFluxoAprovacao.UpdateStatusworkFlow(input);

            return Response(true, "Sucesso", "Operação realizada com sucesso", null, "success");
        } 

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] TesteFluxoAprovacaoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _TesteFluxoAprovacao.Create(input);

            return Response(true, "Sucesso", "Operação realizada com sucesso", null, "success");
        }

        [HttpPost("SaveObservacao")]
        [EnableCors("CorsPolicy")]
        public IActionResult SaveObservacao([FromBody] TesteFluxoAprovacaoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _TesteFluxoAprovacao.SaveObservacao(input);

            return Response(true, "Sucesso", "Operação realizada com sucesso", null, "success");
        }


        [HttpPost("GetAny")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAny([FromBody] TesteFluxoAprovacaoInput input)
        {
            var data = _TesteFluxoAprovacao.GetAny((bool)input.Fl_Ativo).ProjectTo<TesteFluxoAprovacaoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] TesteFluxoAprovacaoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _TesteFluxoAprovacao.Remove((long)input.Id_Teste_Fluxo_Aprovacao);
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
