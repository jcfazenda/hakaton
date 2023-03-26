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
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/TesteProcedimentoAmostraExecucaoAtributo")]
    public class TesteProcedimentoAmostraExecucaoAtributoController : Controller
    {
        private readonly ITesteProcedimentoAmostraExecucaoAtributoRepository _TesteProcedimentoAmostraExecucaoAtributo;
        private readonly ITesteProcedimentoAmostraExecucaoRepository _TesteProcedimentoAmostraExecucao;

        public TesteProcedimentoAmostraExecucaoAtributoController(ITesteProcedimentoAmostraExecucaoAtributoRepository TesteProcedimentoAmostraExecucaoAtributo,
                                                                   ITesteProcedimentoAmostraExecucaoRepository TesteProcedimentoAmostraExecucao)
        {
            _TesteProcedimentoAmostraExecucaoAtributo = TesteProcedimentoAmostraExecucaoAtributo;
            _TesteProcedimentoAmostraExecucao = TesteProcedimentoAmostraExecucao;
        }

        [HttpPost("GetByProcedimentoAmostraExecucao")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByProcedimentoAmostraExecucao([FromBody] TesteProcedimentoAmostraExecucaoAtributoInput input)
        {
            var data = _TesteProcedimentoAmostraExecucaoAtributo.GetByProcedimentoAmostraExecucao((long)input.Id_Teste_Procedimento_Amostra_Execucao).ProjectTo<TesteProcedimentoAmostraExecucaoAtributoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] TesteProcedimentoAmostraExecucaoAtributoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var Execucoes = _TesteProcedimentoAmostraExecucao.GetByProcedimentoAmostra((long)input.Id_Teste_Procedimento_Amostra)
                                                             .ProjectTo<TesteProcedimentoAmostraExecucaoOutput>();

            if (input.Id_Teste_Procedimento_Amostra_Execucao_Atributo > 0)
            { 
                var update = _TesteProcedimentoAmostraExecucaoAtributo.GetByProcedimentoAmostraExecucaoAtributo((long)input.Id_Teste_Procedimento_Amostra_Execucao_Atributo)
                                                                      .ProjectTo<TesteProcedimentoAmostraExecucaoAtributoOutput>().FirstOrDefault();

                input.Teste_Procedimento_Amostra_Execucao_Atributo_Nome_Old = update.Teste_Procedimento_Amostra_Execucao_Atributo_Nome;
                _TesteProcedimentoAmostraExecucaoAtributo.Update(input); 

            } else
            {
                foreach (var item in Execucoes)
                {
                    input.Id_Teste_Procedimento_Amostra_Execucao = item.Id_Teste_Procedimento_Amostra_Execucao;
                    input.Id_Teste_Procedimento_Amostra          = item.Id_Teste_Procedimento_Amostra;

                    _TesteProcedimentoAmostraExecucaoAtributo.Create(input); 
                }
            }
             

            return Response(true, "Sucesso", "Operação realizada com sucesso", null, "success");
        }

        [HttpPost("GetAny")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAny([FromBody] TesteProcedimentoAmostraExecucaoAtributoInput input)
        {
            var data = _TesteProcedimentoAmostraExecucaoAtributo.GetAll().ProjectTo<TesteProcedimentoAmostraExecucaoAtributoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("UpdateStatusExecucaoAtributo")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatusExecucaoAtributo([FromBody] TesteProcedimentoAmostraExecucaoAtributoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _TesteProcedimentoAmostraExecucaoAtributo.UpdateStatusExecucaoAtributo(input.Id_Teste_Procedimento_Amostra_Execucao_Atributo);
            return Response(true, "Sucesso", "Registro removido com sucesso", data, "success");
        }

        [HttpPost("RemoveByProcedimentoAmostra")]
        [EnableCors("CorsPolicy")]
        public IActionResult RemoveByProcedimentoAmostra([FromBody] TesteProcedimentoAmostraExecucaoAtributoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _TesteProcedimentoAmostraExecucaoAtributo.RemoveByProcedimentoAmostra(input);
            return Response(true, "Sucesso", "Registro removido com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] TesteProcedimentoAmostraExecucaoAtributoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _TesteProcedimentoAmostraExecucaoAtributo.Remove((long)input.Id);
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
