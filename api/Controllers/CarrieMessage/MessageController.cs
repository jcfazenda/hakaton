using api.Domain.Views.Input.CarrieMessage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace api.Controllers.HubSignalR
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/Message")]
    public class MessageController : Controller
    {
        private readonly IHubContext<SignalR> _hubContext;

        public MessageController(IHubContext<SignalR> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost("Send")]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult> Send([FromBody] MessageInput input)
        {
            await _hubContext.Clients.All.SendAsync("SendMessage", input); /* Envia mensagem */
            return Response(true, "Sucesso", "sending success", null, "success");

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
