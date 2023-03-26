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
    [Route("{tenant_database}/api/TesteProcedimentoAmostra")]
    public class TesteProcedimentoAmostraController : Controller
    {

        private readonly ITesteProcedimentoAmostraRepository _TesteProcedimentoAmostra;

        public TesteProcedimentoAmostraController(ITesteProcedimentoAmostraRepository TesteProcedimentoAmostra)
        {
            _TesteProcedimentoAmostra = TesteProcedimentoAmostra;
        }

        [HttpPost("GetByProcedimento")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByProcedimento([FromBody] TesteProcedimentoAmostraInput input)
        {
            var data = _TesteProcedimentoAmostra.GetByProcedimento((long)input.Id_Teste_Procedimento).ProjectTo<TesteProcedimentoAmostraOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }


        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] TesteProcedimentoAmostraInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Teste_Procedimento_Amostra > 0) { _TesteProcedimentoAmostra.Update(input); }
            if (input.Id_Teste_Procedimento_Amostra == 0) { _TesteProcedimentoAmostra.Create(input); }
            

            return Response(true, "Sucesso", "Operação realizada com sucesso", null, "success");
        }

        [HttpPost("GetAny")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAny([FromBody] TesteProcedimentoAmostraInput input)
        {
            var data = _TesteProcedimentoAmostra.GetAll().ProjectTo<TesteProcedimentoAmostraOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] TesteProcedimentoAmostraInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _TesteProcedimentoAmostra.Remove((long)input.Id);
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
