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
    [Route("{tenant_database}/api/LgpdQuiz")]
    public class LgpdQuizController : Controller
    {

        private readonly ILgpdQuizRepository _LgpdQuiz;

        public LgpdQuizController(ILgpdQuizRepository LgpdQuiz)
        {
            _LgpdQuiz = LgpdQuiz;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] LgpdQuizInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Lgpd_Quiz > 0) { _LgpdQuiz.Update(input); }
            if (input.Id_Lgpd_Quiz == 0)  { _LgpdQuiz.Create(input); }

            var data = _LgpdQuiz.GetAll(true).ProjectTo<LgpdQuizOutput>();

            return Response(true, "Sucesso", "Registro criado com sucesso", data, "success");
        }

        [HttpPost("Create")]
        [EnableCors("CorsPolicy")]
        public IActionResult Create([FromBody] LgpdQuizInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _LgpdQuiz.Create(input);

            var data = _LgpdQuiz.GetAll(true).ProjectTo<LgpdQuizOutput>();

            return Response(true, "Sucesso", "Registro criado com sucesso", data, "success");
        }


        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] LgpdQuizInput input)
        {
            var data = _LgpdQuiz.Update(input);
            return Response(true, "Sucesso", "Atualização realizada com sucesso", data, "success");
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] LgpdQuizInput input)
        {
            var data = _LgpdQuiz.GetAll(input.Fl_Ativo == null ? true : (bool)input.Fl_Ativo).ProjectTo<LgpdQuizOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }


        [HttpPost("GetByTipo")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByTipo([FromBody] LgpdQuizInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _LgpdQuiz.GetByTipo(input.Id_Lgpd_Tipo).ProjectTo<LgpdQuizOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] LgpdQuizInput input)
        {
            var data = _LgpdQuiz.Remove(input.Id_Lgpd_Quiz);
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
