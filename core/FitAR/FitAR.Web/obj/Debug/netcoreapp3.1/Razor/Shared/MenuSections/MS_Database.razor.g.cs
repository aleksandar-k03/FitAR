#pragma checksum "D:\git\FitAr\core\FitAR\FitAR.Web\Shared\MenuSections\MS_Database.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e60454586e1e1eb0d7e5b8abca49d58beb63f922"
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
    public partial class MS_Database : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<div class=\"pcoded-navigatio-lavel\">База података</div>\r\n");
            __builder.OpenElement(1, "ul");
            __builder.AddAttribute(2, "class", "pcoded-item pcoded-left-item");
            __builder.AddMarkupContent(3, "\r\n");
#nullable restore
#line 5 "D:\git\FitAr\core\FitAR\FitAR.Web\Shared\MenuSections\MS_Database.razor"
     foreach (var schema in Caching.CachingManager.DatabaseSchemas)
	{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(4, "\t\t");
            __builder.OpenElement(5, "li");
            __builder.AddAttribute(6, "class", "pcoded-hasmenu_a ");
            __builder.AddMarkupContent(7, "\r\n\t\t\t");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "aopen");
            __builder.AddMarkupContent(10, "\r\n\t\t\t\t");
            __builder.AddMarkupContent(11, "<span class=\"pcoded-micon\"><i class=\"feather icon-file-plus\"></i></span>\r\n\t\t\t\t");
            __builder.OpenElement(12, "span");
            __builder.AddAttribute(13, "class", "pcoded-mtext");
            __builder.AddContent(14, 
#nullable restore
#line 10 "D:\git\FitAr\core\FitAR\FitAR.Web\Shared\MenuSections\MS_Database.razor"
                                            schema.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\r\n\t\t\t");
            __builder.OpenElement(17, "ul");
            __builder.AddAttribute(18, "class", "pcoded-submenu_a");
            __builder.AddMarkupContent(19, "\r\n");
#nullable restore
#line 13 "D:\git\FitAr\core\FitAR\FitAR.Web\Shared\MenuSections\MS_Database.razor"
                 foreach (var table in schema.Tables)
				{
					var url = $"/databaseTable/{schema.Name}:{table.Name}";

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(20, "\t\t\t\t\t");
            __builder.OpenElement(21, "li");
            __builder.AddAttribute(22, "class", " ");
            __builder.AddMarkupContent(23, "\r\n\t\t\t\t\t\t");
            __builder.OpenElement(24, "a");
            __builder.AddAttribute(25, "href", 
#nullable restore
#line 17 "D:\git\FitAr\core\FitAR\FitAR.Web\Shared\MenuSections\MS_Database.razor"
                                  url

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(26, "\r\n\t\t\t\t\t\t\t");
            __builder.OpenElement(27, "span");
            __builder.AddAttribute(28, "class", "pcoded-mtext");
            __builder.AddContent(29, 
#nullable restore
#line 18 "D:\git\FitAr\core\FitAR\FitAR.Web\Shared\MenuSections\MS_Database.razor"
                                                        table.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\r\n\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\r\n");
#nullable restore
#line 21 "D:\git\FitAr\core\FitAR\FitAR.Web\Shared\MenuSections\MS_Database.razor"
				}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(33, "\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\r\n\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\r\n");
#nullable restore
#line 24 "D:\git\FitAr\core\FitAR\FitAR.Web\Shared\MenuSections\MS_Database.razor"
	}

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
