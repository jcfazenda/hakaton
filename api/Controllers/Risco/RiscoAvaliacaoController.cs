using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using api.Domain.Views.Output.Risco;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace api.Controllers.Risco
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/RiscoAvaliacao")]
    public class RiscoAvaliacaoController : Controller
    {

        private readonly IRiscoAvaliacaoRepository _RiscoAvaliacao;
        private readonly IRiscoAvaliacaoStatusRepository _RiscoAvaliacaoStatus;
        private readonly IRiscosRepository _risco;

        public RiscoAvaliacaoController(IRiscoAvaliacaoRepository RiscoAvaliacao,
                                        IRiscosRepository risco, IRiscoAvaliacaoStatusRepository RiscoAvaliacaoStatus)
        {
            _RiscoAvaliacao = RiscoAvaliacao;
            _risco = risco;
            _RiscoAvaliacaoStatus = RiscoAvaliacaoStatus;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] RiscoAvaliacaoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }


            if (input.Id_Risco_Avaliacao  == 0 ) {

                input.Id_Risco_Avaliacao_Status = _RiscoAvaliacaoStatus.GetByDescricao("Avaliando").ProjectTo<RiscoAvaliacaoStatusOutput>().FirstOrDefault().Id_Risco_Avaliacao_Status;
                input.Id_Risco_Avaliacao        = _RiscoAvaliacao.Create(input); 
            
            }

            if (input.Id_Risco_Avaliacao  > 0 ) { _RiscoAvaliacao.Update(input); }

            var data = _RiscoAvaliacao.GetByAvaliacao((long)input.Id_Risco_Avaliacao).ProjectTo<RiscoAvaliacaoOutput>();


            return Response(true, "Sucesso", "Registro associado com sucesso", data, "success");
        }

        [HttpPost("GetByAvaliacao")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByAvaliacao([FromBody] RiscoAvaliacaoInput input)
        {
            var data = _RiscoAvaliacao.GetByAvaliacao((long)input.Id_Risco_Avaliacao).ProjectTo<RiscoAvaliacaoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("GetByRisco")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByRisco([FromBody] RiscoAvaliacaoInput input)
        {
            var data = _RiscoAvaliacao.GetByRisco((long)input.Id_Risco).ProjectTo<RiscoAvaliacaoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("UpdateStatusWorkFlow")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatusWorkFlow([FromBody] RiscoAvaliacaoInput input)
        {
            _RiscoAvaliacao.UpdateStatusWorkFlow(input.Id_Risco, input.Id_Risco_Avaliacao_Status);
            var risco = _risco.GetByRisco(input.Id_Risco);

            return Response(true, "Sucesso", "Registro atualizado com sucesso", risco, "success");
        } 

        [HttpPost("GetByStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByStatus([FromBody] RiscoAvaliacaoInput input)
        {
            var data = _RiscoAvaliacao.GetByStatus((long)input.Id_Risco_Avaliacao_Status).ProjectTo<RiscoAvaliacaoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }


        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] RiscoAvaliacaoInput input)
        {
            var data = _RiscoAvaliacao.Remove(input.Id_Risco_Avaliacao);
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
