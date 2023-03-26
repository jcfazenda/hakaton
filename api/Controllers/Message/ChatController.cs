
using api.Domain.Models.Message;
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

namespace api.Controllers.Message
{
    [Produces("application/json")]
    [Route("{tenant_database}/api/[controller]")]
    public class ChatController : Controller
    {
        private readonly IChatRepository _Chat;
        private readonly IBotRepository _Bot; 

        public ChatController(IChatRepository Chat, IBotRepository Bot)
        {
            _Chat = Chat;
            _Bot  = Bot;
        }

        [HttpPost("GetMessage")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetMessage([FromBody] ChatInput input)
        {
            var data = _Chat.GetMessage((long)input.Id_Bot, (long)input.Id_Usuario).ProjectTo<ChatOutput>();

            return Response(true, "Sucesso", "Operação realizada com sucesso", data, "success");
        }

        [HttpPost("GetAny")]
        [EnableCors("CorsPolicy")]
        public IActionResult GetAny([FromBody] ChatInput input)
        {

            return Response(true, "Sucesso", "Operação realizada com sucesso (GetAny).", input.Mensagem, "success");
        }

        [HttpPost("SendMessageAsync")]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> SendMessageAsync([FromBody] ChatInput input)
        {
            if (input == null) { return Response(false, "Erro", "algo inesperado aconteceu.", null, "error"); }

            try
            {
                input.Fl_Bot = false;
                _Chat.Create(input); /* Salva Mensagem do Usuario */
                var apiKey = _Bot.GetApi((long)input.Id_Bot).ProjectTo<BotOutput>().FirstOrDefault().Api;

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);

                    var response = await client.PostAsync("https://api.openai.com/v1/completions",
                               new StringContent("{\"model\": \"text-davinci-003\", \"prompt\": \"" + input.Mensagem + "\", \"temperature\": 1, \"max_tokens\": 1024}",
                                   Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    { 

                        string responseString = await response.Content.ReadAsStringAsync();
                        var data = JsonSerializer.Deserialize<Generics.Resposta>(responseString);

                        List<string> _items = new List<string>();

                        foreach (var item in data.choices.ToArray())
                        {
                            _items.Add(item.text.Replace("\n", ""));
                        }

                        
                        input.Fl_Bot   = true;
                        input.Mensagem = _items[0].ToString();

                        _Chat.Create(input); /* Salva Resposta do ChatGPT */
                        var request = _Chat.GetMessage((long)input.Id_Bot, (long)input.Id_Usuario).ProjectTo<ChatOutput>();

                        return Response(true, "ChatGPT", "",  request, "success");

                    }

                }

                return Response(true, "Sucesso", "Registro criado com sucesso", null, "success");

            }
            catch (System.Exception ex)
            {
                return Response(false, "Erro", ex.Message, null, "error");
            }

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
