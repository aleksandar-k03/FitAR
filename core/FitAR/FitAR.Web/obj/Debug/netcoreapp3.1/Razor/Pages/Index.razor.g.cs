#pragma checksum "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6332e568b5f02a12f3f1f4196d8814c53e375874"
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
#nullable restore
#line 20 "D:\git\FitAr\core\FitAR\FitAR.Web\_Imports.razor"
using FitAR.Sockets;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : ARPage
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "main-body");
            __builder.AddMarkupContent(2, "\r\n\t");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "page-wrapper");
            __builder.AddMarkupContent(5, "\r\n\r\n\t\t");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "page-body");
            __builder.AddMarkupContent(8, "\r\n\t\t\t");
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "class", "row");
            __builder.AddMarkupContent(11, "\r\n\t\t\t\t\r\n\t\t\t\t");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "col-xl-3 col-md-6");
            __builder.AddMarkupContent(14, "\r\n\t\t\t\t\t");
            __builder.OpenElement(15, "div");
            __builder.AddAttribute(16, "class", "card bg-c-yellow update-card");
            __builder.AddMarkupContent(17, "\r\n\t\t\t\t\t\t");
            __builder.OpenElement(18, "div");
            __builder.AddAttribute(19, "class", "card-block");
            __builder.AddMarkupContent(20, "\r\n\t\t\t\t\t\t\t");
            __builder.OpenElement(21, "div");
            __builder.AddAttribute(22, "class", "row align-items-end");
            __builder.AddMarkupContent(23, "\r\n\t\t\t\t\t\t\t\t");
            __builder.OpenElement(24, "div");
            __builder.AddAttribute(25, "class", "col-8");
            __builder.AddMarkupContent(26, "\r\n\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(27, "h4");
            __builder.AddAttribute(28, "class", "text-white");
            __builder.AddContent(29, 
#nullable restore
#line 14 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Index.razor"
                                                            this.Socket.NumberOfConnections

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n\t\t\t\t\t\t\t\t\t");
            __builder.AddMarkupContent(31, "<h6 class=\"text-white m-b-0\">Тренутни број корисника на платформи</h6>\r\n\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\r\n\t\t\t\t\t\t\t\t");
            __builder.AddMarkupContent(33, "<div class=\"col-4 text-right\">\r\n\t\t\t\t\t\t\t\t\t<canvas id=\"update-chart-1\" height=\"50\"></canvas>\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\r\n\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\r\n\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(36, "\r\n\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\r\n\t\t\t\t");
            __builder.OpenElement(38, "div");
            __builder.AddAttribute(39, "class", "col-xl-3 col-md-6");
            __builder.AddMarkupContent(40, "\r\n\t\t\t\t\t");
            __builder.OpenElement(41, "div");
            __builder.AddAttribute(42, "class", "card bg-c-green update-card");
            __builder.AddMarkupContent(43, "\r\n\t\t\t\t\t\t");
            __builder.OpenElement(44, "div");
            __builder.AddAttribute(45, "class", "card-block");
            __builder.AddMarkupContent(46, "\r\n\t\t\t\t\t\t\t");
            __builder.OpenElement(47, "div");
            __builder.AddAttribute(48, "class", "row align-items-end");
            __builder.AddMarkupContent(49, "\r\n\t\t\t\t\t\t\t\t");
            __builder.OpenElement(50, "div");
            __builder.AddAttribute(51, "class", "col-8");
            __builder.AddMarkupContent(52, "\r\n\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(53, "h4");
            __builder.AddAttribute(54, "class", "text-white");
            __builder.AddContent(55, 
#nullable restore
#line 29 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Index.razor"
                                                            this.AndroidSocket.NumberOfConnections

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(56, "\r\n\t\t\t\t\t\t\t\t\t");
            __builder.AddMarkupContent(57, "<h6 class=\"text-white m-b-0\">Тренутни број андроид корисника</h6>\r\n\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(58, "\r\n\t\t\t\t\t\t\t\t");
            __builder.AddMarkupContent(59, "<div class=\"col-4 text-right\">\r\n\t\t\t\t\t\t\t\t\t<canvas id=\"update-chart-2\" height=\"50\"></canvas>\r\n\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(60, "\r\n\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(61, "\r\n\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(62, "\r\n\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(63, "\r\n\r\n\r\n\r\n\r\n\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(64, "\r\n\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(65, "\r\n\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(66, "\r\n\r\n\t");
            __builder.AddMarkupContent(67, "<div id=\"styleSelector\">\r\n\r\n\t</div>\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 97 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Index.razor"

	public int SocketConnections = 0;
	public string Test = Guid.NewGuid().ToString();

	protected override void OnInitialized()
	{
		this.ScopeWith(Scope, ARScope.ScopeGroup.Socket, ARScope.ScopeComponent.Layout);
	}


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ARScope Scope { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private FitAR.Sockets.AndroidSocketManager AndroidSocket { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private FitAR.Sockets.DashboardSocketHandler Socket { get; set; }
    }
}
#pragma warning restore 1591
