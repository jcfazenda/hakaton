using api.Domain.Repository.Interface.Empresas;
using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Empresas;
using api.Domain.Views.Input.Risco;
using api.Domain.Views.Output.Risco;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Risco
{

    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/Riscos")]
    public class RiscosController : Controller
    {

        private readonly IRiscosRepository _riscos;
        private readonly IEmpresaRiscoRepository _Empresarisco;
        private readonly IRiscoAvaliacaoRepository _RiscoAvaliacao;

        public RiscosController(IRiscosRepository riscos, IRiscoAvaliacaoRepository RiscoAvaliacao, IEmpresaRiscoRepository Empresarisco)
        {
            _riscos = riscos;
            _RiscoAvaliacao = RiscoAvaliacao;
            _Empresarisco = Empresarisco;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] RiscosInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Risco > 0) { _riscos.Update(input); }

            if (input.Id_Risco == 0) { 

                input.Id_Risco    = _riscos.Create(input);

                EmpresaRiscoInput createE = new EmpresaRiscoInput();
                createE.Id_Empresa = input.Id_Empresa;
                createE.Id_Risco     = input.Id_Risco; 
                _Empresarisco.Create(createE); 
            } 

            return Response(true, "Sucesso", "base de dados atualizada com sucesso", input, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] RiscosInput input)
        {
            var data = _riscos.Update(input);
            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] RiscosInput input)
        {
            var data = _riscos.GetAll((bool)input.Fl_Ativo).ProjectTo<RiscoOutput>();

            return Response(true, "Sucesso", "...", data, "success");
        }

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] RiscosInput input)
        {
            var data = _riscos.UpdateStatus(input.Id_Risco);

            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] RiscosInput input)
        {
            _riscos.Remove(input.Id_Risco);
            return Response(true, "Sucesso", "Registro removido com sucesso", input, "success");
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
