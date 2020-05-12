using Direct;
using Direct.Fitardb.Models;
using FitAR.Database;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitAR.Web
{
  public class ARContext
  {
    private readonly IHttpContextAccessor _httpContextAccessor;
    private ClientDM _client = null;
    public HttpContext Context => _httpContextAccessor.HttpContext;

    public ClientDM Client
    {
      get
      {
        if (!this.Context.Request.Cookies.ContainsKey("wauth"))
          return null;

        int cid = 0;
        if (!int.TryParse(this.Context.Request.Cookies["wauth"], out cid))
          return null;

        if (!Caching.CachingManager.LoggedInDashboard.Contains(this.Context.Request.Cookies["wauth"].ToString()))
        {
          if (this._client != null)
            this._client = null;
          return null;
        }

        if (this._client != null)
          return this._client;

        this._client = ARDirect.Instance.Query<ClientDM>().Where("[id]={0}", cid).LoadSingle();
        return this._client;
      }
      set
      {
        this._client = value;
      }
    }

    public string WebsiteUrl
      => $"{Context.Request.Scheme}://{Context.Request.Host}{Context.Request.PathBase}";

    public ARContext(IHttpContextAccessor httpContextAccessor)
    {
      _httpContextAccessor = httpContextAccessor;
    }

    public bool IsLoggedIn => this.Client != null;
    public bool IsAdmin => this.Client != null && this.Client.isAdmin;

  }
}
