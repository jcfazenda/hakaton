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
    [Route("{tenant_database}/api/Empresa")]
    public class EmpresaController : Controller
    {

        private readonly IEmpresaRepository _Empresa;
        private readonly IEmpresaEnderecoRepository _EmpresaEndereco;

        public EmpresaController(IEmpresaRepository Empresa,
                                 IEmpresaEnderecoRepository EmpresaEndereco)
        {
            _Empresa = Empresa;
            _EmpresaEndereco = EmpresaEndereco;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] EmpresaInput input)
        {
            if (input == null ) { return Response(true, "Alerta", "não foi possível executar esta tarefa.", null, "warn"); }

            if (input.Id_Empresa > 0) { _Empresa.Update(input); }
            if (input.Id_Empresa == 0) { input.EmpresaEndereco.Id_Empresa = _Empresa.Create(input); }

            if (input.EmpresaEndereco.Id_Empresa_Endereco > 0) { _EmpresaEndereco.Update(input.EmpresaEndereco); }
            if (input.EmpresaEndereco.Id_Empresa_Endereco == 0) { input.Id_Empresa_Endereco = _EmpresaEndereco.Create(input.EmpresaEndereco); }
            

            _Empresa.UpdateIdEndereco(input.EmpresaEndereco.Id_Empresa, input.Id_Empresa_Endereco);

            return Response(true, "Sucesso", "base de dados atuaalizada com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] EmpresaInput input)
        {
            var data = _Empresa.Update(input);
            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] EmpresaInput input)
        {
            var data = _Empresa.GetAll((bool)input.Fl_Ativo).ProjectTo<EmpresaOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }
         

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] EmpresaInput input)
        {
            var data = _Empresa.UpdateStatus(input.Id_Empresa);

            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] EmpresaInput input)
         {
            _EmpresaEndereco.RemoveByEmpresa(input.Id_Empresa);
            _Empresa.Remove(input.Id_Empresa);

            return Response(true, "Sucesso", "Registro removido com sucesso", null, "success");
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
