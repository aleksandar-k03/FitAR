using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FitAR.Web
{
  public class ARScope
  {

    public enum ScopeGroup
    {
      Socket, 
      ICR
    }

    public enum ScopeComponent
    {
      Layout,
      Header,
      Login,
      MS_ICR
    }

    protected Dictionary<ScopeComponent, Action> Actions = new Dictionary<ScopeComponent, Action>();
    protected Dictionary<ScopeGroup, Dictionary<ScopeComponent, Action>> Groups = new Dictionary<ScopeGroup, Dictionary<ScopeComponent, Action>>();

    public KeyValuePair<ScopeComponent, Action> AddAction(ScopeComponent id, Action action)
    {
      KeyValuePair<ScopeComponent, Action> pair = KeyValuePair.Create<ScopeComponent, Action>(id, action);
      if (this.Actions.ContainsKey(id))
        return pair;

      this.Actions.Add(pair.Key, pair.Value);
      return pair;
    }

    public void AddIntoGroup(ScopeGroup group, ScopeComponent component, Action action)
    {
      var elem = this.AddAction(component, action);
      if (!Groups.ContainsKey(group))
        Groups.Add(group, new Dictionary<ScopeComponent, Action>());

      if (!Groups[group].ContainsKey(component))
        Groups[group].Add(elem.Key, elem.Value);
    }

    public void NotifyStateChange()
    {
      foreach (var action in this.Actions)
        try { action.Value?.Invoke(); }
        catch { }
    }

    public void NotifyStateChange(ScopeGroup group)
    {
      if (!Groups.ContainsKey(group))
        return;

      foreach (var action in this.Groups[group])
        try { action.Value?.Invoke(); }
        catch { }
    }

    public void NotifyStateChange(ScopeComponent component)
    {
      if (!Actions.ContainsKey(component))
        return;

      Actions[component]?.Invoke();
    }

  }
}
