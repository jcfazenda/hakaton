using api.Domain.Repository.Interface.Testes;
using api.Domain.Views.Input.Testes;
using api.Domain.Views.Output.Testes;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Testes
{

    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/Teste")]
    public class TesteController : Controller
    {

        private readonly ITesteRepository _Teste;

        public TesteController(ITesteRepository Teste)
        {
            _Teste = Teste;
        }

        [HttpPost("UpdateStatusWorkflow")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatusWorkflow([FromBody] TesteInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _Teste.UpdateStatusWorkflow(input);
            return Response(true, "Sucesso", "Registro alterado com sucesso", input, "success"); 
        }


        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] TesteInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Teste == 0)
            {
                input.Id_Teste = _Teste.Create(input);
                Response(true, "Sucesso", "Registro criado com sucesso", input, "success");

            } else if (input.Id_Teste > 0) {
                _Teste.Update(input);
                Response(true, "Sucesso", "Registro alterado com sucesso", input, "success");
            }

            return Response(true, "Sucesso", "Registro criado com sucesso", input, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] TesteInput input)
        {
            var data = _Teste.Update(input);
            return Response(true, "Sucesso", "Atualização realizada com sucesso", data, "success");
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] TesteInput input)
        {
            var data = _Teste.GetAll((bool)input.Fl_Ativo).ProjectTo<TesteOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] TesteInput input)
        {
            var data = _Teste.UpdateStatus(input.Id_Teste);

            return Response(true, "Sucesso", "Status atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] TesteInput input)
        {
            var data = _Teste.Remove(input.Id_Teste);
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
