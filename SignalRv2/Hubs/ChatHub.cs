using Microsoft.AspNetCore.SignalR;

namespace SignalRv2.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message, DateTime sentTime)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message, sentTime);
    }
}