using Direct.Fitardb.Models;
using Direct.Helpers;
using FitAR.Sockets;
using FitAR.Sockets.Dashboard.Models;
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

  }
}
