#pragma checksum "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\ArticleAdd.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "593ba548cb022a9729ed8d487b9d92a49602c33a"
// <auto-generated/>
#pragma warning disable 1591
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
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "main-body");
            __builder.AddMarkupContent(2, "\r\n\t");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "page-wrapper");
            __builder.AddMarkupContent(5, "\r\n\t\t\r\n\t\t");
            __builder.AddMarkupContent(6, "<div class=\"page-header\">\r\n\t\t\t<div class=\"row align-items-end\">\r\n\t\t\t\t<div class=\"col-lg-8\">\r\n\t\t\t\t\t<div class=\"page-header-title\">\r\n\t\t\t\t\t\t<div class=\"d-inline\">\r\n\t\t\t\t\t\t\t<h4>Додавање</h4>\r\n\t\t\t\t\t\t</div>\r\n\t\t\t\t\t</div>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\r\n");
#nullable restore
#line 19 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\ArticleAdd.razor"
         if (!HasError)
		{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(7, "\t\t\t");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "page-body");
            __builder.AddMarkupContent(10, "\r\n\t\t\t\t");
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "row");
            __builder.AddMarkupContent(13, "\r\n\t\t\t\t\t");
            __builder.OpenElement(14, "div");
            __builder.AddAttribute(15, "class", "col-sm-12");
            __builder.AddMarkupContent(16, "\r\n\r\n\t\t\t\t\t\t");
            __builder.OpenElement(17, "div");
            __builder.AddAttribute(18, "class", "card");
            __builder.AddMarkupContent(19, "\r\n\t\t\t\t\t\t\t");
            __builder.OpenElement(20, "div");
            __builder.AddAttribute(21, "class", "card-block");
            __builder.AddMarkupContent(22, "\r\n\t\t\t\t\t\t\t\t");
            __builder.OpenElement(23, "div");
            __builder.AddAttribute(24, "class", "form-group row");
            __builder.AddMarkupContent(25, "\r\n\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(26, "div");
            __builder.AddAttribute(27, "class", "col-sm-12");
            __builder.AddMarkupContent(28, "\r\n\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(29, "input");
            __builder.AddAttribute(30, "type", "text");
            __builder.AddAttribute(31, "placeholder", "Naslov");
            __builder.AddAttribute(32, "class", "form-control");
            __builder.AddAttribute(33, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 29 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\ArticleAdd.razor"
                                                                                                            Naslov

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(34, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => Naslov = __value, Naslov));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\r\n\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(36, "\r\n\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\r\n\t\t\t\t\t\t\t\t<div id=\"content\" class=\"ck\"></div>\r\n\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(38, "\r\n\t\t\t\t\t\t\t");
            __builder.OpenElement(39, "div");
            __builder.AddAttribute(40, "class", "card-block");
            __builder.AddMarkupContent(41, "\r\n");
#nullable restore
#line 35 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\ArticleAdd.razor"
                                 if (this.Done == false)
								{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(42, "\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(43, "button");
            __builder.AddAttribute(44, "class", "btn btn-primary");
            __builder.AddAttribute(45, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 37 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\ArticleAdd.razor"
                                                                              OnSubmit

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(46, "Sacuvaj");
            __builder.CloseElement();
            __builder.AddMarkupContent(47, "\r\n\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(48, "button");
            __builder.AddAttribute(49, "class", "btn btn-primary");
            __builder.AddAttribute(50, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 38 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\ArticleAdd.razor"
                                                                              OnSubmit

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(51, "Izbrisi");
            __builder.CloseElement();
            __builder.AddMarkupContent(52, "\r\n");
#nullable restore
#line 39 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\ArticleAdd.razor"
								}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(53, "\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(54, "\r\n\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(55, "\r\n\r\n\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(56, "\r\n\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(57, "\r\n\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(58, "\r\n");
#nullable restore
#line 46 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\ArticleAdd.razor"
		}
		else
		{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(59, "\t\t\t");
            __builder.AddMarkupContent(60, "<strong>Greska!</strong>\r\n");
#nullable restore
#line 50 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\ArticleAdd.razor"
		}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(61, "\r\n\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(62, "\r\n");
            __builder.CloseElement();
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
