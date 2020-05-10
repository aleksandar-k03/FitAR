using FitAR.Sockets.Dashboard.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace FitAR.Sockets
{
  public class DashboardSocketHandler : WebSocketHandler
  {
    public static DashboardSocketHandler Current = null;
    public DashboardSocketHandler(ConnectionManager webSocketConnectionManager) : base(webSocketConnectionManager) { }

    public override void OnConstructor()
    {
      base.OnConstructor();
      Current = this;
    }

    public override string CreateId(HttpContext context)
      => Guid.NewGuid().ToString();

    public override async Task OnConnected(string id, WebSocket socket)
    {
      await base.OnConnected(id, socket);

      Console.WriteLine($"Imamo konekciju ${id}");
      var socketId = WebSocketConnectionManager.GetId(socket);
      await SendToAll(new DashboardModel() { RequireReload = true });
    }

    public override async Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
    {
      var socketId = WebSocketConnectionManager.GetId(socket);
      var message = $"{socketId} said: {Encoding.UTF8.GetString(buffer, 0, result.Count)}";

      await SendMessageToAllAsync(message);
    }
  }
}
