using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitAR.Sockets.Models
{
  public class AndroidSocketMessage : SocketModelBase
  {
    public string action { get; set; }
    public string subaction { get; set; }
    public string data { get; set; }

    public static AndroidSocketMessage Construct(string action, string subaction, object data)
      => new AndroidSocketMessage()
      {
        action = action,
        subaction = subaction,
        data = JsonConvert.SerializeObject(data)
      };

  }
}
