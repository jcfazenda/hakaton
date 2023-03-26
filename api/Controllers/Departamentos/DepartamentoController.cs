using api.Domain.Repository.Interface.Departamentos;
using api.Domain.Views.Input.Departamentos;
using api.Domain.Views.Output.Departamentos;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Departamentos
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/Departamento")]
    public class DepartamentoController : Controller
    {

        private readonly IDepartamentoRepository _Departamento; 

        public DepartamentoController(IDepartamentoRepository Departamento )
        {
            _Departamento = Departamento; 
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] DepartamentoInput input)
        {
            if (input == null) { return Response(true, "Alerta", "não foi possível executar esta tarefa.", null, "warn"); }

            if (input.Id_Departamento > 0) { _Departamento.Update(input); }
            if (input.Id_Departamento == 0) { _Departamento.Create(input); }  

            return Response(true, "Sucesso", "base de dados atuaalizada com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] DepartamentoInput input)
        {
            var data = _Departamento.Update(input);
            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] DepartamentoInput input)
        {
            var data = _Departamento.GetAll((bool)input.Fl_Ativo).ProjectTo<DepartamentoOutput>();

            return Response(true, "Sucesso", "..", data, "success");
        }


        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] DepartamentoInput input)
        {
            var data = _Departamento.UpdateStatus(input.Id_Departamento);

            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] DepartamentoInput input)
        { 
            _Departamento.Remove(input.Id_Departamento);

            return Response(true, "Sucesso", "Registro removido com sucesso", null, "success");
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
