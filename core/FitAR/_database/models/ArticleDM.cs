using Direct.Models;
using System;

// auto generated 5/5/2020 4:18:08 PM

namespace Direct.Fitardb.Models
{
	public partial class ArticleDM : FitardbDirectModel
	{

		public ArticleDM() : base("article", "articleid", null){}
		public ArticleDM(DirectDatabaseBase db) : base("article", "articleid", db){}
		public override string GetSchemaName() => "text";

		
		[DColumn(Name = "articleid", IsPrimary=true)]
		public int articleid { get; set; } = default;

		[DColumn(Name = "fallbackid", Nullable=true)]
		public int? fallbackid { get; set; } = null;

		[DColumn(Name = "typeid")]
		public int typeid { get; set; } = default;

		[DColumn(Name = "title", Nullable=true)]
		public string title { get; set; } = default;

		[DColumn(Name = "html", Nullable=true)]
		public string html { get; set; } = default;

		[DColumn(Name = "updated", HasDefaultValue=true, DateTimeUpdate=true, NotUpdatable=true)]
		public DateTime updated { get; set; } = DateTime.Now;

		[DColumn(Name = "created", HasDefaultValue=true, DateTimeUpdate=true, NotUpdatable=true)]
		public DateTime created { get; set; } = DateTime.Now;


	}
}
