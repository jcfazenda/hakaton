using api.Domain.Repository.Interface.Testes;
using api.Domain.Views.Input.Testes;
using api.Domain.Views.Output.Testes;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Testes
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/TesteProcedimentoTipo")]
    public class TesteProcedimentoTipoController : Controller
    {

        private readonly ITesteProcedimentoTipoRepository _TesteProcedimentoTipo;

        public TesteProcedimentoTipoController(ITesteProcedimentoTipoRepository TesteProcedimentoTipo)
        {
            _TesteProcedimentoTipo = TesteProcedimentoTipo;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] TesteProcedimentoTipoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Teste_Procedimento_Tipo == 0) { _TesteProcedimentoTipo.Create(input); }
            if (input.Id_Teste_Procedimento_Tipo > 0) { _TesteProcedimentoTipo.Update(input); }

            return Response(true, "Sucesso", "Operação realizada com sucesso", null, "success");
        }

        [HttpPost("GetAny")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAny([FromBody] TesteProcedimentoTipoInput input)
        {
            var data = _TesteProcedimentoTipo.GetAll().ProjectTo<TesteProcedimentoTipoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] TesteProcedimentoTipoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _TesteProcedimentoTipo.Remove(input.Id);
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
