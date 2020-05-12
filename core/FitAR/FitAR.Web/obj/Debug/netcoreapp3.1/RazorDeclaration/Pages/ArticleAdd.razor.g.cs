#pragma checksum "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\ArticleAdd.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "593ba548cb022a9729ed8d487b9d92a49602c33a"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace FitAR.Web.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\git\FitAr\core\FitAR\FitAR.Web\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\git\FitAr\core\FitAR\FitAR.Web\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\git\FitAr\core\FitAR\FitAR.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\git\FitAr\core\FitAR\FitAR.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\git\FitAr\core\FitAR\FitAR.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\git\FitAr\core\FitAR\FitAR.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\git\FitAr\core\FitAR\FitAR.Web\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\git\FitAr\core\FitAR\FitAR.Web\_Imports.razor"
using FitAR.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\git\FitAr\core\FitAR\FitAR.Web\_Imports.razor"
using FitAR.Web.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\git\FitAr\core\FitAR\FitAR.Web\_Imports.razor"
using FitAR.Web.Shared.MenuSections;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\git\FitAr\core\FitAR\FitAR.Web\_Imports.razor"
using FitAR.Web.Caching;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\git\FitAr\core\FitAR\FitAR.Web\_Imports.razor"
using Direct.Fitardb.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\git\FitAr\core\FitAR\FitAR.Web\_Imports.razor"
using FitAR.Database;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\git\FitAr\core\FitAR\FitAR.Web\_Imports.razor"
using Direct;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\git\FitAr\core\FitAR\FitAR.Web\_Imports.razor"
using System.Net.WebSockets;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\git\FitAr\core\FitAR\FitAR.Web\_Imports.razor"
using System.Threading;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\git\FitAr\core\FitAR\FitAR.Web\_Imports.razor"
using FitAR.Sockets.Dashboard.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\git\FitAr\core\FitAR\FitAR.Web\_Imports.razor"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "D:\git\FitAr\core\FitAR\FitAR.Web\_Imports.razor"
using System.Runtime.Remoting;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/addArticle/{fallbackId}")]
    public partial class ArticleAdd : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 58 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\ArticleAdd.razor"

	[Parameter] public string fallbackId { get; set; }
	public bool HasError = false;
	public bool Done = false;
	public CachingArticles ArticleCache { get; set; } = null;
	public ArticleDM ArticleModel { get; set; } = null;
	public string Naslov { get; set; } = string.Empty;

	protected override void OnParametersSet()
	{
		int fallbackID;
		if (!int.TryParse(this.fallbackId, out fallbackID))
		{
			this.HasError = true;
			return;
		}

		this.ArticleCache = (from a in CachingManager.IRCArticles where a.ID == fallbackID select a).FirstOrDefault();
		if (this.ArticleCache == null)
		{
			this.HasError = true;
			return;
		}

		this.ArticleModel = ARDirect.Instance.Query<ArticleDM>().Where("[id]={0}", fallbackID).LoadSingle();
		if (this.ArticleModel == null)
		{
			this.HasError = true;
			return;
		}
	}

	protected override Task OnInitializedAsync()
	{
		return base.OnInitializedAsync();
	}

	protected async void OnSubmit()
	{
		string content = await JSRuntime.InvokeAsync<string>("CKCustomEditor.getData");
		ArticleDM newElem = new ArticleDM()
		{
			fallbackid = this.ArticleModel.ID.Value,
			typeid = this.ArticleModel.typeid,
			title = this.Naslov,
			html = content,
			updated = DateTime.Now,
			created = DateTime.Now
		};
		newElem.Insert();

		ArticleCache.Columns.Add(new CachingArticles()
		{
			ID = newElem.ID.Value,
			Title = Naslov
		});

		this.StateHasChanged();
		NavigationManager.NavigateTo("/article/" + newElem.ID.Value);

		this.Done = true;
	}



#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
