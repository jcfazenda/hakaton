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
    [Route("{tenant_database}/api/Causas")]
    public class CausasController : Controller
    {

        private readonly ICausasRepository _causas;

        public CausasController(ICausasRepository causas)
        {
            _causas = causas;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] CausasInput input)
        {

            if (input.Id_Causa == 0) { _causas.Create(input); }
            if (input.Id_Causa > 0) { _causas.Update(input); }

            return Response(true, "sucess", null);
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] CausasInput input)
        {
            var data = _causas.Update(input);
            return Response(true, "sucess", data);
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] CausasInput input)
        {
            var data = _causas.GetAll((bool)input.Fl_Ativo).ProjectTo<CausasOutput>();

            return Response(true, "sucess", data);
        }

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] CausasInput input)
        {
            var data = _causas.UpdateStatus(input.Id_Causa);

            return Response(true, "sucess", data);
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] CausasInput input)
        {
            var data = _causas.Remove(input.Id_Causa);
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
