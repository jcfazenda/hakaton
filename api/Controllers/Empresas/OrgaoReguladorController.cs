using api.Domain.Repository.Interface.Empresas;
using api.Domain.Views.Input.Empresas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Empresas
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/OrgaoRegulador")]
    public class OrgaoReguladorController : Controller
    {

        private readonly IOrgaoReguladorRepository _OrgaoRegulador;

        public OrgaoReguladorController(IOrgaoReguladorRepository OrgaoRegulador)
        {
            _OrgaoRegulador = OrgaoRegulador;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] OrgaoReguladorInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _OrgaoRegulador.Create(input);

            return Response(true, "Sucesso", "Registro associado com sucesso", null, "success");
        }

        [HttpPost("SaveItem")]
        [EnableCors("CorsPolicy")]
        public IActionResult SaveItem([FromBody] OrgaoReguladorInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            input.Id_Orgao_Regulador = input.Id;
            input.Orgao_Regulador_Nome = input.Nome;

            if (input.Id  > 0) { _OrgaoRegulador.Update(input); }
            if (input.Id == 0) { _OrgaoRegulador.Create(input); }

            return Response(true, "Sucesso", "Registro associado com sucesso", input, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] OrgaoReguladorInput input)
        {
            var data = _OrgaoRegulador.Remove(input.Id);
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
