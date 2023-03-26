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
    [Route("{tenant_database}/api/TesteAnexo")]
    public class TesteAnexoController : Controller
    {

        private readonly ITesteAnexoRepository _TesteAnexo;

        public TesteAnexoController(ITesteAnexoRepository TesteAnexo)
        {
            _TesteAnexo = TesteAnexo;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] TesteAnexoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Teste_Anexo == 0) { _TesteAnexo.Create(input); } 

            return Response(true, "Sucesso", "Operação realizada com sucesso", null, "success");
        }

        [HttpPost("GetAny")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAny([FromBody] TesteAnexoInput input)
        {
            var data = _TesteAnexo.GetAny(true).ProjectTo<TesteAnexoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("GetByTeste")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByTeste([FromBody] TesteAnexoInput input)
        {
            var data = _TesteAnexo.GetByTeste((long)input.Id_Teste).ProjectTo<TesteAnexoOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] TesteAnexoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _TesteAnexo.Remove(input.Id);
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
