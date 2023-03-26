using api.Domain.Repository.Interface.Indice;
using api.Domain.Views.Input.Indice;
using api.Domain.Views.Output.Indice;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Indice
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/PerfilAnalise")]
    public class PerfilAnaliseController : Controller
    {

        private readonly IPerfilAnaliseRepository _PerfilAnalise;

        public PerfilAnaliseController(IPerfilAnaliseRepository PerfilAnalise)
        {
            _PerfilAnalise = PerfilAnalise;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] PerfilAnaliseInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Perfil_Analise == 0)
            {
                _PerfilAnalise.Create(input);
                Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
            }

            if (input.Id_Perfil_Analise > 0)
            {
                _PerfilAnalise.Update(input);
                Response(true, "Sucesso", "Registro alterado com sucesso", null, "success");
            }

            return Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] PerfilAnaliseInput input)
        {
            var data = _PerfilAnalise.Update(input);
            return Response(true, "Sucesso", "Atualização realizada com sucesso", data, "success");
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] PerfilAnaliseInput input)
        {
            var data = _PerfilAnalise.GetAll((bool)input.Fl_Ativo).ProjectTo<PerfilAnaliseOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Get")]
        [EnableCors("CorsPolicy")]
        public IActionResult Get([FromBody] PerfilAnaliseInput input)
        {
            var data = _PerfilAnalise.Get((long)input.Id_Perfil_Analise).ProjectTo<PerfilAnaliseOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }


        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] PerfilAnaliseInput input)
        {
            var data = _PerfilAnalise.UpdateStatus(input.Id_Perfil_Analise);

            return Response(true, "Sucesso", "Status atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] PerfilAnaliseInput input)
        {
            var data = _PerfilAnalise.Remove(input.Id_Perfil_Analise);
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
