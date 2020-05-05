using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FitAR.Sockets
{
  public abstract class SocketModelBase
  {

    public string Convert()
      => JsonConvert.SerializeObject(this);

  }
}
