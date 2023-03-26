using api.Domain.Repository.Interface.Processos;
using api.Domain.Views.Input.Processos;
using api.Domain.Views.Output.Risco;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Risco
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/LinhaNegocio")]
    public class LinhaNegocioController : Controller
    {

        private readonly ILinhaNegocioRepository _LinhaNegocio;

        public LinhaNegocioController(ILinhaNegocioRepository LinhaNegocio)
        {
            _LinhaNegocio = LinhaNegocio;
        }


        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] LinhaNegocioInput input)
        {
            var data = _LinhaNegocio.GetAll((bool)input.Fl_Ativo).ProjectTo<RiscoOutput>();

            return Response(true, "Sucesso", "...", data, "success");
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] LinhaNegocioInput input)
        {
            if (input.Id_Linha_Negocio > 0) { _LinhaNegocio.Update(input); }
            if (input.Id_Linha_Negocio == 0) { input.Id_Linha_Negocio = _LinhaNegocio.Create(input); } 

            return Response(true, "Sucesso", "base de dados atualizada com sucesso", input, "success");
        }

        [HttpPost("SaveItem")]
        [EnableCors("CorsPolicy")]
        public IActionResult SaveItem([FromBody] LinhaNegocioInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            input.Id_Linha_Negocio    = input.Id;
            input.Linha_Negocio_Nome  = input.Nome;

            if (input.Id > 0) { _LinhaNegocio.Update(input); }
            if (input.Id == 0) { _LinhaNegocio.Create(input); }

            return Response(true, "Sucesso", "Registro associado com sucesso", input, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] LinhaNegocioInput input)
        {
            var data = _LinhaNegocio.Update(input);
            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }


        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] LinhaNegocioInput input)
        {
            var data = _LinhaNegocio.UpdateStatus(input.Id_Linha_Negocio);

            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] LinhaNegocioInput input)
        {
            var data = _LinhaNegocio.Remove(input.Id);
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
