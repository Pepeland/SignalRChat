using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        private static Dictionary<string, string> users = new Dictionary<string, string>();
        public void Login(string userId)
        {
            if(!users.ContainsKey(userId))
                users.Add(userId, Context.ConnectionId);
            else
                users[userId] = Context.ConnectionId;
        }
        public async Task SendMessage(string user, string toUser, string message)
        {
            if(users.ContainsKey(toUser))
                await Clients.Client(users[toUser]).SendAsync("ReceiveMessage", user, message);
        }
    }
}
