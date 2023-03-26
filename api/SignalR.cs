using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace api
{
    public class SignalR : Hub
    {
        public SignalR()
        {
        }

        public async Task Send(string nick, string message)
        {
            await Clients.All.SendAsync("Send", nick, message);
        }

        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "GRC000000001");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "GRC000000001");
            await base.OnDisconnectedAsync(exception);
        }

        public Task SendMessageToGroup(string user, string message)
        {
            return Clients.Group("GRC000000001").SendAsync("ReceiveMessage", user, message);
        }

 

    }
}
