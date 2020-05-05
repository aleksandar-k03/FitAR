using Direct.Models;
using System;

// auto generated 5/1/2020 11:09:42 PM

namespace Direct.Fitardb.Models
{
	public partial class TestTableBabyDM : FitardbDirectModel
	{

		public TestTableBabyDM() : base("TestTableBaby", "TestID", null){}
		public TestTableBabyDM(DirectDatabaseBase db) : base("TestTableBaby", "TestID", db){}
		public override string GetSchemaName() => "dbo";

		
		[DColumn(Name = "TestID", IsPrimary=true)]
		public int TestID { get; set; } = default;

		[DColumn(Name = "IsThisSomething")]
		public bool IsThisSomething { get; set; } = default;

		[DColumn(Name = "IntegerValue")]
		public int IntegerValue { get; set; } = default;

		[DColumn(Name = "Updated", HasDefaultValue=true, Nullable=true)]
		public DateTime? Updated { get; set; } = DateTime.Now;

		[DColumn(Name = "Created", HasDefaultValue=true, Nullable=true)]
		public DateTime? Created { get; set; } = DateTime.Now;


	}
}
