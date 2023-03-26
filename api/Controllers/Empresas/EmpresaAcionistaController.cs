using api.Domain.Repository.Interface.Empresas;
using api.Domain.Views.Input.Empresas;
using api.Domain.Views.Output.Empresas;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace api.Controllers.Empresas
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/EmpresaAcionista")]
    public class EmpresaAcionistaController : Controller
    {

        private readonly IEmpresaAcionistaRepository _EmpresaAcionista;
        private readonly IAcionistaRepository _acionista;
        private readonly IEmpresaAcionistaAcaoSocietariaRepository _EmpresaAcionistaAcaoSocietaria;

        public EmpresaAcionistaController(IEmpresaAcionistaRepository EmpresaAcionista,
                                          IAcionistaRepository acionista,
                                          IEmpresaAcionistaAcaoSocietariaRepository EmpresaAcionistaAcaoSocietaria)
        {
            _EmpresaAcionista = EmpresaAcionista;
            _acionista = acionista;
            _EmpresaAcionistaAcaoSocietaria = EmpresaAcionistaAcaoSocietaria;
        }

        [HttpPost("GetAcionistas")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAcionistas([FromBody] AcionistaInput input)
        {
            var data = _acionista.GetAll(true).ProjectTo<AcionistaOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }
        [HttpPost("SaveAcionista")]
        [EnableCors("CorsPolicy")]
        public IActionResult SaveAcionista([FromBody] AcionistaInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

 
            if (input.Id_Acionista > 0) { _acionista.Update(input); }
            if (input.Id_Acionista == 0) { _acionista.Create(input); }


            return Response(true, "Sucesso", "Operação realizada com sucesso", null, "success");
        }
         
        /* ----------------------------------------------------------------------------------- */

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] EmpresaAcionistaInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _EmpresaAcionista.Create(input);

            return Response(true, "Sucesso", "Registro associado com sucesso", null, "success");
        }

        [HttpPost("UpdatePercentual")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdatePercentual([FromBody] EmpresaAcionistaInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            _EmpresaAcionista.UpdatePercentual(input);

            _EmpresaAcionistaAcaoSocietaria.RemoveByAcionista(input.Id_Acionista);

            foreach (var item in input.ListAcaoSocietaria)
            {
                EmpresaAcionistaAcaoSocietariaInput create = new EmpresaAcionistaAcaoSocietariaInput();
                create.Id_Acionista                     = input.Id_Acionista;
                create.Id_Empresa                       = input.Id_Empresa;
                create.Id_Empresa_Acao_Societaria_Item  = (long)item;

                _EmpresaAcionistaAcaoSocietaria.Create(create);

            }

            return Response(true, "Sucesso", "Registro associado com sucesso", null, "success");
        }


        [HttpPost("GetByEmpresa")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByEmpresa([FromBody] EmpresaAcionistaInput input)
        {
            var data = _EmpresaAcionista.GetByEmpresa((long)input.Id_Empresa).ProjectTo<EmpresaAcionistaOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] EmpresaAcionistaInput input)
        {
            var data = _EmpresaAcionista.Remove(input.Id);
            return Response(true, "Sucesso", "Registro removido com sucesso", data, "success");

        }

        [HttpPost("RemoveAcionista")]
        [EnableCors("CorsPolicy")]
        public IActionResult RemoveAcionista([FromBody] EmpresaAcionistaInput input)
        {
            /* SE EXISTE */
            var Existe = _EmpresaAcionista.GetByAcionista(input.Id_Acionista).ProjectTo<AcionistaOutput>().ToList();

            if (Existe.Count > 0) { return Response(true, "Error", "Acionista está associado a alguma empresa", null, "error"); }

            if (Existe.Count == 0)
            {
                var data = _acionista.Remove(input.Id_Acionista);
                return Response(true, "Sucesso", "Registro removido com sucesso", data, "success");
            }

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
