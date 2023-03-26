using api.Domain.Repository.Interface.Templates.Emails;
using api.Domain.Views.Input.Templates.Emails;
using api.Domain.Views.Output.Templates.Emails;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace api.Controllers.Templates.Emails
{
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/TemplateEmail")]
    public class TemplateEmailController : Controller
    {

        private readonly ITemplateEmailRepository _TemplateEmail;

        public TemplateEmailController(ITemplateEmailRepository TemplateEmail)
        {
            _TemplateEmail = TemplateEmail;
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] TemplateEmailInput input)
        {

            if (input.Id_Template_Email == 0) { _TemplateEmail.Create(input); }
            if (input.Id_Template_Email > 0) { _TemplateEmail.Update(input); }

            return Response(true, "Sucesso", "base de dados atualizada com sucesso", null, "success");
        }

        [HttpPost("Update")]
        [EnableCors("CorsPolicy")]
        public IActionResult Update([FromBody] TemplateEmailInput input)
        {
            var data = _TemplateEmail.Update(input);
            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("GetAny")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAny([FromBody] TemplateEmailInput input)
        {
            var data = _TemplateEmail.GetAny((bool)input.Fl_Ativo).ProjectTo<TemplateEmailOutput>();

            return Response(true, "Sucesso", "...", data, "success");
        }


        [HttpPost("GetByTela")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetByTela([FromBody] TemplateEmailInput input)
        {
            var data = _TemplateEmail.GetByTela(input.Id_Tela).ProjectTo<TemplateEmailOutput>().FirstOrDefault();

            return Response(true, "Sucesso", "...", data, "success");
        }


        [HttpPost("UpdateStatus")]
        [EnableCors("CorsPolicy")]
        public IActionResult UpdateStatus([FromBody] TemplateEmailInput input)
        {
            var data = _TemplateEmail.UpdateStatus(input.Id_Template_Email);

            return Response(true, "Sucesso", "Registro atualizado com sucesso", data, "success");
        }

        [HttpPost("Remove")]
        [EnableCors("CorsPolicy")]
        public IActionResult Remove([FromBody] TemplateEmailInput input)
        {
            var data = _TemplateEmail.Remove(input.Id_Template_Email);
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
