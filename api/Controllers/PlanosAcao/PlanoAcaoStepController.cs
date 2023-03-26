using api.Domain.Repository.Interface.PlanosAcao;
using api.Domain.Views.Input.PlanosAcao;
using api.Domain.Views.Output.PlanosAcao;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.PlanosAcao
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/PlanoAcaoStep")]
    public class PlanoAcaoStepController : Controller
    {
        private readonly IPlanoAcaoStepRepository _PlanoAcaoStep;

        public PlanoAcaoStepController(IPlanoAcaoStepRepository PlanoAcaoStep)
        {
            _PlanoAcaoStep = PlanoAcaoStep;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] PlanoAcaoStepInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Plano_Acao_Step == 0)
            {
                _PlanoAcaoStep.Create(input);
                Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
            }

            if (input.Id_Plano_Acao_Step > 0)
            {
                _PlanoAcaoStep.Update(input);
                Response(true, "Sucesso", "Registro alterado com sucesso", null, "success");
            }

            return Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] PlanoAcaoStepInput input)
        {
            var data = _PlanoAcaoStep.Update(input);
            return Response(true, "Sucesso", "Atualização realizada com sucesso", data, "success");
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] PlanoAcaoStepInput input)
        {
            var data = _PlanoAcaoStep.GetAll((bool)input.Fl_Ativo).ProjectTo<PlanoAcaoStepOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }
         
        [HttpPost("GetByPlanoAcao")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByPlanoAcao([FromBody] PlanoAcaoStepInput input)
        {
            var data = _PlanoAcaoStep.GetByPlanoAcao((long)input.Id_Plano_Acao).ProjectTo<PlanoAcaoStepOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] PlanoAcaoStepInput input)
        {
            var data = _PlanoAcaoStep.UpdateStatus(input.Id_Plano_Acao_Step);

            return Response(true, "Sucesso", "Status atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] PlanoAcaoStepInput input)
        {
            var data = _PlanoAcaoStep.Remove(input.Id_Plano_Acao_Step);
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
