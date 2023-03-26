using api.Domain.Repository.Interface.Empresas;
using api.Domain.Views.Input.Empresas;
using api.Domain.Views.Output.Empresas;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Empresas
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/EmpresaEndereco")]
    public class EmpresaEnderecoController : Controller
    {

        private readonly IEmpresaEnderecoRepository _EmpresaEndereco;

        public EmpresaEnderecoController(IEmpresaEnderecoRepository EmpresaEndereco)
        {
            _EmpresaEndereco = EmpresaEndereco;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] EmpresaEnderecoInput input)
        {
            if (input == null) { return Response(true, "Alerta", "não foi possível executar esta tarefa.", null, "warn"); }

            if (input.Id_Empresa_Endereco == 0) { _EmpresaEndereco.Create(input); }
            if (input.Id_Empresa_Endereco > 0)  { _EmpresaEndereco.Update(input); }

            return Response(true, "Sucesso", "base de dados atuaalizada com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] EmpresaEnderecoInput input)
        {
            var data = _EmpresaEndereco.Update(input);
            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] EmpresaEnderecoInput input)
        {
            var data = _EmpresaEndereco.GetAll((bool)input.Fl_Ativo).ProjectTo<EmpresaEnderecoOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] EmpresaEnderecoInput input)
        {
            var data = _EmpresaEndereco.UpdateStatus(input.Id_Empresa_Endereco);

            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] EmpresaEnderecoInput input)
        {
            var data = _EmpresaEndereco.Remove(input.Id_Empresa_Endereco);
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
