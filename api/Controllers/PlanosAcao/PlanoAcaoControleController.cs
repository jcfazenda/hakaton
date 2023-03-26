using api.Domain.Repository.Interface.PlanosAcao;
using api.Domain.Views.Input.PlanosAcao;
using api.Domain.Views.Output.PlanosAcao;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace api.Controllers.PlanosAcao
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/PlanoAcaoControle")]
    public class PlanoAcaoControleController : Controller
    {

        private readonly IPlanoAcaoControleRepository _PlanoAcaoControle;

        public PlanoAcaoControleController(IPlanoAcaoControleRepository PlanoAcaoControle)
        {
            _PlanoAcaoControle = PlanoAcaoControle;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] PlanoAcaoControleInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var Exist = _PlanoAcaoControle.GetByPlanoAcaoControle((long)input.Id_Plano_Acao,
                                                                  (long)input.Id_Controle).ProjectTo<PlanoAcaoControleOutput>().FirstOrDefault();

            if (Exist != null) { _PlanoAcaoControle.Remove(Exist.Id_Plano_Acao_Controle); }
            if (Exist == null) { _PlanoAcaoControle.Create(input); }

            return Response(true, "Sucesso", "Operação realizada com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] PlanoAcaoControleInput input)
        {
            var data = _PlanoAcaoControle.Update(input);
            return Response(true, "Sucesso", "Atualização realizada com sucesso", data, "success");
        }

        [HttpPost("GetByPlanoAcao")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByPlanoAcao([FromBody] PlanoAcaoControleInput input)
        {
            var data = _PlanoAcaoControle.GetByPlanoAcao((long)input.Id_Plano_Acao).ProjectTo<PlanoAcaoControleOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] PlanoAcaoControleInput input)
        {
            var data = _PlanoAcaoControle.GetAll((bool)input.Fl_Ativo).ProjectTo<PlanoAcaoControleOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] PlanoAcaoControleInput input)
        {
            var data = _PlanoAcaoControle.UpdateStatus(input.Id_Plano_Acao_Controle);

            return Response(true, "Sucesso", "Status atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] PlanoAcaoControleInput input)
        {
            var data = _PlanoAcaoControle.Remove((long)input.Id_Plano_Acao_Controle);
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
