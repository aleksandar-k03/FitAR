using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitAR.Web
{
  public class ARPage : ComponentBase
  {

    public void ScopeWith(ARScope scope, ARScope.ScopeComponent component, Action? action = null) => this.ScopeWith(scope, null, component, action);
    public void ScopeWith(ARScope scope, ARScope.ScopeGroup? group, ARScope.ScopeComponent component, Action? action = null)
    {
      Action inlineAction = () =>
      {
        InvokeAsync(() => { this.StateHasChanged(); });
        if (action != null)
          action?.Invoke();
      };

      if (group.HasValue)
        scope.AddIntoGroup(group.Value, component, inlineAction);
      else
        scope.AddAction(component, inlineAction);
    }

  }
}
