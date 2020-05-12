using Direct.Models;
using System;

// auto generated 5/10/2020 9:17:58 PM

namespace Direct.Fitardb.Models
{
	public partial class ClientDM : FitardbDirectModel
  {

    public DateTime? LastLogin()
    {
      return this.GetDatabase().LoadDateTime(string.Format(@"SELECT TOP 1 s.created FROM auth.client as client
LEFT OUTER JOIN auth.clientSession AS s ON s.clientid=client.clientid
WHERE client.clientid={0}
ORDER BY s.created DESC
", this.ID.Value));
    }

  }
}
