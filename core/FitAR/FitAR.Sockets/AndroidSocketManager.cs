using Direct;
using Direct.Fitardb.Models;
using FitAR.Database;
using FitAR.Sockets.Android;
using FitAR.Sockets.Dashboard.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace FitAR.Sockets
{
  public class AndroidSocketManager : WebSocketHandler
  {
    public AndroidSocketManager(ConnectionManager webSocketConnectionManager) : base(webSocketConnectionManager) { }
    protected Dictionary<string, AndroidSocket> AndroidSockets { get; set; } = new Dictionary<string, AndroidSocket>();

    public override string CreateId(HttpContext context)
    {
      if (!context.Request.Query.ContainsKey("id"))
        return string.Empty;


      string id = context.Request.Query["id"].ToString();
      ClientSessionDM session = ARDirect.Instance.Query<ClientSessionDM>().Where("clientSessionGuid={0}", id).LoadSingle();
      if (session == null)
        return string.Empty;

      if (this.AndroidSockets.ContainsKey(id))
        return string.Empty;

      AndroidSocket socket = new AndroidSocket(this, session);
      this.AndroidSockets.Add(id, socket);

      return id;
    }

    public override async Task OnConnected(string id, WebSocket socket)
    {
      this.AndroidSockets[this.ID(socket)].socket = socket;
      await base.OnConnected(id, socket);
    }

    public override async Task OnDisconnected(WebSocket socket)
    {
      await this.AndroidSockets[this.ID(socket)].OnDisconect();
      this.AndroidSockets.Remove(this.ID(socket));
    }

    public override async Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
    {
      var socketId = WebSocketConnectionManager.GetId(socket);
      var androidSocket = this.AndroidSockets[socketId];
      if (androidSocket == null)
        return;

      string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
      string[] split = message.Split('#');
      if (split.Length != 2)
        return;

      switch(split[0].ToLower())
      {
        case "ping":
          PingModel model = JsonConvert.DeserializeObject<PingModel>(split[1]);
          await androidSocket.OnPing(model);
          break;
      }

    }
  }
}
