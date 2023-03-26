using api.Domain.Repository.Interface.Empresas;
using api.Domain.Views.Input.Empresas;
using api.Domain.Views.Output.Risco;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Risco
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/EmpresaAcaoSocietariaItem")]
    public class EmpresaAcaoSocietariaItemController : Controller
    {

        private readonly IEmpresaAcaoSocietariaItemRepository _EmpresaAcaoSocietariaItem;

        public EmpresaAcaoSocietariaItemController(IEmpresaAcaoSocietariaItemRepository EmpresaAcaoSocietariaItem)
        {
            _EmpresaAcaoSocietariaItem = EmpresaAcaoSocietariaItem;
        }


        [HttpPost("GetAny")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAny([FromBody] EmpresaAcaoSocietariaItemInput input)
        {
            var data = _EmpresaAcaoSocietariaItem.GetAny((bool)input.Fl_Ativo).ProjectTo<RiscoOutput>();

            return Response(true, "Sucesso", "...", data, "success");
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] EmpresaAcaoSocietariaItemInput input)
        {
            if (input.Id_Empresa_Acao_Societaria_Item > 0) { _EmpresaAcaoSocietariaItem.Update(input); }
            if (input.Id_Empresa_Acao_Societaria_Item == 0) { input.Id_Empresa_Acao_Societaria_Item = _EmpresaAcaoSocietariaItem.Create(input); }

            return Response(true, "Sucesso", "base de dados atualizada com sucesso", input, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] EmpresaAcaoSocietariaItemInput input)
        {
            var data = _EmpresaAcaoSocietariaItem.Update(input);
            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }  

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] EmpresaAcaoSocietariaItemInput input)
        {
            var data = _EmpresaAcaoSocietariaItem.Remove((long)input.Id);
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
