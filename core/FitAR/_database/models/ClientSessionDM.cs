using Direct.Models;
using System;

// auto generated 5/5/2020 4:18:08 PM

namespace Direct.Fitardb.Models
{
	public partial class ClientSessionDM : FitardbDirectModel
	{

		public ClientSessionDM() : base("clientSession", "clientSessionID", null){}
		public ClientSessionDM(DirectDatabaseBase db) : base("clientSession", "clientSessionID", db){}
		public override string GetSchemaName() => "auth";

		
		[DColumn(Name = "clientSessionID", IsPrimary=true)]
		public int clientSessionID { get; set; } = default;

		[DColumn(Name = "clientSessionGuid", HasDefaultValue=true)]
		public Guid clientSessionGuid { get; set; } = Guid.NewGuid();

		[DColumn(Name = "clientid")]
		public int clientid { get; set; } = default;

		[DColumn(Name = "duration", HasDefaultValue=true)]
		public double duration { get; set; } = 0.0;

		[DColumn(Name = "updated", HasDefaultValue=true, DateTimeUpdate=true, NotUpdatable=true)]
		public DateTime updated { get; set; } = DateTime.Now;

		[DColumn(Name = "created", HasDefaultValue=true, DateTimeUpdate=true, NotUpdatable=true)]
		public DateTime created { get; set; } = DateTime.Now;


	}
}
