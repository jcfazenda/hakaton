using api.Domain.Repository.Interface.Processos;
using api.Domain.Views.Input.Processos;
using api.Domain.Views.Output.Processos;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Processos
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/Processo")]
    public class ProcessoController : Controller
    {

        private readonly IProcessoRepository _Processo;
        private readonly IProcessoEmpresaRepository _ProcessoEmpresa;
        private readonly IProcessoLinhaNegocioRepository _ProcessoLinhaNegocio;


        public ProcessoController(IProcessoRepository Processo, IProcessoLinhaNegocioRepository ProcessoLinhaNegocio, IProcessoEmpresaRepository ProcessoEmpresa)
        {
            _Processo = Processo;
            _ProcessoLinhaNegocio = ProcessoLinhaNegocio;
            _ProcessoEmpresa = ProcessoEmpresa;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] ProcessoInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Processo > 0)  { _Processo.Update(input); }

            if (input.Id_Processo == 0) { 

                input.Id_Processo = _Processo.Create(input);

                /* Processo Empresa */
                ProcessoEmpresaInput CreateprocessoEmpresa = new ProcessoEmpresaInput();
                CreateprocessoEmpresa.Id_Processo = input.Id_Processo;
                CreateprocessoEmpresa.Id_Empresa  = input.Id_Empresa;

                _ProcessoEmpresa.Create(CreateprocessoEmpresa);

            }

            _ProcessoLinhaNegocio.RemoveByProcesso(input.Id_Processo);
            foreach (var item in input.ListProcessoLinhaNarogocio)
            {
                ProcessoLinhaNegocioInput _input = new ProcessoLinhaNegocioInput();
                _input.Id_Processo      = input.Id_Processo;
                _input.Id_Linha_Negocio = item;

                _ProcessoLinhaNegocio.Create(_input);
            }


            return Response(true, "Sucesso", "base de dados atuaalizada com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] ProcessoInput input)
        {
            var data = _Processo.Update(input);
            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] ProcessoInput input)
        {
            var data = _Processo.GetAll((bool)input.Fl_Ativo).ProjectTo<ProcessoOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }

        [HttpPost("GetByProcessoByNivel")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByProcessoByNivel([FromBody] ProcessoInput input)
        {
            var data = _Processo.GetByProcessoByNivel((long)input.Id_Processo_Nivel).ProjectTo<ProcessoOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }

        [HttpPost("GetByProcessoByMinorNivel")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByProcessoByMinorNivel([FromBody] ProcessoInput input)
        {
            var data = _Processo.GetByProcessoByMinorNivel((long)input.Id_Processo_Nivel).ProjectTo<ProcessoOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }


        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] ProcessoInput input)
        {
            var data = _Processo.UpdateStatus(input.Id_Processo);

            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] ProcessoInput input)
        {
            var data = _Processo.Remove(input.Id_Processo);
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
