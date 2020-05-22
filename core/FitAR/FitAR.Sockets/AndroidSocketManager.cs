using Direct;
using Direct.Fitardb.Models;
using FitAR.Database;
using FitAR.Sockets.Android;
using FitAR.Sockets.Dashboard.Models;
using FitAR.Sockets.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace FitAR.Sockets
{
  public class AndroidSocketManager : WebSocketHandler
  {
    public static AndroidSocketManager Current = null;

    public AndroidSocketManager(ConnectionManager webSocketConnectionManager) : base(webSocketConnectionManager) { }
    public Dictionary<string, AndroidSocket> AndroidSockets { get; set; } = new Dictionary<string, AndroidSocket>();

    public override void OnConstructor()
    {
      Current = this;
    }

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
      await base.OnConnected(id, socket);

      if (this.AndroidSockets.ContainsKey(this.ID(socket)))
      {
        this.AndroidSockets[this.ID(socket)].OnConnect(socket);
        DashboardSocketHandler.Current?.SendToAll(new DashboardModel()
        {
          Function = DashboardModel.FunctionTypes.notifyInverse,
          RequireReload = true,
          Text = $"Korisnik '{this.AndroidSockets[id].client.username}' se ulogovao preko android aplikacije"
        });
        AndroidSocketManager.Current.Send(FitAR.Sockets.Models.AndroidSocketMessage.Construct("text", "green", new FitAR.Sockets.Models.AndroidSocketTextMessage()
        {
          text = $"Korisnik '{this.AndroidSockets[id].client.username}' se ulogovao preko android aplikacije"
        }));

      }
      else
        Console.WriteLine("Ne postoji socket sa id-em:" + this.ID(socket));
      
    }

    public override async Task OnDisconnected(WebSocket socket)
    {
      this.NumberOfConnections--;
      if (this.AndroidSockets.ContainsKey(this.ID(socket)))
      {
        await this.AndroidSockets[this.ID(socket)].OnDisconect();
        DashboardSocketHandler.Current?.SendToAll(new DashboardModel()
        {
          Function = DashboardModel.FunctionTypes.notifyInverse,
          RequireReload = true,
          Text = $"Korisnik '{this.AndroidSockets[this.ID(socket)].client.username}' je prekinuo sesiju preko android aplikacije"
        });
        AndroidSocketManager.Current.Send(FitAR.Sockets.Models.AndroidSocketMessage.Construct("text", "green", new FitAR.Sockets.Models.AndroidSocketTextMessage()
        {
          text = $"Korisnik '{this.AndroidSockets[this.ID(socket)].client.username}' je prekinuo sesiju preko android aplikacije"
        }));
      }
      this.AndroidSockets.Remove(this.ID(socket));
    }

    public void Send(AndroidSocketMessage message, string username)
      => this.Send(message, (from s in this.AndroidSockets where s.Value.client.username.Equals(username) select s.Value).FirstOrDefault());
    public void Send(AndroidSocketMessage message, AndroidSocket socket)
      => this.Send(message, socket.socket);

    public async void Send(AndroidSocketMessage message, WebSocket specificSocket = null)
    {
      if (specificSocket != null)
        await this.SendMessageAsync(this.ID(specificSocket), message.Convert());
      else
        await this.SendMessageToAllAsync(message.Convert());
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

      try
      {
        switch (split[0].ToLower())
        {
          case "ping":
            var pingModel = JsonConvert.DeserializeObject<PingModel>(split[1]);
            androidSocket.OnPing(pingModel);
            break;
        }
      }
      catch(Exception e)
      {
        int a = 0;
      }

    }


    public bool IsOnline(string username)
      => (from s in this.AndroidSockets where s.Value.client.username == username select s).Any();

  }
}
