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
    [Route("{tenant_database}/api/CausaCategoria")]
    public class CausaCategoriaController : Controller
    {

        private readonly ICausaCategoriaRepository _causaCategoria;

        public CausaCategoriaController(ICausaCategoriaRepository causaCategoria)
        {
            _causaCategoria = causaCategoria;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] CausaCategoriaInput input)
        {

            if (input.Id_Causa_Categoria == 0) { _causaCategoria.Create(input); }
            if (input.Id_Causa_Categoria > 0) { _causaCategoria.Update(input); }

            return Response(true, "sucess", null);
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] CausaCategoriaInput input)
        {
            var data = _causaCategoria.Update(input);
            return Response(true, "sucess", data);
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] CausaCategoriaInput input)
        {
            var data = _causaCategoria.GetAll((bool)input.Fl_Ativo).ProjectTo<CausaCategoriaOutput>();

            return Response(true, "sucess", data);
        }

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] CausaCategoriaInput input)
        {
            var data = _causaCategoria.UpdateStatus(input.Id_Causa_Categoria);

            return Response(true, "sucess", data);
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] CausaCategoriaInput input)
        {
            var data = _causaCategoria.Remove(input.Id_Causa_Categoria);
            return Response(true, "sucess", data);
        }

        protected new IActionResult Response(bool Success, string Messsage, object result = null)
        {
            return Ok(new
            {
                Success,
                Messsage,
                data = result
            });
        }

    }
}
