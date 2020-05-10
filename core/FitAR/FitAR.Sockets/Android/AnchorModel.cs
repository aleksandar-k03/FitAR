using System;
using System.Collections.Generic;
using System.Text;

namespace FitAR.Sockets.Android
{
  public class AnchorModel
  {
    public string sessionid { get; set; }
    public string username { get; set; }
    public double lat { get; set; }
    public double lng { get; set; }
    public string profileImg { get; set; }
    public string noteText { get; set; }
  }
}
