#pragma checksum "D:\git\FitAR\core\FitAR\FitAR.Web\Pages\DatabaseInfo.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "11ab5c7eed680486d4ed85a365792957cdda5031"
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/databaseTable/{input}")]
    public partial class DatabaseInfo : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 3 "D:\git\FitAR\core\FitAR\FitAR.Web\Pages\DatabaseInfo.razor"
 if (!this.HasError)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "\t");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "main-body");
            __builder.AddMarkupContent(3, "\r\n\t\t");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "page-wrapper");
            __builder.AddMarkupContent(6, "\r\n\t\t\t");
            __builder.AddMarkupContent(7, @"<div class=""page-header"">
				<div class=""row align-items-end"">
					<div class=""col-lg-8"">
						<div class=""page-header-title"">
							<div class=""d-inline"">
								<h4>База података</h4>
								<span>Динамични приказ табела коришћених у апликацији</span>
							</div>
						</div>
					</div>
				</div>
			</div>

			");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "page-body");
            __builder.AddMarkupContent(10, "\r\n\t\t\t\t");
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "card");
            __builder.AddMarkupContent(13, "\r\n\t\t\t\t\t");
            __builder.OpenElement(14, "div");
            __builder.AddAttribute(15, "class", "card-header");
            __builder.AddMarkupContent(16, "\r\n\t\t\t\t\t\t");
            __builder.OpenElement(17, "h5");
            __builder.AddMarkupContent(18, "\r\n\t\t\t\t\t\t\t");
            __builder.AddContent(19, 
#nullable restore
#line 39 "D:\git\FitAR\core\FitAR\FitAR.Web\Pages\DatabaseInfo.razor"
                             Table.Name

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(20, "\r\n\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n\t\t\t\t\t\t");
            __builder.OpenElement(22, "span");
            __builder.AddContent(23, 
#nullable restore
#line 41 "D:\git\FitAR\core\FitAR\FitAR.Web\Pages\DatabaseInfo.razor"
                               Table.Schema

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n\r\n\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n\t\t\t\t\t");
            __builder.OpenElement(26, "div");
            __builder.AddAttribute(27, "class", "card-block table-border-style");
            __builder.AddMarkupContent(28, "\r\n\t\t\t\t\t\t");
            __builder.OpenElement(29, "div");
            __builder.AddAttribute(30, "class", "table-responsive");
            __builder.AddMarkupContent(31, "\r\n\t\t\t\t\t\t\t");
            __builder.OpenElement(32, "table");
            __builder.AddAttribute(33, "class", "table");
            __builder.AddMarkupContent(34, "\r\n\t\t\t\t\t\t\t\t");
            __builder.AddMarkupContent(35, "<thead>\r\n\t\t\t\t\t\t\t\t\t<tr>\r\n\t\t\t\t\t\t\t\t\t\t<th>#</th>\r\n\t\t\t\t\t\t\t\t\t\t<th>Име</th>\r\n\t\t\t\t\t\t\t\t\t\t<th>Тип</th>\r\n\t\t\t\t\t\t\t\t\t\t<th>Дефаулт вриједност</th>\r\n\t\t\t\t\t\t\t\t\t</tr>\r\n\t\t\t\t\t\t\t\t</thead>\r\n\t\t\t\t\t\t\t\t");
            __builder.OpenElement(36, "tbody");
            __builder.AddMarkupContent(37, "\r\n");
#nullable restore
#line 56 "D:\git\FitAR\core\FitAR\FitAR.Web\Pages\DatabaseInfo.razor"
                                     for (int i = 0; i < Table.Columns.Count; i++)
									{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(38, "\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(39, "tr");
            __builder.AddMarkupContent(40, "\r\n\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(41, "th");
            __builder.AddContent(42, 
#nullable restore
#line 59 "D:\git\FitAR\core\FitAR\FitAR.Web\Pages\DatabaseInfo.razor"
                                                 i

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(43, "\r\n\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(44, "th");
            __builder.AddMarkupContent(45, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.AddContent(46, 
#nullable restore
#line 61 "D:\git\FitAR\core\FitAR\FitAR.Web\Pages\DatabaseInfo.razor"
                                                 Table.Columns[i].Name

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(47, "\r\n\t\t\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(48, "\r\n\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(49, "th");
            __builder.AddContent(50, 
#nullable restore
#line 63 "D:\git\FitAR\core\FitAR\FitAR.Web\Pages\DatabaseInfo.razor"
                                                 Table.Columns[i].Type

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(51, "\r\n\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(52, "th");
            __builder.AddContent(53, 
#nullable restore
#line 64 "D:\git\FitAR\core\FitAR\FitAR.Web\Pages\DatabaseInfo.razor"
                                                 Table.Columns[i].Default

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(54, "\r\n\t\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(55, "\r\n");
#nullable restore
#line 66 "D:\git\FitAR\core\FitAR\FitAR.Web\Pages\DatabaseInfo.razor"
									}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(56, "\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(57, "\r\n\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(58, "\r\n\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(59, "\r\n\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(60, "\r\n\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(61, "\r\n\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(62, "\r\n\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(63, "\r\n\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(64, "\r\n");
#nullable restore
#line 75 "D:\git\FitAR\core\FitAR\FitAR.Web\Pages\DatabaseInfo.razor"
}
else
{


#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(65, "\t");
            __builder.AddMarkupContent(66, "<div>Postoji greska</div>\r\n");
#nullable restore
#line 80 "D:\git\FitAR\core\FitAR\FitAR.Web\Pages\DatabaseInfo.razor"

}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 83 "D:\git\FitAR\core\FitAR\FitAR.Web\Pages\DatabaseInfo.razor"
       
	[Parameter] public string input { get; set; } = string.Empty;
	[Parameter] public string tableName { get; set; } = string.Empty;
	[Parameter] public string schemaName { get; set; } = string.Empty;
	public bool HasError = false;
	public CachingDatabaseTable Table { get; set; }

	protected override void OnParametersSet()
	{
		if (string.IsNullOrEmpty(this.input))
		{
			this.HasError = true;
			return;
		}

		string[] split = this.input.Split(':');
		if (split.Length != 2)
		{
			this.HasError = true;
			return;
		}

		this.schemaName = split[0];
		this.tableName = split[1];

		foreach (var schema in Caching.CachingManager.DatabaseSchemas)
			if (schema.Name.Equals(this.schemaName))
				foreach (var table in schema.Tables)
					if (table.Name.Equals(this.tableName))
					{
						this.Table = table;
						break;
					}

		if (Table == null)
		{
			this.HasError = true;
			// error
		}
	}

	protected override void OnInitialized()
	{
	}

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
