
using Direct;
using Direct.Fitardb.Models;
using FitAR.Database;
using FitAR.Sockets;
using FitAR.Web.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
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
    [Descriptor(Name = "Логин Контролер",
      Input = typeof(AnchorModel),
      Output = typeof(AnchorResponseModel),
      Description = @"")]
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

      AnchorDM anchor = new AnchorDM()
      {
        clientid = session.clientid,
        clientsessionid = session.clientSessionID,
        sessionid = input.sessionid,
        noteText = input.noteText,
        lat = input.lat,
        lng = input.lng
      };
      await anchor.InsertAsync();

      return response;
    }

  }
}
