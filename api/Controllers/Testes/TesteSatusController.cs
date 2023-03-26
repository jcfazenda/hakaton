using api.Domain.Repository.Interface.Testes;
using api.Domain.Views.Input.Testes;
using api.Domain.Views.Output.Testes;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Testes
{
   // [Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/TesteStatus")]
    public class TesteStatusController : Controller
    {

        private readonly ITesteStatusRepository _TesteStatus;

        public TesteStatusController(ITesteStatusRepository TesteStatus)
        {
            _TesteStatus = TesteStatus;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] TesteStatusInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Teste_Status == 0) { _TesteStatus.Create(input); }
            if (input.Id_Teste_Status > 0) { _TesteStatus.Update(input); }

            return Response(true, "Sucesso", "Registro atualizado com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] TesteStatusInput input)
        {
            var data = _TesteStatus.Update(input);
            return Response(true, "Sucesso", "Atualização realizada com sucesso", data, "success");
        }

        [HttpPost("GetAny")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAny([FromBody] TesteStatusInput input)
        {
            var data = _TesteStatus.GetAll(true).ProjectTo<TesteStatusOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] TesteStatusInput input)
        {
            var data = _TesteStatus.UpdateStatus(input.Id_Teste_Status);

            return Response(true, "Sucesso", "Status atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] TesteStatusInput input)
        {
            var data = _TesteStatus.Remove(input.Id_Teste_Status);
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
