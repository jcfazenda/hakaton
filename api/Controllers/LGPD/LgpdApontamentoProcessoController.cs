using api.Domain.Repository.Interface.LGPD;
using api.Domain.Views.Input.LGPD;
using api.Domain.Views.Output.LGPD;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.LGPD
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/LgpdApontamentoProcesso")]
    public class LgpdApontamentoProcessoController : Controller
    {

        private readonly ILgpdApontamentoProcessoRepository _LgpdApontamentoProcesso;

        public LgpdApontamentoProcessoController(ILgpdApontamentoProcessoRepository LgpdApontamentoProcesso)
        {
            _LgpdApontamentoProcesso = LgpdApontamentoProcesso;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] LgpdApontamentoProcessoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Lgpd_Apontamento_Processo > 0) { _LgpdApontamentoProcesso.Update(input); }
            if (input.Id_Lgpd_Apontamento_Processo == 0) { _LgpdApontamentoProcesso.Create(input); }

            return Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
        }

        [HttpPost("Create")]
        [EnableCors("CorsPolicy")]
        public IActionResult Create([FromBody] LgpdApontamentoProcessoInput input)
        {
            var data = _LgpdApontamentoProcesso.Create(input);
            return Response(true, "Sucesso", "Atualização realizada com sucesso", data, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] LgpdApontamentoProcessoInput input)
        {
            var data = _LgpdApontamentoProcesso.Update(input);
            return Response(true, "Sucesso", "Atualização realizada com sucesso", data, "success");
        } 

        [HttpPost("GetByProcesso")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByProcesso([FromBody] LgpdApontamentoProcessoInput input)
        {
            var data = _LgpdApontamentoProcesso.GetByProcesso(input.Id_Processo).ProjectTo<LgpdApontamentoProcessoOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] LgpdApontamentoProcessoInput input)
        {
            var data = _LgpdApontamentoProcesso.Remove(input.Id_Lgpd_Apontamento_Processo);
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
