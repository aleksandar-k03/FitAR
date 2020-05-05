using System;
using System.Collections.Generic;
using System.Text;

namespace FitAR.Web.API.Models
{

  public class RegistrationInputModel
  {
    public string username { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string password { get; set; }
  }

  public class RegistrationModel : ModelBase
  {

  }
}
