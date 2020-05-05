using Direct.Types.SQLServer;
using System;

namespace FitAR.Database
{
  public class ARDirect : DirectDatabaseSqlServer
  {
    public ARDirect() 
      : base("fitardb",
          "dbo",
          "Server=tcp:fitarserver.database.windows.net,1433;Initial Catalog=fitardb;Persist Security Info=False;User ID=fitar;Password=#aroot123leksa;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=3000;")
    { }


    public static ARDirect Instance => new ARDirect();

  }
}
