using Direct;
using Direct.Fitardb.Models;
using FitAR.Database;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FitAR.Web.Caching
{

  public static class CachingArticlesManager
  {
    public static async Task<List<CachingArticles>> Load(int typeid)
    {
      List<CachingArticles> result = new List<CachingArticles>();
      var data = await ARDirect.Instance.Query<ArticleDM>().Where("typeid={0}", typeid).LoadAsync();
      foreach(var articledm in data)
      {
        if (articledm.fallbackid.HasValue == false)
        {
          result.Add(new CachingArticles() { ID= articledm.articleid, Title = articledm.title, Index = articledm.defaultIndex }); 
          continue;
        }

        var fallbackArticle = (from a in result where a.ID == articledm.fallbackid.Value select a).FirstOrDefault();
        if(fallbackArticle == null)
        {
          Console.WriteLine("could not find this id in fallback");
          continue;
        }

        fallbackArticle.Columns.Add(new CachingArticles() { ID = articledm.ID.Value, Title = articledm.title, Index = articledm.defaultIndex });
      }

      foreach (var article in result)
        article.Columns = article.Columns.OrderBy(x => x.Index).ToList();

      return result;
    }

  }


  public class CachingArticles
  {
    public int ID { get; set; } = -1;
    public string Title { get; set; } = string.Empty;
    public bool IsThisMetaArticle => this.Columns.Count > 0;
    public int Index { get; set; } = 1;
    public List<CachingArticles> Columns { get; set; } = new List<CachingArticles>();
  }
}
