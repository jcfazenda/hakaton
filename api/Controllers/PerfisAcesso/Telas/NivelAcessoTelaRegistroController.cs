
using api.Domain.Repository.Interface.PerfisAcesso.Telas;
using api.Domain.Views.Input.PerfisAcesso.Telas;
using api.Domain.Views.Output.PerfisAcesso.Telas;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace api.Controllers.PerfisAcesso.Telas
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/NivelAcessoTelaRegistro")]
    public class NivelAcessoTelaRegistroController : Controller
    {

        private readonly INivelAcessoTelaRegistroRepository _NivelAcessoTelaRegistro;

        public NivelAcessoTelaRegistroController(INivelAcessoTelaRegistroRepository NivelAcessoTelaRegistro)
        {
            _NivelAcessoTelaRegistro = NivelAcessoTelaRegistro;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] NivelAcessoTelaRegistroInput input)
        {
            var Exist = _NivelAcessoTelaRegistro.GetExist(input).FirstOrDefault();

            if (Exist == null) { _NivelAcessoTelaRegistro.Create(input); }
            if (Exist != null) { _NivelAcessoTelaRegistro.Remove(Exist.Id_Nivel_Acesso_Tela_Registro); }

            return Response(true, "Sucesso", "base de dados atuaalizada com sucesso", null, "success");
        }

        [HttpPost("GetByTelaRegistro")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByTelaRegistro([FromBody] NivelAcessoTelaRegistroInput input)
        {
            var data = _NivelAcessoTelaRegistro.GetByTelaRegistro(input); 

            return Response(true, "Sucesso", "base de dados atuaalizada com sucesso", data, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] NivelAcessoTelaRegistroInput input)
        {
            var data = _NivelAcessoTelaRegistro.Update(input);
            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] NivelAcessoTelaRegistroInput input)
        {
            var data = _NivelAcessoTelaRegistro.GetAll((bool)input.Fl_Ativo).ProjectTo<NivelAcessoTelaRegistroOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }

        [HttpPost("GetByNivelAndTela")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByNivelAndTela([FromBody] NivelAcessoTelaRegistroInput input)
        {
            var data = _NivelAcessoTelaRegistro.GetByNivelAndTela((long)input.Id_Nivel_Acesso, (long)input.Id_Tela).ProjectTo<NivelAcessoTelaRegistroOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] NivelAcessoTelaRegistroInput input)
        {
            var data = _NivelAcessoTelaRegistro.UpdateStatus((long)input.Id_Nivel_Acesso_Tela_Registro);

            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] NivelAcessoTelaRegistroInput input)
        {
            var data = _NivelAcessoTelaRegistro.Remove((long)input.Id_Nivel_Acesso_Tela_Registro);
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
