
using api.Domain.Repository.Interface.PerfisAcesso.Telas;
using api.Domain.Views.Input.PerfisAcesso.Telas;
using api.Domain.Views.Output.PerfisAcesso.Telas;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace api.Controllers.PerfisAcesso.Telas
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/NivelAcessoTelaFuncao")]
    public class NivelAcessoTelaFuncaoController : Controller
    {

        private readonly INivelAcessoTelaFuncaoRepository _NivelAcessoTelaFuncao;
        private readonly ITelaRepository _tela;

        public NivelAcessoTelaFuncaoController(INivelAcessoTelaFuncaoRepository NivelAcessoTelaFuncao, ITelaRepository tela)
        {
            _NivelAcessoTelaFuncao = NivelAcessoTelaFuncao;
            _tela = tela;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] NivelAcessoTelaFuncaoInput input)
        { 
            var Exist = _NivelAcessoTelaFuncao.GetExist(input).FirstOrDefault();

            if (Exist == null) { _NivelAcessoTelaFuncao.Create(input); }
            if (Exist != null) { _NivelAcessoTelaFuncao.Remove(Exist.Id_Nivel_Acesso_Tela_Funcao); }

            return Response(true, "Sucesso", "base de dados atuaalizada com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] NivelAcessoTelaFuncaoInput input)
        {
            var data = _NivelAcessoTelaFuncao.Update(input);
            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] NivelAcessoTelaFuncaoInput input)
        {
            var data = _NivelAcessoTelaFuncao.GetAll((bool)input.Fl_Ativo).ProjectTo<NivelAcessoTelaFuncaoOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }

        [HttpPost("GetByNivel")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByNivel([FromBody] NivelAcessoTelaFuncaoInput input)
        {
            var data = _NivelAcessoTelaFuncao.GetByNivel(input.Id_Nivel_Acesso).ProjectTo<NivelAcessoTelaFuncaoOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }
         

        [HttpPost("GetByNivelTela")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByNivelTela([FromBody] NivelAcessoTelaFuncaoInput input)
        {
            try
            {
                if(input.tela_url != null)
                {
                    TelaOutput tela = _tela.GetByURL(input.tela_url).ProjectTo<TelaOutput>().FirstOrDefault(); 

                    var data = _NivelAcessoTelaFuncao.GetByNivelTela(input.Id_Nivel_Acesso, tela.Id_Tela).ProjectTo<NivelAcessoTelaFuncaoOutput>(); 
                    return Response(true, "Sucesso", "..", data, "success");
                }

                return Response(true, "Sucesso", "..", null, "success");
            }
            catch (Exception)
            {
                return Response(false, "error", "..", null, "error");
            }

        }


        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] NivelAcessoTelaFuncaoInput input)
        {
            var data = _NivelAcessoTelaFuncao.UpdateStatus(input.Id_Tela_Funcao);

            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] NivelAcessoTelaFuncaoInput input)
        {
            var data = _NivelAcessoTelaFuncao.Remove(input.Id_Tela_Funcao);
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
