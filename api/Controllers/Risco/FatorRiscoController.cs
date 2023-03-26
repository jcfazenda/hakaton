using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Controles
{

    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/FatorRisco")]
    public class FatorRiscoController : Controller
    {

        private readonly IFatorRiscoRepository _FatorRisco;

        public FatorRiscoController(IFatorRiscoRepository FatorRisco)
        {
            _FatorRisco = FatorRisco;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] FatorRiscoInput input)
        {
            try
            {
                if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

                if (input.Id_Fator_Risco > 0) { _FatorRisco.Update(input); }
                if (input.Id_Fator_Risco == 0) { _FatorRisco.Create(input); } 

                return Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
            }
            catch (System.Exception ex)
            {
                return Response(false, "Ops", ex.Message, null, "error");
            }

        }


        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] FatorRiscoInput input)
        {
            var data = _FatorRisco.UpdateStatus(input.Id_Fator_Risco);

            return Response(true, "Sucesso", "Status atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] FatorRiscoInput input)
        {
            var data = _FatorRisco.Remove(input.Id_Fator_Risco);
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
