using FitAR.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAR.Web.Caching
{

  internal static class CachingDatabaseManager
  {
    public static async Task<List<CachingDatabaseSchema>> Load()
    {
      var tables = ARDirect.Instance.Generator.GetTables();
      var schemas = new List<CachingDatabaseSchema>();
      foreach(var table in tables)
      {
        var schema = (from s in schemas where s.Name.Equals(table.Schema) select s).FirstOrDefault();
        if (schema == null)
        {
          schema = new CachingDatabaseSchema() { Name = table.Schema };
          schemas.Add(schema);
        }

        var t = new CachingDatabaseTable()
        {
          Schema = table.Schema,
          Name = table.TableName
        };
        schema.Tables.Add(t);
        foreach (var column in table.Columns)
          t.Columns.Add(new CachingDatabaseColumn()
          {
            Name = column.Name,
            Type = column.TranslatedType,
            Default = column.Default,
            IsPrimary = column.IsPrimary,
            IsNullable = column.IsNullable
          });
      }
      return schemas;
    }
  }

  // --+----+----+----+----+----+----+----+----+----+----+----+----+----+----+----+----+----+----+----+----+----+----+--
  // MODELS

  public class CachingDatabaseSchema
  {
    public string Name { get; set; }
    public List<CachingDatabaseTable> Tables { get; set; } = new List<CachingDatabaseTable>();
  }

  public class CachingDatabaseTable
  {

    public string Schema { get; set; }
    public string Name { get; set; }
    public List<CachingDatabaseColumn> Columns { get; set; } = new List<CachingDatabaseColumn>();

  }

  public class CachingDatabaseColumn
  {
    public string Name { get; set; }
    public string Type { get; set; }
    public string Default { get; set; }
    public bool IsPrimary { get; set; }
    public bool IsNullable { get; set; }

  }
}
