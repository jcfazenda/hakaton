using api.Domain.Repository.Interface.Indice;
using api.Domain.Views.Input.Indice;
using api.Domain.Views.Output.Indice;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace api.Controllers.Indice
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/MatrizItemCor")]
    public class MatrizItemCorController : Controller
    {

        private readonly IMatrizItemCorRepository _MatrizItemCor; 

        public MatrizItemCorController(IMatrizItemCorRepository MatrizItemCor)
        {
            _MatrizItemCor = MatrizItemCor; 
        }

        [HttpPost("GetByMatriz")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByMatriz([FromBody] MatrizItemCorInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var data = _MatrizItemCor.GetByMatriz(input.Id_Matriz);

            return Response(true, "Sucesso", "Registro criado com sucesso", data, "success");

        }


        [HttpPost("UpdateBackground")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateBackground([FromBody] MatrizItemCorInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var Exist = _MatrizItemCor.GetExist(input).ProjectTo<MatrizItemCorOutput>().FirstOrDefault();

            if (Exist == null) { _MatrizItemCor.Create(input); }

            if (Exist != null) {

                input.Id_Matriz_Item_Cor = Exist.Id_Matriz_Item_Cor;
                _MatrizItemCor.UpdateBackground(input);
            } 

            return Response(true, "Sucesso", "Registro criado com sucesso", null, "success");

        } 


        [HttpPost("RemoveByMatriz")]
        [EnableCors("CorsPolicy")]
        public IActionResult RemoveByMatriz([FromBody] MatrizItemCorInput input)
        {
            var data = _MatrizItemCor.RemoveByMatrizItem(input.Id_Matriz_Item);
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
