#pragma checksum "D:\git\FitAr\core\FitAR\FitAR.Web\Shared\MenuSections\MS1_Application.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "740ac8929c5dff72fa748cbd6d3855dc76e6aee5"
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
    public partial class MS1_Application : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<div class=\"pcoded-navigatio-lavel\">Application</div>\r\n");
            __builder.OpenElement(1, "ul");
            __builder.AddAttribute(2, "class", "pcoded-item pcoded-left-item");
            __builder.AddMarkupContent(3, "\r\n\t");
            __builder.OpenElement(4, "li");
            __builder.AddAttribute(5, "class", true);
            __builder.AddMarkupContent(6, "\r\n\t\t");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(7);
            __builder.AddAttribute(8, "href", "/");
            __builder.AddAttribute(9, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(10, "\r\n\t\t\t");
                __builder2.AddMarkupContent(11, "<span class=\"pcoded-micon\"><i class=\"feather icon-menu\"></i></span>\r\n\t\t\t");
                __builder2.AddMarkupContent(12, "<span class=\"pcoded-mtext\">Почетна страница</span>\r\n\t\t");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(13, "\r\n\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\r\n\t");
            __builder.AddMarkupContent(15, "<li class>\r\n\t\t<a href=\"https://github.com/aleksandar-k03/FitAR\" target=\"_blank\">\r\n\t\t\t<span class=\"pcoded-micon\"><i class=\"feather icon-menu\"></i></span>\r\n\t\t\t<span class=\"pcoded-mtext\">Github (source code)</span>\r\n\t\t</a>\r\n\t</li>\r\n\t");
            __builder.AddMarkupContent(16, "<li class>\r\n\t\t<a href=\"https://github.com/aleksandar-k03/FitAR\" target=\"_blank\">\r\n\t\t\t<span class=\"pcoded-micon\"><i class=\"feather icon-menu\"></i></span>\r\n\t\t\t<span class=\"pcoded-mtext\">.apk download</span>\r\n\t\t</a>\r\n\t</li>\r\n\t");
            __builder.AddMarkupContent(17, "<li class>\r\n\t\t<a>\r\n\t\t\t<span class=\"pcoded-micon\"><i class=\"feather icon-menu\"></i></span>\r\n\t\t\t<span class=\"pcoded-mtext\">Пројектовање ИС</span>\r\n\t\t</a>\r\n\t</li>\r\n\t");
            __builder.AddMarkupContent(18, "<li class>\r\n\t\t<a href=\"/clients\">\r\n\t\t\t<span class=\"pcoded-micon\"><i class=\"feather icon-menu\"></i></span>\r\n\t\t\t<span class=\"pcoded-mtext\">Kорисници</span>\r\n\t\t</a>\r\n\t</li>\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
