using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitAR.Web
{
  public static class Utils
  {

    public static bool IsDebug()
    {
#if DEBUG
      return true;
#else
      return false;
#endif
    }


  }
}
