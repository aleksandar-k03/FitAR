using System;
using System.Collections.Generic;
using System.Text;

namespace FitAR.Web.API
{
  public class Descriptor : Attribute
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public Type Input { get; set; } = null;
    public Type Output { get; set; } = null;
  }
}
