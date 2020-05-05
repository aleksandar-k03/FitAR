using System;
using FitAR.Sockets;
using FitAR.Sockets.Dashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace FitAR.Web.API
{
  [Produces("application/json")]
  public abstract class ARApiController : ControllerBase
  {
    protected DashboardSocketHandler Socket = null;

    public ARApiController() { }

    [ActivatorUtilitiesConstructor]
    public ARApiController(DashboardSocketHandler socket) { }


    public void Notify(DashboardModel.FunctionTypes function, string text, bool requireRefresh = false)
      => this.Socket?.SendToAll(new DashboardModel()
      {
        Function = function,
        Text = text,
        RequireReload = requireRefresh
      });

  }
}
