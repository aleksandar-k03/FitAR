using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitAR.Web.Code
{
  public class ARLayoutBase : LayoutComponentBase, IDisposable
  {
    public void Dispose()
    {
      this.OnDispose();
    }

    public virtual void OnDispose() { }
  }
}
