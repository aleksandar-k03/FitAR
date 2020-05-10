using Direct.Models;
using System;

// auto generated 5/10/2020 9:17:58 PM

namespace Direct.Fitardb.Models
{
	public partial class TypeDM : FitardbDirectModel
	{

		public TypeDM() : base("type", "typeid", null){}
		public TypeDM(DirectDatabaseBase db) : base("type", "typeid", db){}
		public override string GetSchemaName() => "text";

		
		[DColumn(Name = "typeid", IsPrimary=true)]
		public int typeid { get; set; } = default;

		[DColumn(Name = "name")]
		public string name { get; set; } = default;

		[DColumn(Name = "updated", HasDefaultValue=true, DateTimeUpdate=true, NotUpdatable=true)]
		public DateTime updated { get; set; } = DateTime.Now;

		[DColumn(Name = "created", HasDefaultValue=true, DateTimeUpdate=true, NotUpdatable=true)]
		public DateTime created { get; set; } = DateTime.Now;


	}
}
