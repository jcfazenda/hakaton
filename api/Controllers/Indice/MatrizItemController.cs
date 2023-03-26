using api.Domain.Repository.Interface.Indice;
using api.Domain.Views.Input.Indice;
using api.Domain.Views.Output.Indice;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Indice
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/MatrizItem")]
    public class MatrizItemController : Controller
    {

        private readonly IMatrizItemRepository _MatrizItem;
        private readonly IMatrizItemCorRepository _MatrizItemCor;

        private readonly IMatrizRepository _Matriz;

        public MatrizItemController(IMatrizRepository Matriz, IMatrizItemRepository MatrizItem, IMatrizItemCorRepository MatrizItemCor)
        {
            _MatrizItem = MatrizItem;
            _Matriz = Matriz;
            _MatrizItemCor = MatrizItemCor;
        }

        [HttpPost("SavePIV")]
        [EnableCors("CorsPolicy")]
        public IActionResult SavePIV([FromBody] MatrizItemInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }
              
            if (input.PIV == "PI") {

                MatrizItemCorInput _create = new MatrizItemCorInput();

                input.Tipo = "P";
                input.Id_Matriz_Item = _MatrizItem.Create(input); 

                input.Tipo = "I";
                input.Id_Matriz_Item = _MatrizItem.Create(input);

                _create.Id_Matriz_Item = input.Id_Matriz_Item;
                _create.Id_Matriz      = input.Id_Matriz;
                _create.Background      = "#8f8b8b";
                _create.Linha           = 0;
                _create.Coluna          = 0;
                _MatrizItemCor.Create(_create);

            }

            if (input.PIV == "V") { input.Tipo = "V"; _MatrizItem.Create(input); }


            return Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
        }

         
        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] MatrizItemInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Matriz_Item == 0)
            {
                _MatrizItem.Create(input);
                Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
            }

            if (input.Id_Matriz_Item > 0)
            {
                _MatrizItem.Update(input);
                Response(true, "Sucesso", "Registro alterado com sucesso", null, "success");
            }

            return Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] MatrizItemInput input)
        {
            var data = _MatrizItem.Update(input);
            return Response(true, "Sucesso", "Atualização realizada com sucesso", data, "success");
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] MatrizItemInput input)
        {
            var data = _MatrizItem.GetAll((bool)input.Fl_Ativo).ProjectTo<MatrizItemOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }
 

        [HttpPost("GetByMatriz")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByMatriz([FromBody] MatrizItemInput input)
        {
            var data = _MatrizItem.GetByMatriz((long)input.Id_Matriz).ProjectTo<MatrizItemOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }


        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] MatrizItemInput input)
        {
            var data = _MatrizItem.UpdateStatus(input.Id_Matriz_Item);

            return Response(true, "Sucesso", "Status atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] MatrizItemInput input)
        {
            var data = _MatrizItem.Remove(input.Id_Matriz_Item);
            return Response(true, "Sucesso", "Registro removido com sucesso", data, "success");
        }

        [HttpPost("RemoveByMatriz")]
        [EnableCors("CorsPolicy")]
        public IActionResult RemoveByMatriz([FromBody] MatrizItemInput input)
        {
            var data = _MatrizItem.RemoveByMatriz(input.Id_Matriz);
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
