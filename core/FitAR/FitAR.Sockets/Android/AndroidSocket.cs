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
    private ClientDM client = null;
    private PingModel _lastPingModel = null;
    private AndroidSocketManager manager = null;
    public DateTime created = DateTime.Now;
    public WebSocket socket = null;

    public AndroidSocket(AndroidSocketManager manager, ClientSessionDM session)
    {
      this.manager = manager;
      this.session = session;
      this.client = ARDirect.Instance.Query<ClientDM>().Where("clientid", session.clientid).LoadSingle();
    }

    public async Task OnPing(PingModel model)
    {
      if (this._lastPingModel == null)
      {
        // inicijalno slanje anchora klijentu

        var models = ARDirect.Instance.Load<AnchorModel>(
          @"SELECT anch.sessionid, anch.noteText, anch.lat, anch.lng, client.username, client.profilePic
              FROM core.anchor AS anch
            LEFT OUTER JOIN auth.client as client ON anch.clientid = client.clientid;");
        List<AnchorModel> modelsToSend = new List<AnchorModel>();
        foreach(var dbm in models)
          if (LongtitudeHelper.DistanceTo(model.lat, model.lng, dbm.lat, dbm.lng) <= 15)
            modelsToSend.Add(dbm);

        string json = JsonConvert.SerializeObject(modelsToSend);
        await this.manager.SendMessageAsync(this.socket, string.Format("update#{0}", json));
      }
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
