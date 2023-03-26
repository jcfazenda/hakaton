using api.Domain.Repository.Interface.LGPD;
using api.Domain.Views.Input.LGPD;
using api.Domain.Views.Output.LGPD;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace api.Controllers.LGPD
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/LgpdQuizProcesso")]
    public class LgpdQuizProcessoController : Controller
    {

        private readonly ILgpdQuizProcessoRepository _LgpdQuizProcesso;

        public LgpdQuizProcessoController(ILgpdQuizProcessoRepository LgpdQuizProcesso)
        {
            _LgpdQuizProcesso = LgpdQuizProcesso;
        }
        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] LgpdQuizProcessoInput input)
        {
            var data = _LgpdQuizProcesso.GetAll(input.Fl_Ativo == null ? true : (bool)input.Fl_Ativo).ProjectTo<LgpdQuizProcessoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("GetByProcesso")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByProcesso([FromBody] LgpdQuizProcessoInput input)
        {
            var data = _LgpdQuizProcesso.GetByProcesso(input.Id_Processo).ProjectTo<LgpdQuizProcessoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }
 
        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] LgpdQuizProcessoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }


            /* Busca se existe descritivo */  
            var existe = _LgpdQuizProcesso.GetByQuiz(input.Id_Lgpd_Quiz).ProjectTo<LgpdQuizProcessoOutput>().FirstOrDefault();

            if (input.Id_Lgpd_Quiz_Processo > 0)  { 
                _LgpdQuizProcesso.Update(input);  
            }

            if (input.Id_Lgpd_Quiz_Processo == 0) {             
                if (existe != null) { input.Lgpd_Quiz_Processo_Descritivo = existe.Lgpd_Quiz_Processo_Descritivo; }
                _LgpdQuizProcesso.Create(input);             
            }

            return Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] LgpdQuizProcessoInput input)
        {
            var data = _LgpdQuizProcesso.Update(input);
            return Response(true, "Sucesso", "Atualização realizada com sucesso", data, "success");
        }

        [HttpPost("UpdateDescritivo")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateDescritivo([FromBody] LgpdQuizProcessoInput input)
        {
            var data = _LgpdQuizProcesso.UpdateDescritivo(input);
            return Response(true, "Sucesso", "Atualização realizada com sucesso", data, "success");
        }


        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] LgpdQuizProcessoInput input)
        {
            var data = _LgpdQuizProcesso.Remove(input.Id_Lgpd_Quiz_Processo);
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
