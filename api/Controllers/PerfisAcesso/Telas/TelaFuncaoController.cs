
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
    [Route("{tenant_database}/api/TelaFuncao")]
    public class TelaFuncaoController : Controller
    {

        private readonly ITelaFuncaoRepository _TelaFuncao;
        private readonly ITelaRepository _tela;

        public TelaFuncaoController(ITelaFuncaoRepository TelaFuncao, ITelaRepository tela)
        {
            _TelaFuncao = TelaFuncao;
            _tela = tela;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] TelaFuncaoInput input)
        {
 
            foreach (var item in input.ListIdTela)
            {
                TelaFuncaoOutput Existe = _TelaFuncao.GetByCodFuncao(input.Tela_Funcao_Codigo, item).ProjectTo<TelaFuncaoOutput>().FirstOrDefault();

                if (input.Id_Tela_Funcao > 0 && input.Id_Tela == item) { 

                    _TelaFuncao.Update(input);
                    
                } else
                {
                    if (Existe == null) { input.Id_Tela = item; input.Id_Tela_Funcao = _TelaFuncao.Create(input); } 
                    if (Existe != null) { input.Id_Tela_Funcao = _TelaFuncao.Update(input); }
                } 
            }  
             
            return Response(true, "Sucesso", "base de dados atuaalizada com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] TelaFuncaoInput input)
        {
            var data = _TelaFuncao.Update(input);
            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }


        [HttpPost("GetFuncaoTelaByUrl")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetFuncaoTelaByUrl([FromBody] NivelAcessoTelaFuncaoInput input)
        {
            TelaOutput tela = _tela.GetByURL(input.tela_url).ProjectTo<TelaOutput>().FirstOrDefault();

            var data = _TelaFuncao.GetByTela((long)tela.Id_Tela).ProjectTo<TelaFuncaoOutput>();
            return Response(true, "Sucesso", "..", data, "success"); 
        }


        [HttpPost("GetByTela")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByTela([FromBody] TelaFuncaoInput input)
        {
            var data = _TelaFuncao.GetByTela((long)input.Id_Tela).ProjectTo<TelaFuncaoOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }


        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] TelaFuncaoInput input)
        {
            var data = _TelaFuncao.GetAll((bool)input.Fl_Ativo).ProjectTo<TelaFuncaoOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] TelaFuncaoInput input)
        {
            var data = _TelaFuncao.UpdateStatus(input.Id_Tela_Funcao);

            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] TelaFuncaoInput input)
        {
            var data = _TelaFuncao.Remove(input.Id_Tela_Funcao);
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
