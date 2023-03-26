using api.Domain.Repository.Interface.Testes;
using api.Domain.Views.Input.Testes;
using api.Domain.Views.Output.Testes;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Testes
{
   // [Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/TesteProcedimento")]
    public class TesteProcedimentoController : Controller
    {
        private readonly ITesteProcedimentoRepository _TesteProcedimento;
        private readonly ITesteProcedimentoNaturezaRepository _TesteProcedimentoNatureza;
        private readonly ITesteProcedimentoAmostraAnexoRepository _TesteProcedimentoAmostraAnexo;

        public TesteProcedimentoController(ITesteProcedimentoRepository TesteProcedimento,
                                           ITesteProcedimentoNaturezaRepository TesteProcedimentoNatureza,
                                           ITesteProcedimentoAmostraAnexoRepository TesteProcedimentoAmostraAnexo)
        {
            _TesteProcedimento = TesteProcedimento;
            _TesteProcedimentoNatureza = TesteProcedimentoNatureza;
            _TesteProcedimentoAmostraAnexo = TesteProcedimentoAmostraAnexo;
        }
         
        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] TesteProcedimentoInput input)
        {
            try
            {
                if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

                if (input.Id_Teste_Procedimento > 0) { _TesteProcedimento.Update(input); }
                if (input.Id_Teste_Procedimento == 0) { input.Id_Teste_Procedimento = _TesteProcedimento.Create(input); }
                

                _TesteProcedimentoNatureza.RemoveByProcedimento((long)input.Id_Teste_Procedimento);
                foreach (var item in input.ListTesteProcedimentoNaturezaItem)
                {
                    TesteProcedimentoNaturezaInput _input = new TesteProcedimentoNaturezaInput();
                    _input.Id_Teste_Procedimento = input.Id_Teste_Procedimento;
                    _input.Id_Teste_Procedimento_Natureza_Item = item;

                    _TesteProcedimentoNatureza.Create(_input);
                }

                if (input.ListTesteProcedimentoAmostraAnexo != null)
                {
                    _TesteProcedimentoAmostraAnexo.RemoveByProcedimento((long)input.Id_Teste_Procedimento);
                    foreach (var item in input.ListTesteProcedimentoAmostraAnexo)
                    {
                        _TesteProcedimentoAmostraAnexo.Create(item);
                    }
                }


                return Response(true, "Sucesso", "Registro associado com sucesso", null, "success");
            }
            catch (System.Exception ex)
            {
                return Response(false, "Erro", ex.Message, null, "error");
            }

        }

        [HttpPost("GetByTeste")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByTeste([FromBody] TesteProcedimentoInput input)
        {
            var data = _TesteProcedimento.GetByTeste((long)input.Id_Teste).ProjectTo<TesteProcedimentoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] TesteProcedimentoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _TesteProcedimento.Remove(input.Id);
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
