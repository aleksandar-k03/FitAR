using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FitAR.Sockets
{
  public class WebSocketManagerMiddleware
  {
    private readonly RequestDelegate _next;
    private WebSocketHandler _webSocketHandler { get; set; }

    public WebSocketManagerMiddleware(RequestDelegate next, WebSocketHandler webSocketHandler)
    {
      _next = next;
      _webSocketHandler = webSocketHandler;
    }

    public async Task Invoke(HttpContext context)
    {
      string id = "";
      try
      {
        if (!context.WebSockets.IsWebSocketRequest)
          return;

        id = _webSocketHandler.CreateId(context);
        if (string.IsNullOrEmpty(id))
          return;

        var socket = await context.WebSockets.AcceptWebSocketAsync();
        await _webSocketHandler.OnConnected(id, socket);

        await Receive(socket, async (result, buffer) =>
        {
          if (result.MessageType == WebSocketMessageType.Text)
          {
            await _webSocketHandler.ReceiveAsync(socket, result, buffer);
            return;
          }

          else if (result.MessageType == WebSocketMessageType.Close)
          {
            await _webSocketHandler.OnDisconnected(socket);
            return;
          }

        });
      }
      catch (Exception e)
      {
        if (!string.IsNullOrEmpty(id))
          await _webSocketHandler.ForceDisconnect(id);

        return;
      }
    }

    private async Task Receive(WebSocket socket, Action<WebSocketReceiveResult, byte[]> handleMessage)
    {
      var buffer = new byte[1024 * 4];

      while (socket.State == WebSocketState.Open)
      {
        var result = await socket.ReceiveAsync(buffer: new ArraySegment<byte>(buffer),
                                                cancellationToken: CancellationToken.None);

        handleMessage(result, buffer);
      }
    }
  }
}
