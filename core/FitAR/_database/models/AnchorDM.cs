using Direct.Models;
using System;

// auto generated 5/16/2020 10:59:09 PM

namespace Direct.Fitardb.Models
{
	public partial class AnchorDM : FitardbDirectModel
	{

		public AnchorDM() : base("anchor", "anchorid", null){}
		public AnchorDM(DirectDatabaseBase db) : base("anchor", "anchorid", db){}
		public override string GetSchemaName() => "core";

		
		[DColumn(Name = "anchorid", IsPrimary=true)]
		public int anchorid { get; set; } = default;

		[DColumn(Name = "clientid")]
		public int clientid { get; set; } = default;

		[DColumn(Name = "clientsessionid")]
		public int clientsessionid { get; set; } = default;

		[DColumn(Name = "sessionid")]
		public string sessionid { get; set; } = default;

		[DColumn(Name = "noteText")]
		public string noteText { get; set; } = default;

		[DColumn(Name = "lat")]
		public double lat { get; set; } = default;

		[DColumn(Name = "lng")]
		public double lng { get; set; } = default;

		[DColumn(Name = "updated", HasDefaultValue=true, DateTimeUpdate=true, NotUpdatable=true)]
		public DateTime updated { get; set; } = DateTime.Now;

		[DColumn(Name = "created", HasDefaultValue=true, NotUpdatable=true)]
		public DateTime created { get; set; } = DateTime.Now;


	}
}
