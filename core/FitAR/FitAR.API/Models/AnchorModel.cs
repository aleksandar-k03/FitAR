using System;
using System.Collections.Generic;
using System.Text;

namespace FitAR.Web.API.Models
{
  public class AnchorModel
  {
    public string sessionid { get; set; }
    public string anchorid { get; set; }
    public double lat { get; set; }
    public double lng { get; set; }
    public string noteText { get; set; }
  }

  public class AnchorResponseModel : ModelBase
  {
  }

  public class AnchorResponse
  {
    public string id { get; set; }
    public string username { get; set; }
    public string text { get; set; }
  }

}
