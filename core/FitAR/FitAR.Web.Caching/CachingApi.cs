using FitAR.Web.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;

namespace FitAR.Web.Caching
{
  public static class CachingApi
  {
    public static List<CachingApiController> Get()
    {
      var result = new List<CachingApiController>();
      foreach (var controller in ApiReflection.GetAllTypes())
      {
        var elem = new CachingApiController();
        var descriptor = ApiReflection.GetAttriibute<Descriptor>(controller);
        var crouteAttr = controller.GetType().GetCustomAttribute<RouteAttribute>();
        elem.ID = descriptor.Name.Split(' ')[0] + Guid.NewGuid().ToString().Split('-')[0];
        elem.Name = descriptor.Name;
        elem.Description = descriptor.Description;
        elem.OriginalName = controller.GetType().Name;


        var methods = ApiReflection.GetMethod(controller);
        foreach(var method in methods)
        {
          var melem = new CachingApiMethod();
          var mdescriptor = method.GetCustomAttribute<Descriptor>();
          var routeAttr = method.GetCustomAttribute<RouteAttribute>();
          melem.Name = mdescriptor.Name;
          melem.Description = mdescriptor.Description;
          melem.Route = crouteAttr.Template + "/" + routeAttr?.Template;

          if (mdescriptor.Input != null)
            melem.Input = JsonConvert.SerializeObject(Activator.CreateInstance(mdescriptor.Input));
          if(mdescriptor.Output != null)
            melem.Output = JsonConvert.SerializeObject(Activator.CreateInstance(mdescriptor.Output));

          elem.Methods.Add(melem);
        }

        result.Add(elem);
      }

      return result;
    }
  }


  public class CachingApiController
  {
    public string ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string OriginalName { get; set; }
    public string Route { get; set; }
    public List<CachingApiMethod> Methods { get; set; } = new List<CachingApiMethod>();
  }

  public class CachingApiMethod
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public string Route { get; set; }
    public string Input { get; set; }
    public string Output { get; set; }
  }
}
