using api.Domain.Repository.Interface.Testes;
using api.Domain.Views.Input.Testes;
using api.Domain.Views.Output.Testes;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace api.Controllers.Testes
{

    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/TesteApontamentoTeste")]
    public class TesteApontamentoTesteController : Controller
    {

        private readonly ITesteApontamentoTesteRepository _TesteApontamentoTeste;

        public TesteApontamentoTesteController(ITesteApontamentoTesteRepository TesteApontamentoTeste)
        {
            _TesteApontamentoTeste = TesteApontamentoTeste;
        }

        [HttpPost("GetByTeste")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByTeste([FromBody] TesteApontamentoTesteInput input)
        {
            var data = _TesteApontamentoTeste.GetByTeste(input.Id_Teste).ProjectTo<TesteApontamentoTesteOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        } 

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] TesteApontamentoTesteInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var Exist = _TesteApontamentoTeste.GetByTesteApontamento((long)input.Id_Teste,
                                                                    (long)input.Id_Apontamento).ProjectTo<TesteApontamentoTesteOutput>().FirstOrDefault();

            if (Exist != null) { _TesteApontamentoTeste.Remove(Exist.Id_Teste_Apontamento_Teste); }
            if (Exist == null) { _TesteApontamentoTeste.Create(input); }

            return Response(true, "Sucesso", "Operação realizada com sucesso", null, "success");
        }


        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] TesteApontamentoTesteInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _TesteApontamentoTeste.Remove(input.Id_Teste_Apontamento_Teste);
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
