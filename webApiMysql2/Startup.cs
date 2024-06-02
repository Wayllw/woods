/* define um middleware (WebSocketManagerMiddleware) para tratar as requisições
WebSocket e um manipulador (WebSocketHandler) para lidar com as conexões WebSocket
estabelecidas */
using System.Net.WebSockets;
using System.Text;
namespace WebApplicationSock
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWebSocketManager();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseWebSockets();
            app.MapWebSocketManager("/ws", new WebSocketHandler());
        }
    }
    public static class WebSocketExtensions
    {
        public static IServiceCollection AddWebSocketManager(this IServiceCollection
       services)
        {
            services.AddTransient<WebSocketHandler>();
            return services;
        }
        public static IApplicationBuilder MapWebSocketManager(this
       IApplicationBuilder app, PathString path, WebSocketHandler handler)
        {
            return app.Map(path, (x) =>
           x.UseMiddleware<WebSocketManagerMiddleware>(handler));
        }
    }
    public class WebSocketManagerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly WebSocketHandler _webSocketHandler;
        public WebSocketManagerMiddleware(RequestDelegate next, WebSocketHandler
       webSocketHandler)
        {
            _next = next;
            _webSocketHandler = webSocketHandler;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.WebSockets.IsWebSocketRequest)
                return;
            var socket = await context.WebSockets.AcceptWebSocketAsync();
            await _webSocketHandler.HandleAsync(context, socket);
        }
    }
    public class WebSocketHandler
    {
        private static readonly List<WebSocket> _sockets = new List<WebSocket>();
        public async Task HandleAsync(HttpContext context, WebSocket socket)
        {
            _sockets.Add(socket); // Add the new connection to the list
            var buffer = new byte[1024];
            WebSocketReceiveResult result;

            try
            {
                do
                {
                    result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    // Handle received message (e.g., process it and send response)
                    var responseMessage = $"Received: {message}";
                    var responseBytes = Encoding.UTF8.GetBytes(responseMessage);
                    await socket.SendAsync(new ArraySegment<byte>(responseBytes), result.MessageType, result.EndOfMessage, CancellationToken.None);
                    if (message.StartsWith("delete_post"))
                    {
                        // Extract post ID from the message
                        var postId = int.Parse(message.Split(':')[1]);
                        await NotifyClientsOfPostDeletion(postId);
                    }
                }
                while (!result.CloseStatus.HasValue);

                await socket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
            }
            catch (WebSocketException ex)
            {
                Console.WriteLine("WebSocket error: " + ex.Message);
            }
            finally
            {
                _sockets.Remove(socket); // Ensure socket is removed when closed
            }
        }

        public static async Task SendToAllAsync(string message)
        {
            var socketsToRemove = new List<WebSocket>();
            foreach (var socket in _sockets)
            {
                if (socket.State == WebSocketState.Open)
                {
                    await socket.SendAsync(Encoding.UTF8.GetBytes(message), WebSocketMessageType.Text, true, CancellationToken.None);
                }
                else
                {
                    socketsToRemove.Add(socket); // Collect closed sockets to remove
                }
            }
            // Remove closed sockets from the list
            foreach (var socket in socketsToRemove)
            {
                _sockets.Remove(socket);
            }
        }

        private async Task NotifyClientsOfPostDeletion(int postId)
        {
            // Construct a message indicating the deleted post
            var message = $"delete_post:{postId}";

            // Send the message to all connected WebSocket clients
            await SendToAllAsync(message);
        }
    }
}
