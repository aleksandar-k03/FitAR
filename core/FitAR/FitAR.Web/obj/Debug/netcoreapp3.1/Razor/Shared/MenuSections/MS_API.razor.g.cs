#pragma checksum "D:\git\FitAR\core\FitAR\FitAR.Web\Shared\MenuSections\MS_API.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ffb77a4f51aa7dd375ae3449d04f25ade3f8b104"
// <auto-generated/>
#pragma warning disable 1591
namespace FitAR.Web.Shared.MenuSections
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
    public partial class MS_API : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<div class=\"pcoded-navigatio-lavel\">АПИ</div>\r\n");
            __builder.OpenElement(1, "ul");
            __builder.AddAttribute(2, "class", "pcoded-item pcoded-left-item");
            __builder.AddMarkupContent(3, "\r\n");
#nullable restore
#line 4 "D:\git\FitAR\core\FitAR\FitAR.Web\Shared\MenuSections\MS_API.razor"
     foreach (var api in Caching.CachingManager.ApiControllers)
	{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(4, "\t\t");
            __builder.OpenElement(5, "li");
            __builder.AddAttribute(6, "class", true);
            __builder.AddMarkupContent(7, "\r\n\t\t\t");
            __builder.OpenElement(8, "a");
            __builder.AddAttribute(9, "href", "/_api/" + (
#nullable restore
#line 7 "D:\git\FitAR\core\FitAR\FitAR.Web\Shared\MenuSections\MS_API.razor"
                            api.ID

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(10, "\r\n\t\t\t\t");
            __builder.AddMarkupContent(11, "<span class=\"pcoded-micon\"><i class=\"feather icon-file-plus\"></i></span>\r\n\t\t\t\t");
            __builder.OpenElement(12, "span");
            __builder.AddAttribute(13, "class", "pcoded-mtext");
            __builder.AddContent(14, 
#nullable restore
#line 9 "D:\git\FitAR\core\FitAR\FitAR.Web\Shared\MenuSections\MS_API.razor"
                                            api.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\r\n\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n");
#nullable restore
#line 12 "D:\git\FitAR\core\FitAR\FitAR.Web\Shared\MenuSections\MS_API.razor"
	}

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
