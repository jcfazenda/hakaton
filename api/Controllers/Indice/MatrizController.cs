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
    [Route("{tenant_database}/api/Matriz")]
    public class MatrizController : Controller
    {

        private readonly IMatrizRepository _Matriz;
        private readonly IMatrizItemRepository _MatrizItem;

        public MatrizController(IMatrizRepository Matriz, IMatrizItemRepository MatrizItem)
        {
            _Matriz = Matriz;
            _MatrizItem = MatrizItem;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] MatrizInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Matriz == 0)
            {
                _Matriz.Create(input);
                Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
            }

            if (input.Id_Matriz > 0)
            {
                _Matriz.Update(input);
                Response(true, "Sucesso", "Registro alterado com sucesso", null, "success");
            }

            return Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] MatrizInput input)
        {
            var data = _Matriz.Update(input);
            return Response(true, "Sucesso", "Atualização realizada com sucesso", data, "success");
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] MatrizInput input)
        {
            var data = _Matriz.GetAll(input.Fl_Ativo == null ?  true : (bool)input.Fl_Ativo).ProjectTo<MatrizOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] MatrizInput input)
        {
            var data = _Matriz.UpdateStatus(input.Id_Matriz);

            return Response(true, "Sucesso", "Status atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] MatrizInput input)
        {
            var data = _Matriz.Remove(input.Id_Matriz);
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
