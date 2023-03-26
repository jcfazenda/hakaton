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
    [Route("{tenant_database}/api/PlanoAcaoApontamentoPlano")]
    public class PlanoAcaoApontamentoPlanoController : Controller
    {

        private readonly IPlanoAcaoApontamentoPlanoRepository _PlanoAcaoApontamentoPlano;

        public PlanoAcaoApontamentoPlanoController(IPlanoAcaoApontamentoPlanoRepository PlanoAcaoApontamentoPlano)
        {
            _PlanoAcaoApontamentoPlano = PlanoAcaoApontamentoPlano;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] PlanoAcaoApontamentoPlanoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            var Exist = _PlanoAcaoApontamentoPlano.GetByPlanoAcaoApontamento((long)input.Id_Plano_Acao, 
                                                                             (long)input.Id_Apontamento).ProjectTo<PlanoAcaoApontamentoPlanoOutput>().FirstOrDefault();

            if (Exist != null) { _PlanoAcaoApontamentoPlano.Remove(Exist.Id_Plano_Acao_Apontamento_Plano); }
            if (Exist == null) { _PlanoAcaoApontamentoPlano.Create(input); } 

            return Response(true, "Sucesso", "Operação realizada com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] PlanoAcaoApontamentoPlanoInput input)
        {
            var data = _PlanoAcaoApontamentoPlano.Update(input);
            return Response(true, "Sucesso", "Atualização realizada com sucesso", data, "success");
        }

        [HttpPost("GetByPlanoAcao")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByPlanoAcao([FromBody] PlanoAcaoApontamentoPlanoInput input)
        {
            var data = _PlanoAcaoApontamentoPlano.GetByPlanoAcao((long)input.Id_Plano_Acao).ProjectTo<PlanoAcaoApontamentoPlanoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] PlanoAcaoApontamentoPlanoInput input)
        {
            var data = _PlanoAcaoApontamentoPlano.GetAll((bool)input.Fl_Ativo).ProjectTo<PlanoAcaoApontamentoPlanoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] PlanoAcaoApontamentoPlanoInput input)
        {
            var data = _PlanoAcaoApontamentoPlano.UpdateStatus(input.Id_Plano_Acao_Apontamento_Plano);

            return Response(true, "Sucesso", "Status atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] PlanoAcaoApontamentoPlanoInput input)
        {
            var data = _PlanoAcaoApontamentoPlano.Remove((long)input.Id_Plano_Acao_Apontamento_Plano);
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
