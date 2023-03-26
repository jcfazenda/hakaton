
using api.Domain.Models.Usuario;
using api.Domain.Repository.Interface.Usuario;
using api.Domain.Views.Input.Usuario;
using api.Domain.Views.Output.Usuario;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;

namespace api.Controllers.Usuario
{
    [Produces("application/json")]
    [Route("{tenant_database}/api/[controller]")]
    public class UsuariosController : Controller
    {
        private readonly IUsuariosRepository _Usuarios;


        public UsuariosController(IUsuariosRepository Usuarios)
        {
            _Usuarios = Usuarios;
        }

        [EnableCors("CorsPolicy")]
        [HttpPost("Connected")]
        public IActionResult Connected([FromBody] UsuariosInput usuario)
        {
            try
            {
                if (usuario.Usuario_Email != null)
                    if (usuario.Usuario_Email.Length > 0)
                        if (!Generics.Generics.IsEmail(usuario.Usuario_Email)) { return Response(false, "warn", "e-mail inválido", null, "warn"); }

                usuario.Usuario_Senha = Generics.Hash.HashValue(usuario.Usuario_Senha.Trim()); 

                Usuarios user = new Usuarios();
                         user = _Usuarios.GetAccess(usuario).FirstOrDefault();

                if (user == null) { return Response(false, "warn", "não conseguimos localizar você!.", null, "warn"); }

                return Response(true, "success", "seja bem vindo.", user, "success");

            }
            catch (System.Exception ex)
            {
                return Response(false, "warn", ex.Message, null, "warn");
            }
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] UsuariosInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Usuario == 0) { _Usuarios.Create(input); }
            if (input.Id_Usuario  > 0) { _Usuarios.Update(input); }

            return Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] UsuariosInput input)
        { 
            if (input.Id_Usuario == 0) { _Usuarios.Create(input); }
            if (input.Id_Usuario > 0) { _Usuarios.Update(input); }

            return Response(true, "Sucesso", "Atualização realizada com sucesso", null, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] UsuariosInput input)
        {
            var data = _Usuarios.Remove(input.Id_Usuario);
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
