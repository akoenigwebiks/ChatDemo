using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ChatDemo.Middlewares
{
    public record ChatMessage(string user, string message);
    public class HubMessageInterceptor<THub> where THub : Hub
    {
        private readonly IHubContext<THub> _hubContext;

        public HubMessageInterceptor(IHubContext<THub> hubContext)
        {
            _hubContext = hubContext;
        }


        // Ensure this method matches how you're calling it in ChatHub
        public async Task SendMessageAsync(string methodName, string user, string message)
        {
            // Log the message
            Debug.WriteLine($"Sending message from {user}: {message}");

            // Optionally modify the message
            var modifiedMessage = $"[Modified] {user}: {message}";

            // Send the message using SignalR
            await _hubContext.Clients.All.SendAsync(methodName, new ChatMessage(user,message));
        }
    }
}
