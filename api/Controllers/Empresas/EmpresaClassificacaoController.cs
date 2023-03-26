using api.Domain.Repository.Interface.Empresas;
using api.Domain.Views.Input.Empresas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Empresas
{
   // [Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/EmpresaClassificacao")]
    public class EmpresaClassificacaoController : Controller
    {

        private readonly IEmpresaClassificacaoRepository _EmpresaClassificacao;

        public EmpresaClassificacaoController(IEmpresaClassificacaoRepository EmpresaClassificacao)
        {
            _EmpresaClassificacao = EmpresaClassificacao;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] EmpresaClassificacaoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _EmpresaClassificacao.Create(input);

            return Response(true, "Sucesso", "Registro associado com sucesso", null, "success");
        }

        [HttpPost("SaveItem")]
        [EnableCors("CorsPolicy")]
        public IActionResult SaveItem([FromBody] EmpresaClassificacaoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            input.Id_Empresa_Classificacao = input.Id;
            input.Empresa_Classificacao_Nome = input.Nome;

            if (input.Id  > 0) { _EmpresaClassificacao.Update(input); }
            if (input.Id == 0) { input.Id_Empresa_Classificacao = _EmpresaClassificacao.Create(input); }  

            return Response(true, "Sucesso", "Registro associado com sucesso", input, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] EmpresaClassificacaoInput input)
        {
            var data = _EmpresaClassificacao.Remove(input.Id);
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
