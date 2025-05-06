using ChatModels;
using Microsoft.AspNetCore.SignalR;
using SignalRv2.Repos;

namespace SignalRv2.Hubs;

public class ChatHub(ChatRepo chatRepo) : Hub
{
    public async Task SendMessage(Chat chat)
    {
        await chatRepo.SaveChatAsync(chat);
        await Clients.All.SendAsync("ReceiveMessage", chat);
    }
}