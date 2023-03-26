using api.Domain.Repository.Interface.LGPD;
using api.Domain.Views.Input.LGPD;
using api.Domain.Views.Output.LGPD;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.LGPD
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/LgpdTipo")]
    public class LgpdTipoController : Controller
    {

        private readonly ILgpdTipoRepository _LgpdTipo; 

        public LgpdTipoController(ILgpdTipoRepository LgpdTipo)
        {
            _LgpdTipo = LgpdTipo; 
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] LgpdTipoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Lgpd_Tipo == 0)
            {
                _LgpdTipo.Create(input);
                Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
            }

            if (input.Id_Lgpd_Tipo > 0)
            {
                _LgpdTipo.Update(input);
                Response(true, "Sucesso", "Registro alterado com sucesso", null, "success");
            }

            return Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] LgpdTipoInput input)
        {
            var data = _LgpdTipo.Update(input);
            return Response(true, "Sucesso", "Atualização realizada com sucesso", data, "success");
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] LgpdTipoInput input)
        {
            var data = _LgpdTipo.GetAll(input.Fl_Ativo == null ? true : (bool)input.Fl_Ativo).ProjectTo<LgpdTipoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] LgpdTipoInput input)
        {
            var data = _LgpdTipo.Remove(input.Id_Lgpd_Tipo);
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
