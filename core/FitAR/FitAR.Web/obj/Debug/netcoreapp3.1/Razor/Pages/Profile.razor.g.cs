#pragma checksum "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Profile.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e79af92ffb1ba09a53b2370279f354e5e7fb6797"
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/profile/{username}")]
    public partial class Profile : ARPage
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
#line 8 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Profile.razor"
         if (this.Client == null)
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
								<span>Не постоји профил са овим корисничким именом</span>
							</div>
						</div>
					</div>
				</div>
			</div>
");
#nullable restore
#line 22 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Profile.razor"
		}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(8, "\r\n");
#nullable restore
#line 24 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Profile.razor"
         if (this.Client != null)
		{


#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(9, "\t\t\t");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "page-body");
            __builder.AddMarkupContent(12, "\r\n\t\t\t\t\r\n\t\t\t\t");
            __builder.OpenElement(13, "div");
            __builder.AddAttribute(14, "class", "row");
            __builder.AddMarkupContent(15, "\r\n\t\t\t\t\t");
            __builder.OpenElement(16, "div");
            __builder.AddAttribute(17, "class", "col-lg-12");
            __builder.AddMarkupContent(18, "\r\n\t\t\t\t\t\t");
            __builder.OpenElement(19, "div");
            __builder.AddAttribute(20, "class", "cover-profile");
            __builder.AddMarkupContent(21, "\r\n\t\t\t\t\t\t\t");
            __builder.OpenElement(22, "div");
            __builder.AddAttribute(23, "class", "profile-bg-img");
            __builder.AddMarkupContent(24, "\r\n\t\t\t\t\t\t\t\t<img class=\"profile-bg-img img-fluid\" src=\"assets\\images\\user-profile\\bg-img1.jpg\" alt=\"bg-img\">\r\n\t\t\t\t\t\t\t\t");
            __builder.OpenElement(25, "div");
            __builder.AddAttribute(26, "class", "card-block user-info");
            __builder.AddMarkupContent(27, "\r\n\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(28, "div");
            __builder.AddAttribute(29, "class", "col-md-12");
            __builder.AddMarkupContent(30, "\r\n\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(31, "div");
            __builder.AddAttribute(32, "class", "media-left");
            __builder.AddMarkupContent(33, "\r\n\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(34, "a");
            __builder.AddAttribute(35, "href", "#");
            __builder.AddAttribute(36, "class", "profile-image");
            __builder.AddMarkupContent(37, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(38, "img");
            __builder.AddAttribute(39, "class", "user-img img-radius");
            __builder.AddAttribute(40, "src", 
#nullable restore
#line 38 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Profile.razor"
                                                                                       this.Client.profilePic

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(41, "alt", "user-img");
            __builder.AddAttribute(42, "style", "width:100px");
            __builder.CloseElement();
            __builder.AddMarkupContent(43, "\r\n\t\t\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(44, "\r\n\t\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(45, "\r\n\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(46, "div");
            __builder.AddAttribute(47, "class", "media-body row");
            __builder.AddMarkupContent(48, "\r\n\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(49, "div");
            __builder.AddAttribute(50, "class", "col-lg-12");
            __builder.AddMarkupContent(51, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(52, "div");
            __builder.AddAttribute(53, "class", "user-title");
            __builder.AddMarkupContent(54, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(55, "h2");
            __builder.AddContent(56, 
#nullable restore
#line 44 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Profile.razor"
                                                         this.Client.username

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(57, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(58, "span");
            __builder.AddAttribute(59, "class", "text-white");
            __builder.AddContent(60, 
#nullable restore
#line 45 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Profile.razor"
                                                                              this.Client.firstName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(61, " ");
            __builder.AddContent(62, 
#nullable restore
#line 45 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Profile.razor"
                                                                                                     this.Client.lastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(63, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(64, "\r\n\t\t\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(65, "\r\n\t\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(66, "\r\n\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(67, "\r\n\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(68, "\r\n\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(69, "\r\n\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(70, "\r\n\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(71, "\r\n\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(72, "\r\n\t\t\t\t\r\n\t\t\t\t");
            __builder.OpenElement(73, "div");
            __builder.AddAttribute(74, "class", "row");
            __builder.AddMarkupContent(75, "\r\n\t\t\t\t\t");
            __builder.OpenElement(76, "div");
            __builder.AddAttribute(77, "class", "col-lg-12");
            __builder.AddMarkupContent(78, "\r\n\t\t\t\t\t\t\r\n\t\t\t\t\t\t\r\n\t\t\t\t\t\t");
            __builder.OpenElement(79, "div");
            __builder.AddAttribute(80, "class", "tab-content");
            __builder.AddMarkupContent(81, "\r\n\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t");
            __builder.OpenElement(82, "div");
            __builder.AddAttribute(83, "class", "tab-pane active");
            __builder.AddAttribute(84, "id", "personal");
            __builder.AddAttribute(85, "role", "tabpanel");
            __builder.AddMarkupContent(86, "\r\n\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t");
            __builder.OpenElement(87, "div");
            __builder.AddAttribute(88, "class", "card");
            __builder.AddMarkupContent(89, "\r\n\t\t\t\t\t\t\t\t\t");
            __builder.AddMarkupContent(90, "<div class=\"card-header\">\r\n\t\t\t\t\t\t\t\t\t\t<h5 class=\"card-header-text\">Подаци о кориснику</h5>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(91, "div");
            __builder.AddAttribute(92, "class", "card-block");
            __builder.AddMarkupContent(93, "\r\n\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(94, "div");
            __builder.AddAttribute(95, "class", "view-info");
            __builder.AddMarkupContent(96, "\r\n\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(97, "div");
            __builder.AddAttribute(98, "class", "row");
            __builder.AddMarkupContent(99, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(100, "div");
            __builder.AddAttribute(101, "class", "col-lg-12");
            __builder.AddMarkupContent(102, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(103, "div");
            __builder.AddAttribute(104, "class", "general-info");
            __builder.AddMarkupContent(105, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(106, "div");
            __builder.AddAttribute(107, "class", "row");
            __builder.AddMarkupContent(108, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(109, "div");
            __builder.AddAttribute(110, "class", "col-lg-12 col-xl-6");
            __builder.AddMarkupContent(111, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(112, "div");
            __builder.AddAttribute(113, "class", "table-responsive");
            __builder.AddMarkupContent(114, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(115, "table");
            __builder.AddAttribute(116, "class", "table m-0");
            __builder.AddMarkupContent(117, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(118, "tbody");
            __builder.AddMarkupContent(119, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(120, "tr");
            __builder.AddMarkupContent(121, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.AddMarkupContent(122, "<th scope=\"row\">Име и презиме</th>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(123, "td");
            __builder.AddContent(124, 
#nullable restore
#line 80 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Profile.razor"
                                                                                     Client.firstName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(125, " ");
            __builder.AddContent(126, 
#nullable restore
#line 80 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Profile.razor"
                                                                                                       Client.lastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(127, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(128, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(129, "tr");
            __builder.AddMarkupContent(130, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.AddMarkupContent(131, "<th scope=\"row\">Профил креиран</th>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(132, "td");
            __builder.AddContent(133, 
#nullable restore
#line 84 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Profile.razor"
                                                                                     Client.created.PrintDate()

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(134, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(135, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(136, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(137, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(138, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(139, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(140, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(141, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(142, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(143, "\r\n\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(144, "\r\n\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(145, "\r\n\r\n\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(146, "\r\n\r\n\r\n");
#nullable restore
#line 107 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Profile.razor"
                                 if (!string.IsNullOrEmpty(this.Client.additional))
								{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(147, "\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(148, "div");
            __builder.AddAttribute(149, "class", "card");
            __builder.AddMarkupContent(150, "\r\n\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(151, "div");
            __builder.AddAttribute(152, "class", "card-block card-block-text");
            __builder.AddMarkupContent(153, "\r\n\t\t\t\t\t\t\t\t\t\t\t");
            __builder.AddContent(154, 
#nullable restore
#line 111 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Profile.razor"
                                              (MarkupString)this.Client.additional

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(155, "\r\n\t\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(156, "\r\n\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(157, "\r\n");
#nullable restore
#line 114 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Profile.razor"
								}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(158, "\r\n\t\t\t\t\t\t\t\t");
            __builder.OpenElement(159, "div");
            __builder.AddAttribute(160, "class", "row");
            __builder.AddMarkupContent(161, "\r\n\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(162, "div");
            __builder.AddAttribute(163, "class", "col-lg-12");
            __builder.AddMarkupContent(164, "\r\n\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(165, "div");
            __builder.AddAttribute(166, "class", "card");
            __builder.AddMarkupContent(167, "\r\n\t\t\t\t\t\t\t\t\t\t\t");
            __builder.AddMarkupContent(168, "<div class=\"card-header\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t<h5 class=\"card-header-text\">Логин подаци</h5>\r\n\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(169, "div");
            __builder.AddAttribute(170, "class", "card-block user-desc");
            __builder.AddMarkupContent(171, "\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(172, "div");
            __builder.AddAttribute(173, "class", "card-block");
            __builder.AddMarkupContent(174, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(175, "div");
            __builder.AddAttribute(176, "class", "dt-responsive table-responsive");
            __builder.AddMarkupContent(177, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(178, "table");
            __builder.AddAttribute(179, "class", "table table-striped table-bordered nowrap");
            __builder.AddAttribute(180, "serialize", true);
            __builder.AddMarkupContent(181, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.AddMarkupContent(182, "<thead>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<tr>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<th>Латитуда</th>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<th>Лонгтитуда</th>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<th>Трајање сесије</th>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<th>Вријеме</th>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t</tr>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t</thead>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(183, "tbody");
            __builder.AddMarkupContent(184, "\r\n");
#nullable restore
#line 136 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Profile.razor"
                                                                 foreach (var session in this.Sessions)
																{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(185, "\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(186, "tr");
            __builder.AddMarkupContent(187, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(188, "th");
            __builder.AddContent(189, 
#nullable restore
#line 139 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Profile.razor"
                                                                             session.lat

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(190, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(191, "th");
            __builder.AddContent(192, 
#nullable restore
#line 140 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Profile.razor"
                                                                             session.lng

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(193, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(194, "th");
            __builder.AddContent(195, 
#nullable restore
#line 141 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Profile.razor"
                                                                             session.duration

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(196, " секунди");
            __builder.CloseElement();
            __builder.AddMarkupContent(197, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.OpenElement(198, "th");
            __builder.AddContent(199, 
#nullable restore
#line 142 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Profile.razor"
                                                                             session.created.PrintDate()

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(200, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(201, "\r\n");
#nullable restore
#line 144 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Profile.razor"
																}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(202, "\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(203, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.AddMarkupContent(204, "<tfoot>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<tr>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<th>Латитуда</th>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<th>Лонгтитуда</th>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<th>Трајање сесије</th>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<th>Вријеме</th>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t</tr>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t</tfoot>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(205, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(206, "\r\n\t\t\t\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(207, "\r\n\r\n\t\t\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(208, "\r\n\t\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(209, "\r\n\t\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(210, "\r\n\t\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(211, "\r\n\r\n\t\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(212, "\r\n\t\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(213, "\r\n\r\n\t\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(214, "\r\n\t\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(215, "\r\n\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(216, "\r\n");
#nullable restore
#line 169 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Profile.razor"

		}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(217, "\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(218, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(219, "\r\n\r\n\r\n");
#nullable restore
#line 175 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Profile.razor"
 if (this.Client != null && Context.IsAdmin)
{


#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(220, "\t");
            __builder.OpenElement(221, "div");
            __builder.AddAttribute(222, "class", "card");
            __builder.AddMarkupContent(223, "\r\n\t\t");
            __builder.OpenElement(224, "div");
            __builder.AddAttribute(225, "class", "card-block");
            __builder.AddMarkupContent(226, "\r\n\t\t\t");
            __builder.AddMarkupContent(227, "<div class=\"form-group row\">\r\n\t\t\t</div>\r\n\t\t\t");
            __builder.OpenElement(228, "div");
            __builder.AddAttribute(229, "id", "content");
            __builder.AddAttribute(230, "class", "ck");
            __builder.AddMarkupContent(231, "\r\n\t\t\t\t");
            __builder.AddContent(232, 
#nullable restore
#line 183 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Profile.razor"
                  (MarkupString)this.Client.additional

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(233, "\r\n\t\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(234, "\r\n\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(235, "\r\n\t\t");
            __builder.OpenElement(236, "div");
            __builder.AddAttribute(237, "class", "card-block");
            __builder.AddMarkupContent(238, "\r\n\t\t\t");
            __builder.OpenElement(239, "button");
            __builder.AddAttribute(240, "class", "btn btn-primary");
            __builder.AddAttribute(241, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 187 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Profile.razor"
                                                      OnSave

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(242, "Sacuvaj");
            __builder.CloseElement();
            __builder.AddMarkupContent(243, "\r\n\t\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(244, "\r\n\t");
            __builder.CloseElement();
            __builder.AddMarkupContent(245, "\r\n");
#nullable restore
#line 190 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Profile.razor"

}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(246, "\r\n\r\n");
            __builder.AddMarkupContent(247, "<div id=\"styleSelector\">\r\n\r\n</div>");
        }
        #pragma warning restore 1998
#nullable restore
#line 202 "D:\git\FitAr\core\FitAR\FitAR.Web\Pages\Profile.razor"

	[Parameter] public string username { get; set; }
	ClientDM Client = null;
	List<ClientSessionDM> Sessions = new List<ClientSessionDM>();
	List<AnchorDM> Anchors = new List<AnchorDM>();


	protected override async Task OnParametersSetAsync()
	{
		base.OnParametersSetAsync();
		this.Client = await ARDirect.Instance.Query<ClientDM>().Where("username={0}", this.username).LoadSingleAsync();
		if (this.Client == null)
		{
			this.StateHasChanged();
			return;
		}

		this.Sessions = await ARDirect.Instance.Query<ClientSessionDM>().Where("clientid={0}", this.Client.ID.ToString()).Additional("order by created desc").Limit(50).LoadAsync();
		this.Anchors = await ARDirect.Instance.Query<AnchorDM>().Where("clientid={0}", this.Client.ID).Additional("order by created desc").LoadAsync();

	}


	protected async void OnSave()
	{
		this.Client.additional = await JSRuntime.InvokeAsync<string>("CKCustomEditor.getData");
		await this.Client.UpdateAsync();

		//// update title
		//var fallbackArticle = (from a in CachingManager.IRCArticles where a.ID == this.ArticleModel.fallbackid.Value select a).FirstOrDefault();
		//for (var i = 0; i < fallbackArticle.Columns.Count; i++)
		//	if (fallbackArticle.Columns[i].ID == this.ArticleModel.ID.Value)
		//	{
		//		fallbackArticle.Columns[i].Title = this.ArticleModel.title;
		//		break;
		//	}

		this.StateHasChanged();
	}


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ARContext Context { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
#pragma warning restore 1591
