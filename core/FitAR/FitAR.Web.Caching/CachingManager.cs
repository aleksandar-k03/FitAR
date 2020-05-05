using System;
using System.Collections.Generic;

namespace FitAR.Web.Caching
{
  public static class CachingManager
  {
    public static List<string> LoggedInDashboard { get; set; } = new List<string>();
    public static List<CachingDatabaseSchema> DatabaseSchemas { get; private set; }
    public static List<CachingArticles> IRCArticles { get; set; }
    public static List<CachingApiController> ApiControllers { get; set; }


    public static async void Init()
    {
      DatabaseSchemas = await CachingDatabaseManager.Load();
      IRCArticles = await CachingArticlesManager.Load(1);
      ApiControllers = CachingApi.Get();
    }

  }
}
