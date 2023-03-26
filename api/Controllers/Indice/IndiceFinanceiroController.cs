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
    [Route("{tenant_database}/api/IndiceFinanceiro")]
    public class IndiceFinanceiroController : Controller
    {

        private readonly IIndiceFinanceiroRepository _IndiceFinanceiro;

        public IndiceFinanceiroController(IIndiceFinanceiroRepository IndiceFinanceiro)
        {
            _IndiceFinanceiro = IndiceFinanceiro;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] IndiceFinanceiroInput input)
        { 
            try
            {                 
                if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

                if (input.Id_Indice_Financeiro == 0) { _IndiceFinanceiro.Create(input); } 
                if (input.Id_Indice_Financeiro > 0) { _IndiceFinanceiro.Update(input);  }

                return Response(true, "Sucesso", "operação realizada com sucesso", null, "success");
            }
            catch (System.Exception ex)
            { 
                return Response(false, "error",   ex.ToString() , null, "error");
            }
                       
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] IndiceFinanceiroInput input)
        {
            var data = _IndiceFinanceiro.Update(input);
            return Response(true, "Sucesso", "Atualização realizada com sucesso", data, "success");
        }

        [HttpPost("GetAll")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAll([FromBody] IndiceFinanceiroInput input)
        {
            var data = _IndiceFinanceiro.GetAll((bool)input.Fl_Ativo).ProjectTo<IndiceFinanceiroOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] IndiceFinanceiroInput input)
        {
            var data = _IndiceFinanceiro.UpdateStatus(input.Id_Indice_Financeiro);

            return Response(true, "Sucesso", "Status atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] IndiceFinanceiroInput input)
        {
            var data = _IndiceFinanceiro.Remove(input.Id_Indice_Financeiro);
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
