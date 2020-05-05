#pragma checksum "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Article.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d84d44cdad9da08163295a135d858baa003706f8"
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/article/{articleId}")]
    public partial class Article : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 95 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Article.razor"

	[Parameter] public string articleId { get; set; }
	public bool HasError = false;
	public bool ConfirmDelete = false;
	public ArticleDM ArticleModel { get; set; } = null;

	protected override void OnParametersSet()
	{
		int articleID;
		if (!int.TryParse(this.articleId, out articleID))
		{
			this.HasError = true;
			return;
		}

		this.ArticleModel = ARDirect.Instance.Query<ArticleDM>().Where("[id]={0}", articleID).LoadSingle();
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

	protected async void OnSave()
	{
		this.ArticleModel.html = await JSRuntime.InvokeAsync<string>("CKCustomEditor.getData");
		await this.ArticleModel.UpdateAsync();

		// update title
		var fallbackArticle = (from a in CachingManager.IRCArticles where a.ID == this.ArticleModel.fallbackid.Value select a).FirstOrDefault();
		for (var i = 0; i < fallbackArticle.Columns.Count; i++)
			if (fallbackArticle.Columns[i].ID == this.ArticleModel.ID.Value)
			{
				fallbackArticle.Columns[i].Title = this.ArticleModel.title;
				break;
			}
		this.StateHasChanged();
	}

	/// <summary>
	///  DELETE
	/// </summary>

	protected void OpenConfirmDelete()
	{
		this.ConfirmDelete = true;
		this.StateHasChanged();
	}

	protected void CloseConfirmDelete()
	{
		this.ConfirmDelete = false;
		this.StateHasChanged();
	}

	protected void DeleteThisArticle()
	{
		// izbrisi iz cache
		var fallbackArticle = (from a in CachingManager.IRCArticles where a.ID == this.ArticleModel.fallbackid.Value select a).FirstOrDefault();
		for (var i = 0; i < fallbackArticle.Columns.Count; i++)
			if (fallbackArticle.Columns[i].ID == this.ArticleModel.ID.Value)
			{
				fallbackArticle.Columns.RemoveAt(i);
				break;
			}

		this.ArticleModel.Delete();
		this.StateHasChanged();
		NavigationManager.NavigateTo("/");
	}



#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ARContext Context { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
#pragma warning restore 1591
