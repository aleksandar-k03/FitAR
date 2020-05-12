using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitAR.Web.Code
{
  public class ARScopeEntry
  {
    public Action Inline { get; set; }
    public Action<dynamic?> Override { get; set; }
  }
}
