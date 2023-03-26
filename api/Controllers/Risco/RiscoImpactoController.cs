using api.Domain.Repository.Interface.Indice;
using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using api.Domain.Views.Output.Indice;
using api.Domain.Views.Output.Risco;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace api.Controllers.Risco
{

    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/RiscoImpacto")]
    public class RiscoImpactoController : Controller
    {

        private readonly IRiscoImpactoRepository _RiscoImpacto;
        private readonly IMatrizItemRepository _MatrizItem;

        public RiscoImpactoController(IRiscoImpactoRepository RiscoImpacto, IMatrizItemRepository MatrizItem)
        {
            _RiscoImpacto = RiscoImpacto;
            _MatrizItem = MatrizItem;

    }

        [HttpPost("SaveRiscoImpactoMatriz")]
        [EnableCors("CorsPolicy")]
        public IActionResult SaveRiscoImpactoMatriz([FromBody] RiscoImpactoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _RiscoImpacto.SaveRiscoImpactoMatriz(input);

            return Response(true, "Sucesso", "Registro associado com sucesso", null, "success");
        }
         


        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] RiscoImpactoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var matriz = _MatrizItem.GetAll().ProjectTo<MatrizItemOutput>().FirstOrDefault();
            input.Id_Matriz_Item = matriz.Id_Matriz_Item;

            _RiscoImpacto.Create(input);

            return Response(true, "Sucesso", "Registro associado com sucesso", null, "success");
        }

        [HttpPost("GetByRisco")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByRisco([FromBody] RiscoImpactoInput input)
        {
            var data = _RiscoImpacto.GetByRisco((long)input.Id_Risco)/*.ProjectTo<RiscoImpactoOutput>()*/;

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] RiscoImpactoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }
            var data = _RiscoImpacto.Remove(input.Id);
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
