using System;
using System.Collections.Generic;
using System.Text;

namespace FitAR.Web.API.Models
{

  public class LoginInputModel
  {
    public string username { get; set; }
    public string password { get; set; }
  }

  public class LoginModel : ModelBase
  {
    public int clientID { get; set; }
    public string session { get; set; }

    public string username { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string profilePic { get; set; }

  }
}
