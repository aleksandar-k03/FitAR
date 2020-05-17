using Direct.Fitardb.Models;
using Direct.Helpers;
using FitAR.Sockets;
using FitAR.Sockets.Dashboard.Models;
using FitAR.Sockets.Models;
using FitAR.Web.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitAR.Web.API
{
  [Route("api/test")]
  [Descriptor(Name = "TestController", Description = @"Користи се за тестирање апи-ја")]
  public class TestController : ARApiController
  {
    private DashboardSocketHandler socket = null;

    public TestController() { }

    [ActivatorUtilitiesConstructor]
    public TestController(DashboardSocketHandler dashboardSocketHandler)
    {
      this.socket = dashboardSocketHandler;
    }

    [HttpGet]
    [Descriptor(Name = "Акција", Output = typeof(ModelBase), Description = "Враћа текст \"све је ок\"")]
    public ModelBase Index(string t)
    {
      var result = new ModelBase();
      socket.SendToAll(new DashboardModel()
      {
        Text = t,
        Function = DashboardModel.FunctionTypes.notifyDanger,
        RequireReload = false
      });
      result.GenerateError("Sve ok");
      return result;
    }

    [HttpGet]
    [Route("createUser")]
    public ActionResult CreateUser(string username, string password)
    {
      ClientDM client = new ClientDM()
      {
        username = username,
        password = DirectPassword.Hash(password),
        firstName = "firstname",
        lastName = "lastname"
      };
      client.InsertAsync();
      client.WaitIDExplicit(10);
      return this.Content("Userid: " + client.ID.Value);
    }

    [HttpGet]
    [Route("socket_android/{text}")]
    [Descriptor(Name = "Акција", Output = typeof(ModelBase), Description = "Враћа текст \"све је ок\"")]
    public ActionResult SocketAndroid(string text)
    {
      if(AndroidSocketManager.Current == null)
        return this.Content("AndroidSocketManager.Current je null");

      AndroidSocketManager.Current.Send(AndroidSocketMessage.Construct("text", "green", new AndroidSocketTextMessage()
      {
         text = text
      }));

      return this.Content("OK");
    }


    [HttpGet]
    [Route("socket_web/{text}")]
    [Descriptor(Name = "Акција", Output = typeof(ModelBase), Description = "Враћа текст \"све је ок\"")]
    public ActionResult SocketWeb(string text)
    {
      if (DashboardSocketHandler.Current == null)
        return this.Content("AndroidSocketManager.Current je null");

      DashboardSocketHandler.Current.SendToAll(new DashboardModel()
      {
        Function = DashboardModel.FunctionTypes.notifyInverse,
        RequireReload = false,
        Text = text
      });

      return this.Content("OK");
    }

  }
}
