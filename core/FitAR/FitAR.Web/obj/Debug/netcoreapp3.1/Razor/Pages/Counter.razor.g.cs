#pragma checksum "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Counter.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "31eb61993ced957755daaccf4866f66a39e5a100"
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/counter")]
    public partial class Counter : ARPage
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Counter</h1>\r\n\r\n");
            __builder.OpenElement(1, "p");
            __builder.AddContent(2, "Current count: ");
            __builder.AddContent(3, 
#nullable restore
#line 5 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Counter.razor"
                   currentCount

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(4, "\r\n\r\n");
            __builder.OpenElement(5, "button");
            __builder.AddAttribute(6, "class", "btn btn-primary");
            __builder.AddAttribute(7, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 7 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Counter.razor"
                                          IncrementCount

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(8, "Click me");
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n\r\n");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(10);
            __builder.AddAttribute(11, "href", "/databaseTable/core:TestTable1");
            __builder.AddAttribute(12, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddContent(13, "test");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 13 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Counter.razor"
	private int currentCount = 0;

	private void IncrementCount()
	{
		currentCount++;
	}

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
