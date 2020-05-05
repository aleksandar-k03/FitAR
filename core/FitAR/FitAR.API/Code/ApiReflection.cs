using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FitAR.Web.API
{

  public static class ApiReflection
  {

    public static IEnumerable<ARApiController> GetAllTypes()
    {
      IEnumerable<ARApiController> exporters = typeof(ARApiController)
        .Assembly.GetTypes()
        .Where(t => t.IsSubclassOf(typeof(ARApiController)) && !t.IsAbstract )
        .Where(t => t.GetCustomAttributes(typeof(Descriptor), false).Length > 0)
        .Select(t => (ARApiController)Activator.CreateInstance(t));
      return exporters;
    }

    public static IEnumerable<MethodInfo> GetMethod(ARApiController t)
    {
      return t.GetType().GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public)
                .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                .Where(m => m.GetCustomAttributes(typeof(Descriptor), false).Length > 0);
    }

    public static TAtr GetAttriibute<TAtr>(ARApiController obj)
      where TAtr : Descriptor
    {
      var dnAttribute = obj.GetType().GetCustomAttributes(
          typeof(TAtr), true
      ).FirstOrDefault() as TAtr;
      return dnAttribute;
    }

    private static TValue GetAttributeValue<TAttribute, TValue>(
        this Type type,
        Func<TAttribute, TValue> valueSelector)
        where TAttribute : Attribute
    {
      var att = type.GetCustomAttributes(
          typeof(TAttribute), true
      ).FirstOrDefault() as TAttribute;
      if (att != null)
      {
        return valueSelector(att);
      }
      return default(TValue);
    }
  }
}
