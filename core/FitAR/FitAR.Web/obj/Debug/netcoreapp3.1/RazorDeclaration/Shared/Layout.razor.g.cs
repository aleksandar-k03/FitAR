#pragma checksum "D:\git\FitAr\core\FitAR\FitAR.Web\Shared\Layout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d39e3a0d18d43d67ee4a2e739c17b03459304142"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace FitAR.Web.Shared
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
    public partial class Layout : FitAR.Web.Code.ARLayoutBase, IDisposable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 13 "D:\git\FitAr\core\FitAR\FitAR.Web\Shared\Layout.razor"
	protected CancellationTokenSource src = new CancellationTokenSource();
	protected ClientWebSocket Socket;

	protected override async Task OnAfterRenderAsync(bool firstRender)
	{
		await JSRuntime.InvokeVoidAsync("onReady", firstRender);
	}

	public override void OnDispose()
	{
		try
		{
			if(this.Socket != null)
				this.Socket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "", src.Token);
		}
		catch { }
		src.Cancel();
	}

	protected override async Task OnInitializedAsync()
	{
		base.OnInitializedAsync();

		Task socketTask = Task.Run(async () =>
		{
			var buffer = new byte[10240];
			this.Socket= new ClientWebSocket();
			await Socket.ConnectAsync(new Uri("wss://localhost:5001/ws_dashboard"), src.Token);
			for (; ; )
			{
				await Socket.ReceiveAsync(new ArraySegment<byte>(buffer), src.Token);
				string content = System.Text.Encoding.UTF8.GetString(buffer);
				Console.WriteLine("Imamo odgovor na dashboard: " + content);
				buffer = new byte[1024];

				try
				{
					var data = JsonConvert.DeserializeObject<DashboardModel>(content);
					if (!string.IsNullOrEmpty(data.Text))
						await JSRuntime.InvokeVoidAsync(data.Function.ToString(),  data.Text);

					if (data.RequireReload)
						ARScope.NotifyStateChange(ARScope.ScopeGroup.Socket);
				}
				catch(Exception e)
				{
					Console.WriteLine("Greska u konvertovanju objekta " + e.ToString());
				}

			}
		});
	}



#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ARScope ARScope { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
#pragma warning restore 1591
