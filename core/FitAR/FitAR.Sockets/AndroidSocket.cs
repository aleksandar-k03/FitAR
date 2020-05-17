using Direct;
using Direct.Fitardb.Models;
using FitAR.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace FitAR.Sockets.Android
{
  public class AndroidSocket
  {
    private ClientSessionDM session = null;
    public ClientDM client = null;
    private PingModel _lastPingModel = null;
    private AndroidSocketManager manager = null;
    public DateTime created = DateTime.Now;
    public WebSocket socket = null;

    public AndroidSocket(AndroidSocketManager manager, ClientSessionDM session)
    {
      this.manager = manager;
      this.session = session;
      this.client = ARDirect.Instance.Query<ClientDM>().Where("clientid={0}", session.clientid).LoadSingle();
    }

    public void OnConnect(WebSocket socket)
    {
      this.socket = socket;
    }

    public void OnPing(PingModel model)
    {
      this._lastPingModel = model;
    }

    public async Task OnDisconect()
    {
      this.session.duration = (DateTime.Now - this.created).TotalSeconds;
      this.session.lat = this._lastPingModel?.lat;
      this.session.lng = this._lastPingModel?.lng;
      await this.session.UpdateAsync();
    }

  }
}
