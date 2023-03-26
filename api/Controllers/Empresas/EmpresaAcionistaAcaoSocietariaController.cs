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
    [Route("{tenant_database}/api/EmpresaAcionistaAcaoSocietaria")]
    public class EmpresaAcionistaAcaoSocietariaController : Controller
    {

        private readonly IEmpresaAcionistaAcaoSocietariaRepository _EmpresaAcionistaAcaoSocietaria;

        public EmpresaAcionistaAcaoSocietariaController(IEmpresaAcionistaAcaoSocietariaRepository EmpresaAcionistaAcaoSocietaria)
        {
            _EmpresaAcionistaAcaoSocietaria = EmpresaAcionistaAcaoSocietaria;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] EmpresaAcionistaAcaoSocietariaInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _EmpresaAcionistaAcaoSocietaria.Create(input);

            return Response(true, "Sucesso", "Registro associado com sucesso", null, "success");
        }

        [HttpPost("GetByAcionista")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByAcionista([FromBody] EmpresaAcionistaAcaoSocietariaInput input)
        {
            var data = _EmpresaAcionistaAcaoSocietaria.GetByAcionista((long)input.Id_Acionista, (long)input.Id_Empresa).ProjectTo<EmpresaAcionistaAcaoSocietariaOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] EmpresaAcionistaAcaoSocietariaInput input)
        {
            var data = _EmpresaAcionistaAcaoSocietaria.Remove(input.Id);
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
