#pragma checksum "D:\git\FitAR\core\FitAR\FitAR.Web\Shared\_Header.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3a26b391a6490abbc2fbb9c344ef76fa983920d4"
// <auto-generated/>
#pragma warning disable 1591
namespace FitAR.Web.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\git\FitAR\core\FitAR\FitAR.Web\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\git\FitAR\core\FitAR\FitAR.Web\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\git\FitAR\core\FitAR\FitAR.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\git\FitAR\core\FitAR\FitAR.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\git\FitAR\core\FitAR\FitAR.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\git\FitAR\core\FitAR\FitAR.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\git\FitAR\core\FitAR\FitAR.Web\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\git\FitAR\core\FitAR\FitAR.Web\_Imports.razor"
using FitAR.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\git\FitAR\core\FitAR\FitAR.Web\_Imports.razor"
using FitAR.Web.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\git\FitAR\core\FitAR\FitAR.Web\_Imports.razor"
using FitAR.Web.Shared.MenuSections;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\git\FitAR\core\FitAR\FitAR.Web\_Imports.razor"
using FitAR.Web.Caching;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\git\FitAR\core\FitAR\FitAR.Web\_Imports.razor"
using Direct.Fitardb.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\git\FitAR\core\FitAR\FitAR.Web\_Imports.razor"
using FitAR.Database;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\git\FitAR\core\FitAR\FitAR.Web\_Imports.razor"
using Direct;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\git\FitAR\core\FitAR\FitAR.Web\_Imports.razor"
using System.Net.WebSockets;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\git\FitAR\core\FitAR\FitAR.Web\_Imports.razor"
using System.Threading;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\git\FitAR\core\FitAR\FitAR.Web\_Imports.razor"
using FitAR.Sockets.Dashboard.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\git\FitAR\core\FitAR\FitAR.Web\_Imports.razor"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "D:\git\FitAR\core\FitAR\FitAR.Web\_Imports.razor"
using System.Runtime.Remoting;

