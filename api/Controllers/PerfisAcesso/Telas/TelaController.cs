
using api.Domain.Repository.Interface.PerfisAcesso.Telas;
using api.Domain.Views.Input.PerfisAcesso.Telas;
using api.Domain.Views.Output.PerfisAcesso.Telas;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.PerfisAcesso.Telas
{    
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/Tela")]
    public class TelaController : Controller
    {

        private readonly ITelaRepository _Tela; 

        public TelaController(ITelaRepository Tela)
        {
            _Tela = Tela; 
        }

        [Authorize]
        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] TelaInput input)
        {
            if (input.Id_Tela == 0) { _Tela.Create(input); }
            if (input.Id_Tela > 0) { _Tela.Update(input); } 

            return Response(true, "Sucesso", "base de dados atuaalizada com sucesso", null, "success");
        }

        [Authorize]
        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] TelaInput input)
        {
            var data = _Tela.Update(input);
            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [Authorize]
        [HttpPost("GetByUrl")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByUrl([FromBody] TelaInput input)
        {
            var data = _Tela.GetByURL(input.Tela_Url).ProjectTo<TelaOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }
                
        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] TelaInput input)
        {
            var data = _Tela.GetAll((bool)input.Fl_Ativo).ProjectTo<TelaOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }

        [Authorize]
        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] TelaInput input)
        {
            var data = _Tela.UpdateStatus(input.Id_Tela);

            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [Authorize]
        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] TelaInput input)
        {
            var data = _Tela.Remove(input.Id_Tela);
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
