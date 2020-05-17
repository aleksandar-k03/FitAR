using Direct.Models;
using System;

// auto generated 5/16/2020 10:59:09 PM

namespace Direct.Fitardb.Models
{
  public abstract class FitardbDirectModel : DirectModel
  {
    public FitardbDirectModel(string tableName, string id_name, DirectDatabaseBase db) : base(tableName, id_name, db) { }
    public override DirectDatabaseType DatabaseType => DirectDatabaseType.SQLServer;
    protected override DirectDatabaseBase DatabaseReference => new FitAR.Database.ARDirect();
  }
}
