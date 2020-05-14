using FitAR.Web.Code;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitAR.Web
{
  public class ARPage : ComponentBase, IDisposable
  {
    

    public void Dispose() { this.OnDispose(); }
    public virtual void OnDispose() { }

    public void ScopeWith(ARScope scope, ARScope.ScopeComponent component, Action<dynamic>? action = null) => this.ScopeWith(scope, null, component, action);
    public void ScopeWith(ARScope scope, ARScope.ScopeGroup? group, ARScope.ScopeComponent component, Action<dynamic>? action = null)
    {
      ARScopeEntry entry = new ARScopeEntry();
      entry.Inline = () =>
      {
        InvokeAsync(() => { this.StateHasChanged(); });
      };
      entry.Override = action;

      if (group.HasValue)
        scope.AddIntoGroup(group.Value, component, entry);
      else
        scope.AddAction(component, entry);
    }

    //protected override async Task OnAfterRenderAsync(bool firstRender)
    //{
    //  try
    //  {
    //    await this._jsRuntime.InvokeVoidAsync("onReady", firstRender);
    //  }
    //  catch (Exception e)
    //  {
    //    Console.WriteLine("Greska sa onReady");
    //  }

    //  return base.OnAfterRenderAsync(firstRender);
    //}

  }
}
