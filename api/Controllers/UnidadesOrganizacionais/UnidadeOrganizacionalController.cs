using api.Domain.Repository.Interface.UnidadesOrganizacionais;
using api.Domain.Views.Input.UnidadesOrganizacionais;
using api.Domain.Views.Output.UnidadesOrganizacionais;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.UnidadeOrganizacionals
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/UnidadeOrganizacional")]
    public class UnidadeOrganizacionalController : Controller
    {

        private readonly IUnidadeOrganizacionalRepository _UnidadeOrganizacional; 


        public UnidadeOrganizacionalController(IUnidadeOrganizacionalRepository UnidadeOrganizacional)
        {
            _UnidadeOrganizacional = UnidadeOrganizacional; 
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] UnidadeOrganizacionalInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Unidade_Organizacional > 0) { _UnidadeOrganizacional.Update(input); }
            if (input.Id_Unidade_Organizacional == 0) { input.Id_Unidade_Organizacional = _UnidadeOrganizacional.Create(input); } 

            return Response(true, "Sucesso", "base de dados atuaalizada com sucesso", input, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] UnidadeOrganizacionalInput input)
        {
            var data = _UnidadeOrganizacional.Update(input);
            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("GetAny")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAny([FromBody] UnidadeOrganizacionalInput input)
        {
            var data = _UnidadeOrganizacional.GetAny((bool)input.Fl_Ativo).ProjectTo<UnidadeOrganizacionalOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }
 
        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] UnidadeOrganizacionalInput input)
        {
            var data = _UnidadeOrganizacional.UpdateStatus(input.Id_Unidade_Organizacional);

            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] UnidadeOrganizacionalInput input)
        {
            var data = _UnidadeOrganizacional.Remove(input.Id_Unidade_Organizacional);
            return Response(true, "Sucesso", "Registro removido com sucesso", data, "success");
        }

        protected new ActionResult Response(bool success, string Title, string Message, object result, string type)
        {
            return Ok(new
            {
                success,
                Title,
                Message,
                data = result,
                type
            });
        }

    }
}
