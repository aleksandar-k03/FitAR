#pragma checksum "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\APIController.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "38dcfc7d6ae1f657382013c91feccd7ceda2496f"
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/_api/{name}")]
    public partial class APIController : ARPage
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "main-body");
            __builder.AddMarkupContent(2, "\r\n\t");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "page-wrapper");
            __builder.AddMarkupContent(5, "\r\n\t\t\r\n\r\n");
#nullable restore
#line 8 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\APIController.razor"
         if (this.HasError)
		{


#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(6, "\t\t\t");
            __builder.AddMarkupContent(7, @"<div class=""page-header"">
				<div class=""row align-items-end"">
					<div class=""col-lg-8"">
						<div class=""page-header-title"">
							<div class=""d-inline"">
								<h4>Грешка</h4>
								<span>Контролер не постоји</span>
							</div>
						</div>
					</div>
				</div>
			</div>
");
#nullable restore
#line 23 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\APIController.razor"
		}
		else
		{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(8, "\t\t\t");
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "class", "page-header");
            __builder.AddMarkupContent(11, "\r\n\t\t\t\t");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "row align-items-end");
            __builder.AddMarkupContent(14, "\r\n\t\t\t\t\t");
            __builder.OpenElement(15, "div");
            __builder.AddAttribute(16, "class", "col-lg-8");
            __builder.AddMarkupContent(17, "\r\n\t\t\t\t\t\t");
            __builder.OpenElement(18, "div");
            __builder.AddAttribute(19, "class", "page-header-title");
            __builder.AddMarkupContent(20, "\r\n\t\t\t\t\t\t\t");
            __builder.OpenElement(21, "div");
            __builder.AddAttribute(22, "class", "d-inline");
            __builder.AddMarkupContent(23, "\r\n\t\t\t\t\t\t\t\t");
            __builder.OpenElement(24, "h4");
            __builder.AddContent(25, 
#nullable restore
#line 31 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\APIController.razor"
                                     Controller.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n\t\t\t\t\t\t\t\t");
            __builder.OpenElement(27, "span");
            __builder.AddContent(28, 
#nullable restore
#line 32 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\APIController.razor"
                                       Controller.Description

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(29, "\r\n\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\r\n\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\r\n\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\r\n\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\r\n");
#nullable restore
#line 38 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\APIController.razor"
		}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(35, "\t\t\r\n\r\n");
#nullable restore
#line 41 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\APIController.razor"
         if (this.HasError == false)
		{
			

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\APIController.razor"
             foreach (var method in this.Controller.Methods)
			{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(36, "\t\t\t\t");
            __builder.OpenElement(37, "div");
            __builder.AddAttribute(38, "class", "page-body");
            __builder.AddMarkupContent(39, "\r\n\t\t\t\t\t");
            __builder.OpenElement(40, "div");
            __builder.AddAttribute(41, "class", "row");
            __builder.AddMarkupContent(42, "\r\n\t\t\t\t\t\t");
            __builder.OpenElement(43, "div");
            __builder.AddAttribute(44, "class", "col-sm-12");
            __builder.AddMarkupContent(45, "\r\n\t\t\t\t\t\t\t");
            __builder.OpenElement(46, "div");
            __builder.AddAttribute(47, "class", "card");
            __builder.AddMarkupContent(48, "\r\n\t\t\t\t\t\t\t\t");
            __builder.OpenElement(49, "div");
            __builder.AddAttribute(50, "class", "card-header");
            __builder.AddMarkupContent(51, "\r\n\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(52, "h5");
            __builder.AddContent(53, 
#nullable restore
#line 50 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\APIController.razor"
                                         method.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(54, "\r\n\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(55, "span");
            __builder.AddAttribute(56, "style", "color:#0000a8");
            __builder.AddContent(57, 
#nullable restore
#line 51 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\APIController.razor"
                                                                 Context.WebsiteUrl

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(58, "/");
            __builder.AddContent(59, 
#nullable restore
#line 51 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\APIController.razor"
                                                                                     method.Route

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(60, "\r\n\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(61, "span");
            __builder.AddContent(62, 
#nullable restore
#line 52 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\APIController.razor"
                                           method.Description

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(63, "\r\n\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(64, "\r\n\t\t\t\t\t\t\t\t");
            __builder.OpenElement(65, "div");
            __builder.AddAttribute(66, "class", "card-block");
            __builder.AddMarkupContent(67, "\r\n\t\t\t\t\t\t\t\t\tУлазни параметри <br>\r\n\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(68, "code");
            __builder.AddMarkupContent(69, "\r\n\t\t\t\t\t\t\t\t\t\t");
            __builder.AddContent(70, 
#nullable restore
#line 57 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\APIController.razor"
                                          (MarkupString)method.Input

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(71, "\r\n\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(72, "<br><br>\r\n\t\t\t\t\t\t\t\t\tОчекивани одговор<br>\r\n\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(73, "code");
            __builder.AddMarkupContent(74, "\r\n\t\t\t\t\t\t\t\t\t\t");
            __builder.AddContent(75, 
#nullable restore
#line 61 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\APIController.razor"
                                          (MarkupString)method.Output

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(76, "\r\n\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(77, "\r\n\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(78, "\r\n\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(79, "\r\n\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(80, "\r\n\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(81, "\r\n\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(82, "\r\n");
#nullable restore
#line 68 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\APIController.razor"
			}

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\APIController.razor"
             
		}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(83, "\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(84, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 78 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\APIController.razor"

	[Parameter] public string name { get; set; }
	public bool HasError = false;
	public CachingApiController Controller = null;

	protected override void OnParametersSet()
	{
		this.Controller = (from c in CachingManager.ApiControllers where c.ID.Equals(this.name) select c).FirstOrDefault();
		if (this.Controller == null)
			this.HasError = true;
	}

	protected override Task OnInitializedAsync()
	{
		return base.OnInitializedAsync();
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
