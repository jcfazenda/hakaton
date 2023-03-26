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
    [Route("{tenant_database}/api/TesteProcedimentoNatureza")]
    public class TesteProcedimentoNaturezaController : Controller
    {

        private readonly ITesteProcedimentoNaturezaRepository _TesteProcedimentoNatureza;

        public TesteProcedimentoNaturezaController(ITesteProcedimentoNaturezaRepository TesteProcedimentoNatureza)
        {
            _TesteProcedimentoNatureza = TesteProcedimentoNatureza;
        }

        [HttpPost("GetByProcedimento")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByProcedimento([FromBody] TesteProcedimentoNaturezaInput input)
        {
            var data = _TesteProcedimentoNatureza.GetByProcedimento((long)input.Id_Teste_Procedimento).ProjectTo<TesteProcedimentoNaturezaOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }


        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] TesteProcedimentoNaturezaInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Teste_Procedimento_Natureza == 0) { _TesteProcedimentoNatureza.Create(input); }
            if (input.Id_Teste_Procedimento_Natureza > 0) { _TesteProcedimentoNatureza.Update(input); }

            return Response(true, "Sucesso", "Operação realizada com sucesso", null, "success");
        }

        [HttpPost("GetAny")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAny([FromBody] TesteProcedimentoNaturezaInput input)
        {
            var data = _TesteProcedimentoNatureza.GetAll().ProjectTo<TesteProcedimentoNaturezaOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] TesteProcedimentoNaturezaInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _TesteProcedimentoNatureza.Remove(input.Id);
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
