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

    public static string PrintDate(this DateTime date)
    {
      if (DateTime.Now.Month == date.Month)
      {
        if (DateTime.Now.Day == date.Day)
        {
          // danasnji dan
          return string.Format("{0}:{1}", Decimal(date.Hour), Decimal(date.Minute));
        }
      }

      return string.Format("{0}. {1} ({2}:{3})", date.Day, Month(date.Month), Decimal(date.Hour), Decimal(date.Minute));
    }
    public static string PrintDate(this DateTime? date)
    {
      if (!date.HasValue)
        return string.Empty;
      return date.Value.PrintDate();
    }

    public static string Month(int Val)
    {
      switch (Val)
      {
        default:
        case 1: return "Јануар";
        case 2: return "Фебруар";
        case 3: return "Март";
        case 4: return "Април";
        case 5: return "Мај";
        case 6: return "Јун";
        case 7: return "Јул";
        case 8: return "Август";
        case 9: return "Септембар";
        case 10: return "Октобар";
        case 11: return "Новембар";
        case 12: return "Децембар";
      }
    }
    public static string Decimal(int Val)
      => (Val < 10 ? "0" : "") + Val.ToString();


  }
}
