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
    [Route("{tenant_database}/api/CategoriaRisco")]
    public class CategoriaRiscoController : Controller
    {

        private readonly ICategoriaRiscoRepository _CategoriaRisco;

        public CategoriaRiscoController(ICategoriaRiscoRepository CategoriaRisco)
        {
            _CategoriaRisco = CategoriaRisco;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] CategoriaRiscoInput input)
        {

            if (input.Id_Categoria_Risco == 0) { _CategoriaRisco.Create(input); }
            if (input.Id_Categoria_Risco > 0) { _CategoriaRisco.Update(input); }

            return Response(true, "sucess", null);
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] CategoriaRiscoInput input)
        {
            var data = _CategoriaRisco.Update(input);
            return Response(true, "sucess", data);
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] CategoriaRiscoInput input)
        {
            var data = _CategoriaRisco.GetAll((bool)input.Fl_Ativo).ProjectTo<CategoriaRiscoOutput>();

            return Response(true, "sucess", data);
        }

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] CategoriaRiscoInput input)
        {
            var data = _CategoriaRisco.UpdateStatus(input.Id_Categoria_Risco);

            return Response(true, "sucess", data);
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] CategoriaRiscoInput input)
        {
            var data = _CategoriaRisco.Remove(input.Id_Categoria_Risco);
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
