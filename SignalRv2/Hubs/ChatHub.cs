using ChatModels;
using Microsoft.AspNetCore.SignalR;

namespace SignalRv2.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(Chat chat)
    {
        await Clients.All.SendAsync("ReceiveMessage", chat);
    }
}