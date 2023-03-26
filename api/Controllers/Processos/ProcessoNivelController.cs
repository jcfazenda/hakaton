using api.Controllers.Generics;
using api.Domain.Repository.Interface.Processos;
using api.Domain.Views.Input.Processos;
using api.Domain.Views.Output.Processos;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace api.Controllers.Processos
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/ProcessoNivel")]
    public class ProcessoNivelController : Controller
    {

        private readonly IProcessoNivelRepository _Processo;  

        public ProcessoNivelController(IProcessoNivelRepository Processo)
        {
            _Processo = Processo; 
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] ProcessoNivelInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            input.Id_Processo_Nivel   = input.Id;
            input.Processo_Nivel_Nome = input.Nome;

            if (input.Id_Processo_Nivel > 0)  { _Processo.Update(input); }
            if (input.Id_Processo_Nivel == 0) {input.Id_Processo_Nivel = _Processo.Create(input); }

            var data = ListItems.ListProcessoNivelSet(_Processo.GetAny(true).ToList(), 0);

            return Response(true, "Sucesso", "base de dados atuaalizada com sucesso", data, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] ProcessoNivelInput input)
        {
            var data = _Processo.Update(input);
            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("GetAny")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAny([FromBody] ProcessoNivelInput input)
        {
            var data = _Processo.GetAny((bool)input.Fl_Ativo).ProjectTo<ProcessoNivelOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] ProcessoNivelInput input)
        {
            var data = _Processo.UpdateStatus(input.Id_Processo_Nivel);

            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] ProcessoNivelInput input)
        {
            var data = _Processo.Remove(input.Id);
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