#line default
#line hidden
#nullable disable
    public partial class _Header : ARPage
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "nav");
            __builder.AddAttribute(1, "class", "navbar header-navbar pcoded-header");
            __builder.AddMarkupContent(2, "\r\n\t");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "navbar-wrapper");
            __builder.AddMarkupContent(5, "\r\n\r\n\t\t");
            __builder.AddMarkupContent(6, @"<div class=""navbar-logo"">
			<a class=""mobile-menu"" id=""mobile-collapse"" onclick=""javascript:void(0)"">
				<i class=""feather icon-menu""></i>
			</a>
			<a href=""index-1.htm"">
				<img class=""img-fluid"" src=""assets\images\logo.png"" alt=""Theme-Logo"">
			</a>
			<a class=""mobile-options"">
				<i class=""feather icon-more-horizontal""></i>
			</a>
		</div>

		");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "class", "navbar-container container-fluid");
            __builder.AddMarkupContent(9, "\r\n\t\t\t");
            __builder.AddMarkupContent(10, "<ul class=\"nav-left\">\r\n\t\t\t\t<li>\r\n\t\t\t\t\t<a onclick=\"javascript:toggleFullScreen()\">\r\n\t\t\t\t\t\t<i class=\"feather icon-maximize full-screen\"></i>\r\n\t\t\t\t\t</a>\r\n\t\t\t\t</li>\r\n\t\t\t</ul>\r\n\t\t\t");
            __builder.OpenElement(11, "ul");
            __builder.AddAttribute(12, "class", "nav-right");
            __builder.AddMarkupContent(13, "\r\n\t\t\t\t");
            __builder.AddMarkupContent(14, "<li class=\"header-notification\">\r\n\r\n\r\n\r\n\t\t\t\t</li>\r\n\t\t\t\t");
            __builder.OpenElement(15, "li");
            __builder.AddAttribute(16, "class", "user-profile header-notification");
            __builder.AddMarkupContent(17, "\r\n\r\n");
#nullable restore
#line 92 "D:\git\FitAR\core\FitAR\FitAR.Web\Shared\_Header.razor"
                     if (Context.IsLoggedIn)
					{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(18, "\t\t\t\t\t\t");
            __builder.OpenElement(19, "div");
            __builder.AddAttribute(20, "class", "dropdown-primary dropdown");
            __builder.AddMarkupContent(21, "\r\n\t\t\t\t\t\t\t");
            __builder.OpenElement(22, "div");
            __builder.AddAttribute(23, "class", "dropdown-toggle");
            __builder.AddAttribute(24, "data-toggle", "dropdown");
            __builder.AddMarkupContent(25, "\r\n\t\t\t\t\t\t\t\t");
            __builder.OpenElement(26, "img");
            __builder.AddAttribute(27, "src", 
#nullable restore
#line 96 "D:\git\FitAR\core\FitAR\FitAR.Web\Shared\_Header.razor"
                                           Context.Client.profilePic

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(28, "class", "img-radius");
            __builder.AddAttribute(29, "alt", "User-Profile-Image");
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n\t\t\t\t\t\t\t\t");
            __builder.OpenElement(31, "span");
            __builder.AddContent(32, 
#nullable restore
#line 97 "D:\git\FitAR\core\FitAR\FitAR.Web\Shared\_Header.razor"
                                       Context.Client.firstName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(33, " ");
            __builder.AddContent(34, 
#nullable restore
#line 97 "D:\git\FitAR\core\FitAR\FitAR.Web\Shared\_Header.razor"
                                                                 Context.Client.lastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\r\n\t\t\t\t\t\t\t\t<i class=\"feather icon-chevron-down\"></i>\r\n\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(36, "\r\n\t\t\t\t\t\t\t");
            __builder.OpenElement(37, "ul");
            __builder.AddAttribute(38, "class", "show-notification profile-notification dropdown-menu");
            __builder.AddAttribute(39, "data-dropdown-in", "fadeIn");
            __builder.AddAttribute(40, "data-dropdown-out", "fadeOut");
            __builder.AddMarkupContent(41, "\r\n\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(42, "li");
            __builder.AddMarkupContent(43, "\r\n\t\t\t\t\t\t\t\t");
            __builder.OpenElement(44, "a");
            __builder.AddAttribute(45, "href", "/profile/" + (
#nullable restore
#line 102 "D:\git\FitAR\core\FitAR\FitAR.Web\Shared\_Header.razor"
                                                   Context.Client.username

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(46, "\r\n\t\t\t\t\t\t\t\t\t\t<i class=\"feather icon-user\"></i> Профил\r\n\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(47, "\r\n\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(48, "\r\n\t\t\t\t\t\t\t\t");
            __builder.OpenElement(49, "a");
            __builder.AddAttribute(50, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 106 "D:\git\FitAR\core\FitAR\FitAR.Web\Shared\_Header.razor"
                                             OnLogout

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(51, "\r\n\t\t\t\t\t\t\t\t\t");
            __builder.AddMarkupContent(52, "<li>\r\n\t\t\t\t\t\t\t\t\t\t<i class=\"feather icon-log-out\"></i> Логаут\r\n\t\t\t\t\t\t\t\t\t</li>\r\n\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(53, "\r\n\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(54, "\r\n\r\n\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(55, "\r\n");
#nullable restore
#line 114 "D:\git\FitAR\core\FitAR\FitAR.Web\Shared\_Header.razor"
					}
					else
					{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(56, "\t\t\t\t\t\t");
            __builder.AddMarkupContent(57, "<a href=\"/login\">Улогуј се</a>\r\n");
#nullable restore
#line 118 "D:\git\FitAR\core\FitAR\FitAR.Web\Shared\_Header.razor"
					}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(58, "\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(59, "\r\n\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(60, "\r\n\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(61, "\r\n\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(62, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 237 "D:\git\FitAR\core\FitAR\FitAR.Web\Shared\_Header.razor"

	protected override void OnInitialized()
	{
		this.OnInitializedAsync();
		this.ScopeWith(Scope, ARScope.ScopeComponent.Header, this.OnData);
	}

	async void OnLogout()
	{
		CachingManager.LoggedInDashboard.Remove(this.Context.Client.clientid.ToString());
		await this.WriteCookieAsync("wauth", "");
		this.StateHasChanged();
		this.Scope.NotifyStateChange();
	}

	public async Task WriteCookieAsync(string name, string value, int days = -365)
	{
		var test = await JSRuntime.InvokeAsync<object>("blazorExtensions.WriteCookie", name, value, days);
	}

	public void OnData(dynamic data)
	{
		if (data == null)
			return;

		try
		{
			this.Context.Client = data as ClientDM;
		}
		catch (Exception e) { }

	}


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ARScope Scope { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ARContext Context { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
#pragma warning restore 1591
