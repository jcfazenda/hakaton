using api.Domain.Repository.Interface.Testes;
using api.Domain.Views.Input.Testes;
using api.Domain.Views.Output.Testes;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace api.Controllers.Testes
{
   // [Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/TesteProcedimentoAmostraExecucao")]
    public class TesteProcedimentoAmostraExecucaoController : Controller
    {
        private readonly ITesteProcedimentoAmostraExecucaoRepository _TesteProcedimentoAmostraExecucao;
        private readonly ITesteProcedimentoAmostraExecucaoAtributoRepository _TesteProcedimentoAmostraExecucaoAtributo;

        public TesteProcedimentoAmostraExecucaoController(ITesteProcedimentoAmostraExecucaoRepository TesteProcedimentoAmostraExecucao,
                                                          ITesteProcedimentoAmostraExecucaoAtributoRepository TesteProcedimentoAmostraExecucaoAtributo)
        {
            _TesteProcedimentoAmostraExecucao = TesteProcedimentoAmostraExecucao;
            _TesteProcedimentoAmostraExecucaoAtributo = TesteProcedimentoAmostraExecucaoAtributo;
        }

        [HttpPost("GetByProcedimentoAmostra")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByProcedimentoAmostra([FromBody] TesteProcedimentoAmostraExecucaoInput input)
        {
            var data = _TesteProcedimentoAmostraExecucao.GetByProcedimentoAmostra((long)input.Id_Teste_Procedimento_Amostra).ProjectTo<TesteProcedimentoAmostraExecucaoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] TesteProcedimentoAmostraExecucaoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Teste_Procedimento_Amostra_Execucao  > 0) { _TesteProcedimentoAmostraExecucao.Update(input); }

            /* Se for novo, verifica se ja existe para copiar os atributos*/
            if (input.Id_Teste_Procedimento_Amostra_Execucao == 0) {

                var existe = _TesteProcedimentoAmostraExecucao.GetByProcedimentoAmostra((long)input.Id_Teste_Procedimento_Amostra).ProjectTo<TesteProcedimentoAmostraExecucaoOutput>().FirstOrDefault();
                long Id_Teste_Procedimento_Amostra_Execucao = _TesteProcedimentoAmostraExecucao.Create(input);
                
                if (existe != null)
                {
                    var ExisteAtributo = _TesteProcedimentoAmostraExecucaoAtributo.GetByProcedimentoAmostraExecucao(existe.Id_Teste_Procedimento_Amostra_Execucao)
                                                                                  .ProjectTo<TesteProcedimentoAmostraExecucaoAtributoOutput>();

                    foreach (var item in ExisteAtributo)
                    {
                        TesteProcedimentoAmostraExecucaoAtributoInput atributo = new TesteProcedimentoAmostraExecucaoAtributoInput();
                        atributo.Id_Teste_Procedimento_Amostra                     = input.Id_Teste_Procedimento_Amostra;
                        atributo.Id_Teste_Procedimento_Amostra_Execucao            = Id_Teste_Procedimento_Amostra_Execucao;
                        atributo.Teste_Procedimento_Amostra_Execucao_Atributo_Nome = item.Teste_Procedimento_Amostra_Execucao_Atributo_Nome;

                        _TesteProcedimentoAmostraExecucaoAtributo.Create(atributo);
                    } 
                    
                }
                
            } 

            return Response(true, "Sucesso", "Operação realizada com sucesso", null, "success");
        }

        [HttpPost("GetAny")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAny([FromBody] TesteProcedimentoAmostraExecucaoInput input)
        {
            var data = _TesteProcedimentoAmostraExecucao.GetAll().ProjectTo<TesteProcedimentoAmostraExecucaoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] TesteProcedimentoAmostraExecucaoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _TesteProcedimentoAmostraExecucao.Remove((long)input.Id);
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
