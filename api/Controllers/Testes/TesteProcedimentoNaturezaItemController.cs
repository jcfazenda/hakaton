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
    [Route("{tenant_database}/api/TesteProcedimentoNaturezaItem")]
    public class TesteProcedimentoNaturezaItemController : Controller
    {

        private readonly ITesteProcedimentoNaturezaItemRepository _TesteProcedimentoNaturezaItem;

        public TesteProcedimentoNaturezaItemController(ITesteProcedimentoNaturezaItemRepository TesteProcedimentoNaturezaItem)
        {
            _TesteProcedimentoNaturezaItem = TesteProcedimentoNaturezaItem;
        }
         

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] TesteProcedimentoNaturezaItemInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Teste_Procedimento_Natureza_Item > 0) { _TesteProcedimentoNaturezaItem.Update(input); }
            if (input.Id_Teste_Procedimento_Natureza_Item == 0) { input.Id_Teste_Procedimento_Natureza_Item = _TesteProcedimentoNaturezaItem.Create(input); } 

            return Response(true, "Sucesso", "Operação realizada com sucesso", input, "success");
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] TesteProcedimentoNaturezaItemInput input)
        {
            var data = _TesteProcedimentoNaturezaItem.GetAll().ProjectTo<TesteProcedimentoNaturezaItemOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] TesteProcedimentoNaturezaItemInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _TesteProcedimentoNaturezaItem.Remove((long)input.Id);
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
