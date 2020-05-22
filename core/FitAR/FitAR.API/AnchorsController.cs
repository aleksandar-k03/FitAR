
using Direct;
using Direct.Fitardb.Models;
using FitAR.Database;
using FitAR.Sockets;
using FitAR.Sockets.Dashboard.Models;
using FitAR.Sockets.Models;
using FitAR.Web.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;

namespace FitAR.Web.API
{
  [Route("api/anchor")]
  [Descriptor(Name = "AnchorController", Description = "Користи се за чување ар локацију у базу")]
  public class AnchorController : ARApiController
  {

    public AnchorController() : base() { }
    [ActivatorUtilitiesConstructor] public AnchorController(DashboardSocketHandler socket) : base(socket) { }


    [HttpPost]
    [Descriptor(Name = "Акција",
      Input = typeof(AnchorModel),
      Output = typeof(AnchorResponseModel),
      Description = @"Чувају се подаци о креираном поруци у базу")]
    public async Task<AnchorResponseModel> Index(AnchorModel input)
    {
      var db = ARDirect.Instance;
      var response = new AnchorResponseModel();
      ClientSessionDM session = await db.Query<ClientSessionDM>().Where("clientSessionGuid={0}", input.sessionid).LoadSingleAsync();
      if(session == null)
      {
        response.GenerateError("Sesija ne postoji");
        return response;
      }

      ClientDM client = await db.Query<ClientDM>().Where("clientid={0}", session.clientid).LoadSingleAsync();

      AnchorDM anchor = new AnchorDM()
      {
        clientid = session.clientid,
        clientsessionid = session.clientSessionID,
        sessionid = input.anchorid,
        noteText = input.noteText,
        lat = input.lat,
        lng = input.lng
      };
      await anchor.InsertAsync();

      AndroidSocketManager.Current.Send(FitAR.Sockets.Models.AndroidSocketMessage.Construct("text", "green", new FitAR.Sockets.Models.AndroidSocketTextMessage()
      {
        text = $"Korisnik '{client.username}' je postavio poruku '{input.noteText}'."
      }));
      DashboardSocketHandler.Current?.SendToAll(new DashboardModel()
      {
        Function = DashboardModel.FunctionTypes.notifyInverse,
        RequireReload = false,
        Text = $"Korisnik '{client.username}' je postavio poruku '{input.noteText}'."
      }); ;

      return response;
    }

    [HttpGet]
    [HttpPost]
    [Route("getall")]
    [Descriptor(Name = "Враћање свих порука из базе",
      Output = typeof(AnchorResponse),
      Description = @"Враћа листу порука у простору за потребе андроид апликације")]
    public async Task<List<AnchorResponse>> GetAll()
    {
      var response = new List<AnchorResponse>();
      await foreach (var anchor in ARDirect.Instance.Query<AnchorDM>().Where("[id]>0").LoadEnumerableAsync())
        response.Add(new AnchorResponse
        {
          id = anchor.sessionid,
          username = await ARDirect.Instance.LoadStringAsync(@"SELECT username FROM auth.client WHERE clientid={0}", anchor.clientid),
          text = anchor.noteText
        });
      return response;
    }

  }
}
