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
    [Route("{tenant_database}/api/TesteProcedimentoAmostraAnexo")]
    public class TesteProcedimentoAmostraAnexoController : Controller
    {

        private readonly ITesteProcedimentoAmostraAnexoRepository _TesteProcedimentoAmostraAnexo;

        public TesteProcedimentoAmostraAnexoController(ITesteProcedimentoAmostraAnexoRepository TesteProcedimentoAmostraAnexo)
        {
            _TesteProcedimentoAmostraAnexo = TesteProcedimentoAmostraAnexo;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] TesteProcedimentoAmostraAnexoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Teste_Procedimento_Amostra_Anexo == 0) { _TesteProcedimentoAmostraAnexo.Create(input); }

            return Response(true, "Sucesso", "Operação realizada com sucesso", null, "success");
        }

        [HttpPost("GetAny")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAny([FromBody] TesteProcedimentoAmostraAnexoInput input)
        {
            var data = _TesteProcedimentoAmostraAnexo.GetAny(true).ProjectTo<TesteProcedimentoAmostraAnexoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("GetByProcedimento")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByProcedimento([FromBody] TesteProcedimentoAmostraAnexoInput input)
        {
            var data = _TesteProcedimentoAmostraAnexo.GetByProcedimento((long)input.Id_Teste_Procedimento).ProjectTo<TesteProcedimentoAmostraAnexoOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] TesteProcedimentoAmostraAnexoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _TesteProcedimentoAmostraAnexo.Remove(input.Id);
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
