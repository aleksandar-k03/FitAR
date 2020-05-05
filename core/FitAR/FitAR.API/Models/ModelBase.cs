using System;
using System.Collections.Generic;
using System.Text;

namespace FitAR.Web.API.Models
{
  public class ModelBase
  {
    public bool hasError { get; set; } = false;
    public string errorMessage { get; set; } = string.Empty;

    public void GenerateError(string err)
    {
      this.hasError = true;
      this.errorMessage = err;
    }

  }
}
