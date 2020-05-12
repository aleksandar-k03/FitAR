using FitAR.Web.Code;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FitAR.Web
{
  public class ARScope
  {

    public enum ScopeGroup
    {
      Socket, 
      Login,
      ICR
    }

    public enum ScopeComponent
    {
      Layout,
      Header,
      Login,
      MS_ICR
    }

    protected Dictionary<ScopeComponent, ARScopeEntry> Actions = new Dictionary<ScopeComponent, ARScopeEntry>();
    protected Dictionary<ScopeGroup, Dictionary<ScopeComponent, ARScopeEntry>> Groups = new Dictionary<ScopeGroup, Dictionary<ScopeComponent, ARScopeEntry>>();

    public KeyValuePair<ScopeComponent, ARScopeEntry> AddAction(ScopeComponent id, ARScopeEntry entry)
    {
      KeyValuePair<ScopeComponent, ARScopeEntry> pair = KeyValuePair.Create<ScopeComponent, ARScopeEntry>(id, entry);
      if (this.Actions.ContainsKey(id))
        return pair;

      this.Actions.Add(pair.Key, pair.Value);
      return pair;
    }

    public void AddIntoGroup(ScopeGroup group, ScopeComponent component, ARScopeEntry entry)
    {
      var elem = this.AddAction(component, entry);
      if (!Groups.ContainsKey(group))
        Groups.Add(group, new Dictionary<ScopeComponent, ARScopeEntry>());

      if (!Groups[group].ContainsKey(component))
        Groups[group].Add(elem.Key, elem.Value);
    }

    public void NotifyStateChange(dynamic? data = null)
    {
      foreach (var action in this.Actions)
        try 
        {
          action.Value.Inline.Invoke();
          action.Value.Override?.Invoke(data);
        }
        catch { }
    }

    public void NotifyStateChange(ScopeGroup group, dynamic? data = null)
    {
      if (!Groups.ContainsKey(group))
        return;
      
      foreach (var action in this.Groups[group])
        try 
        {
          action.Value.Inline.Invoke();
          action.Value.Override?.Invoke(data);
        }
        catch { }
    }

    public void NotifyStateChange(ScopeComponent component, dynamic? data = null)
    {
      if (!Actions.ContainsKey(component))
        return;

      Actions[component]?.Inline.Invoke();
      Actions[component]?.Override?.Invoke(data);
    }

  }
}
