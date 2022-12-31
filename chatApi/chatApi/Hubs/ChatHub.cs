using Microsoft.AspNetCore.SignalR;

namespace chatApi.Hubs;

public class ChatHub : Hub
{
    public async Task MessageYubor(string message)
    {
       await Clients.All.SendAsync("MessageHandler", message);
    }
}