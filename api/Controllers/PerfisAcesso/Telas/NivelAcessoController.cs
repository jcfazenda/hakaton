
using api.Domain.Repository.Interface.PerfisAcesso.Telas;
using api.Domain.Views.Input.PerfisAcesso.Telas;
using api.Domain.Views.Output.PerfisAcesso.Telas;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.PerfisAcesso.Telas
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/NivelAcesso")]
    public class NivelAcessoController : Controller
    {

        private readonly INivelAcessoRepository _NivelAcesso;

        public NivelAcessoController(INivelAcessoRepository NivelAcesso)
        {
            _NivelAcesso = NivelAcesso;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] NivelAcessoInput input)
        {
            if (input.Id_Nivel_Acesso == 0) { _NivelAcesso.Create(input); }
            if (input.Id_Nivel_Acesso > 0) { _NivelAcesso.Update(input); }

            return Response(true, "Sucesso", "base de dados atuaalizada com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] NivelAcessoInput input)
        {
            var data = _NivelAcesso.Update(input);
            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] NivelAcessoInput input)
        {
            var data = _NivelAcesso.GetAll((bool)input.Fl_Ativo).ProjectTo<NivelAcessoOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] NivelAcessoInput input)
        {
            var data = _NivelAcesso.UpdateStatus(input.Id_Nivel_Acesso);

            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] NivelAcessoInput input)
        {
            var data = _NivelAcesso.Remove(input.Id_Nivel_Acesso);
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
