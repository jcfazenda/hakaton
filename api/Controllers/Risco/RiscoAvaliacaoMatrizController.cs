using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using api.Domain.Views.Output.Risco;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Risco
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/RiscoAvaliacaoMatriz")]
    public class RiscoAvaliacaoMatrizController : Controller
    {

        private readonly IRiscoAvaliacaoMatrizRepository _RiscoAvaliacaoMatriz;

        public RiscoAvaliacaoMatrizController(IRiscoAvaliacaoMatrizRepository RiscoAvaliacaoMatriz)
        {
            _RiscoAvaliacaoMatriz = RiscoAvaliacaoMatriz;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] RiscoAvaliacaoMatrizInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Risco_Avaliacao == 0) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _RiscoAvaliacaoMatriz.RemoveByRiscoAvaliacao((long)input.Id_Risco_Avaliacao); 

            foreach (var item in input.ListRiscoAvaliacaoMatriz)
            { 
                _RiscoAvaliacaoMatriz.Create(item);
            }

            return Response(true, "Sucesso", "avaliação realizada com sucesso", null, "success");
        }

        [HttpPost("GetByAvaliacao")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByAvaliacao([FromBody] RiscoAvaliacaoMatrizInput input)
        {
            var data = _RiscoAvaliacaoMatriz.GetByAvaliacao((long)input.Id_Risco_Avaliacao).ProjectTo<RiscoAvaliacaoMatrizOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] RiscoAvaliacaoMatrizInput input)
        {
            var data = _RiscoAvaliacaoMatriz.Remove(input.Id);
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
