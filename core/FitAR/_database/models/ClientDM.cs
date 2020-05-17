using Direct.Models;
using System;

// auto generated 5/16/2020 10:59:09 PM

namespace Direct.Fitardb.Models
{
	public partial class ClientDM : FitardbDirectModel
	{

		public ClientDM() : base("client", "clientid", null){}
		public ClientDM(DirectDatabaseBase db) : base("client", "clientid", db){}
		public override string GetSchemaName() => "auth";

		
		[DColumn(Name = "clientid", IsPrimary=true)]
		public int clientid { get; set; } = default;

		[DColumn(Name = "username")]
		public string username { get; set; } = default;

		[DColumn(Name = "password")]
		public string password { get; set; } = default;

		[DColumn(Name = "firstName", Nullable=true)]
		public string firstName { get; set; } = default;

		[DColumn(Name = "lastName", Nullable=true)]
		public string lastName { get; set; } = default;

		[DColumn(Name = "profilePic", HasDefaultValue=true)]
		public string profilePic { get; set; } = "'https://paywall.blob.core.windows.net/aco/defaultProfilePic.png'";

		[DColumn(Name = "additional", Nullable=true)]
		public string additional { get; set; } = default;

		[DColumn(Name = "isAdmin", HasDefaultValue=true)]
		public bool isAdmin { get; set; } = false;

		[DColumn(Name = "updated", HasDefaultValue=true, DateTimeUpdate=true, NotUpdatable=true)]
		public DateTime updated { get; set; } = DateTime.Now;

		[DColumn(Name = "created", HasDefaultValue=true, NotUpdatable=true)]
		public DateTime created { get; set; } = DateTime.Now;


	}
}
