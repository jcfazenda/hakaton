using api.Domain.Repository.Interface.Indice;
using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using api.Domain.Views.Output.Indice;
using api.Domain.Views.Output.Risco;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace api.Controllers.Risco
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/RiscoCausa")]
    public class RiscoCausaController : Controller
    {

        private readonly IRiscoCausaRepository _RiscoCausa;
        private readonly IMatrizItemRepository _MatrizItem;

        public RiscoCausaController(IRiscoCausaRepository RiscoCausa, IMatrizItemRepository MatrizItem)
        {
            _RiscoCausa = RiscoCausa;
            _MatrizItem = MatrizItem;
        }


        [HttpPost("SaveRiscoCausaMatriz")]
        [EnableCors("CorsPolicy")]
        public IActionResult SaveRiscoCausaMatriz([FromBody] RiscoCausaInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _RiscoCausa.SaveRiscoCausaMatriz(input);

            return Response(true, "Sucesso", "Registro associado com sucesso", null, "success");
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] RiscoCausaInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }


            var matriz = _MatrizItem.GetAll().ProjectTo<MatrizItemOutput>().FirstOrDefault();
            input.Id_Matriz_Item = matriz.Id_Matriz_Item;

            _RiscoCausa.Create(input);

            return Response(true, "Sucesso", "Registro associado com sucesso", null, "success");
        }

        [HttpPost("GetByRisco")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByRisco([FromBody] RiscoCausaInput input)
        {
            var data = _RiscoCausa.GetByRisco((long)input.Id_Risco).ProjectTo<RiscoCausaOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] RiscoCausaInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }
            var data = _RiscoCausa.Remove(input.Id);
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
