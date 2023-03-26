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
    [Route("{tenant_database}/api/LgpdTipoDados")]
    public class LgpdTipoDadosController : Controller
    {

        private readonly ILgpdTipoDadosRepository _LgpdTipoDados;

        public LgpdTipoDadosController(ILgpdTipoDadosRepository LgpdTipoDados)
        {
            _LgpdTipoDados = LgpdTipoDados;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] LgpdTipoDadosInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Lgpd_Tipo_Dados > 0) { _LgpdTipoDados.Update(input); }
            if (input.Id_Lgpd_Tipo_Dados == 0) { _LgpdTipoDados.Create(input); }

            return Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] LgpdTipoDadosInput input)
        {
            var data = _LgpdTipoDados.Update(input);
            return Response(true, "Sucesso", "Atualização realizada com sucesso", data, "success");
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] LgpdTipoDadosInput input)
        {
            var data = _LgpdTipoDados.GetAll(input.Fl_Ativo == null ? true : (bool)input.Fl_Ativo).ProjectTo<LgpdTipoDadosOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] LgpdTipoDadosInput input)
        {
            var data = _LgpdTipoDados.Remove(input.Id_Lgpd_Tipo_Dados);
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
