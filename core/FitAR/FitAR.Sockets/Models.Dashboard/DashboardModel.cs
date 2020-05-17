using System;
using System.Collections.Generic;
using System.Text;

namespace FitAR.Sockets.Dashboard.Models
{
  public class DashboardModel : SocketModelBase
  {
    public enum FunctionTypes
    {
      notifyInverse,
      notifyInfo,
      notifySuccess,
      notifyWarning,
      notifyDanger
    }

    public string Text { get; set; }
    public FunctionTypes Function { get; set; }
    public bool RequireReload { get; set; }

  }
}
