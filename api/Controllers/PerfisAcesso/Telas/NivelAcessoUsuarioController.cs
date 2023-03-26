
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
    [Route("{tenant_database}/api/NivelAcessoUsuario")]
    public class NivelAcessoUsuarioController : Controller
    {

        private readonly INivelAcessoUsuarioRepository _NivelAcessoUsuario;

        public NivelAcessoUsuarioController(INivelAcessoUsuarioRepository NivelAcessoUsuario)
        {
            _NivelAcessoUsuario = NivelAcessoUsuario;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] NivelAcessoUsuarioInput input)
        { 
            var Exist = _NivelAcessoUsuario.GetExist(input).FirstOrDefault();

            _NivelAcessoUsuario.RemoveByUsuario(input.Id_Usuario);
            _NivelAcessoUsuario.Create(input); 

            return Response(true, "Sucesso", "base de dados atuaalizada com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] NivelAcessoUsuarioInput input)
        {
            var data = _NivelAcessoUsuario.Update(input);
            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] NivelAcessoUsuarioInput input)
        {
            var data = _NivelAcessoUsuario.GetAll((bool)input.Fl_Ativo).ProjectTo<NivelAcessoUsuarioOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }

        [HttpPost("GetByUsuario")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByUsuario([FromBody] NivelAcessoUsuarioInput input)
        {
            var data = _NivelAcessoUsuario.GetByUsuario(input.Id_Usuario).ProjectTo<NivelAcessoUsuarioOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] NivelAcessoUsuarioInput input)
        {
            var data = _NivelAcessoUsuario.UpdateStatus(input.Id_Nivel_Acesso_Usuario);

            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] NivelAcessoUsuarioInput input)
        {
            var data = _NivelAcessoUsuario.Remove(input.Id_Nivel_Acesso_Usuario);
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
