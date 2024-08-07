using ChatDemo.Middlewares;
using Microsoft.AspNetCore.SignalR;

namespace ChatDemo.Sockets
{
    public class ChatHub : Hub
    {
        private readonly HubMessageInterceptor<ChatHub> _interceptor;

        public ChatHub(HubMessageInterceptor<ChatHub> interceptor)
        {
            _interceptor = interceptor;
        }

        public async Task SendMessage(string user, string message)
        {
            // Use the interceptor to send the message
            await Clients.All.SendAsync("ReceiveMessage", new ChatMessage(user, message));

            //await _interceptor.SendMessageAsync("ReceiveMessage",user ,message);
        }
    }
}
