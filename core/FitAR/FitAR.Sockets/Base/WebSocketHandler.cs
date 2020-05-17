using FitAR.Sockets.Android;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FitAR.Sockets
{
  public abstract class WebSocketHandler
  {
    protected ConnectionManager WebSocketConnectionManager { get; set; }

    public int NumberOfConnections = 0;
    
    public WebSocketHandler(ConnectionManager webSocketConnectionManager)
    {
      WebSocketConnectionManager = webSocketConnectionManager;
      this.OnConstructor();
    }

    public virtual void OnConstructor() { }
    public virtual string CreateId(HttpContext context)
    {
      return string.Empty;
    }

    public string ID(WebSocket socket) => WebSocketConnectionManager.GetId(socket);

    public virtual async Task OnConnected(string id, WebSocket socket)
    {
      this.NumberOfConnections++;
      WebSocketConnectionManager.AddSocket(id, socket);
    }

    public async Task ForceDisconnect(string id)
    {
      if (this.WebSocketConnectionManager.GetSocket(id) != null)
        await this.OnDisconnected(this.WebSocketConnectionManager.GetSocket(id));
    }

    public virtual async Task OnDisconnected(WebSocket socket)
    {
      this.NumberOfConnections--;
      string id = WebSocketConnectionManager.GetId(socket);
      Console.WriteLine($"Diskonekcija ${id}");
      await WebSocketConnectionManager.RemoveSocket(id);
    }

    public async Task SendMessageAsync(WebSocket socket, string message)
    {
      if (socket.State != WebSocketState.Open)
        return;

      await socket.SendAsync(buffer: new ArraySegment<byte>(array: Encoding.UTF8.GetBytes(message),
                                                              offset: 0,
                                                              count: message.Length),
                              messageType: WebSocketMessageType.Text,
                              endOfMessage: true,
                              cancellationToken: CancellationToken.None);
    }

    public async Task SendMessageAsync(string socketId, string message)
    {
      await SendMessageAsync(WebSocketConnectionManager.GetSocketById(socketId), message);
    }

    public Task SendToAll(SocketModelBase model)
      => this.SendMessageToAllAsync(model.Convert());

    public async Task SendMessageToAllAsync(string message)
    {
      foreach (var pair in WebSocketConnectionManager.GetAll())
      {
        if (pair.Value.State == WebSocketState.Open)
          await SendMessageAsync(pair.Value, message);
      }
    }

    public abstract Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer);
  }
}
