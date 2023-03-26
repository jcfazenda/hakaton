
using api.Domain.Models.Usuario;
using api.Domain.Repository.Interface.Message;
using api.Domain.Repository.Interface.Usuario;
using api.Domain.Views.Input.Message;
using api.Domain.Views.Input.Usuario;
using api.Domain.Views.Output.Message;
using api.Domain.Views.Output.Usuario;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Vonage.Request;
using Vonage;
using Vonage.Voice;
using Vonage.Voice.Nccos;
using Vonage.Voice.Nccos.Endpoints;

using System.Net;

namespace api.Controllers.Message
{
    [Produces("application/json")]
    [Route("{tenant_database}/api/[controller]")]
    public class BotController : Controller
    {
        private readonly IBotRepository _Bot;

        public BotController(IBotRepository Bot)
        {
            _Bot = Bot;
        }

        [HttpPost("Sms")]
        [EnableCors("CorsPolicy")]
        public IActionResult Sms([FromBody] BotInput input)
        {
            try
            {
                var key = _Bot.GetById((long)input.Id_Bot).ProjectTo<BotOutput>().FirstOrDefault().Key_Vonage_Voice;
                var EVENT_URL = new[] { Environment.GetEnvironmentVariable("EVENT_URL") ?? "https://example.com" };

                var credentials = Credentials.FromApiKeyAndSecret(
                    "5cbdb2e1",
                    "HQBtnYTzwC74KMni"
                );
                var VonageClient = new VonageClient(credentials);

                var response = VonageClient.SmsClient.SendAnSms(new Vonage.Messaging.SendSmsRequest()
                {
                    To = input.Phone,
                    From = "Vonage APIs",
                    Text = "teste de sms Hakaton"
                });

                return Response(true, "Sucesso", "Operação realizada com sucesso", response, "success");

            }
            catch (Exception ex)
            {
                return Response(false, "error", ex.Message, null, "erroe"); ;
            }

        }

        [HttpPost("Call")]
        [EnableCors("CorsPolicy")]
        public IActionResult Call([FromBody] BotInput input)
        {
            try
            { 
                var key       = _Bot.GetById((long)input.Id_Bot).ProjectTo<BotOutput>().FirstOrDefault().Key_Vonage_Voice;
                var EVENT_URL = new[] { Environment.GetEnvironmentVariable("EVENT_URL") ?? "https://example.com" };


                var creds = Credentials.FromAppIdAndPrivateKeyPath("fc38d344-3e40-41be-bfe9-863316d3de3c",
                                                                   Environment.CurrentDirectory + "/voice.key");
                var client = new VonageClient(creds);


                var toEndpoint   = new PhoneEndpoint() { Number = input.Phone };
                var fromEndpoint = new PhoneEndpoint() { Number = "5521992408317" };
                var extraText    = "";

                var talkAction = new TalkAction() { Text = "Olá estou falando com Julio?." + extraText };
                var ncco       = new Ncco(talkAction);

                var command  = new CallCommand() { To = new Endpoint[] { toEndpoint }, From = fromEndpoint, Ncco = ncco, EventUrl = EVENT_URL };
                var response = client.VoiceClient.CreateCall(command);

                return Response(true, "Sucesso", "Operação realizada com sucesso", response, "success");

            }
            catch (Exception ex)
            {
                return Response(false, "error", ex.Message , null, "erroe"); ;
            }

        }

        [HttpPost("GetAny")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAny([FromBody] BotInput input)
        {
            var data = _Bot.GetAny((bool)input.Fl_Ativo).ProjectTo<BotOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("Save")]
        [EnableCors("CorsPolicy")]
        public IActionResult Save([FromBody] BotInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            if (input.Id_Bot == 0) { _Bot.Create(input); }
            if (input.Id_Bot  > 0) { _Bot.Update(input); }

            return Response(true, "Sucesso", "Registro criado com sucesso", null, "success");
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
