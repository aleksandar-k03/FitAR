using Direct.Models;
using System;

// auto generated 5/1/2020 11:09:42 PM

namespace Direct.Fitardb.Models
{
	public partial class TestTable1DM : FitardbDirectModel
	{

		public TestTable1DM() : base("TestTable1", "TestTable1ID", null){}
		public TestTable1DM(DirectDatabaseBase db) : base("TestTable1", "TestTable1ID", db){}
		public override string GetSchemaName() => "core";

		
		[DColumn(Name = "TestTable1ID", IsPrimary=true)]
		public int TestTable1ID { get; set; } = default;

		[DColumn(Name = "Input", Nullable=true)]
		public string Input { get; set; } = default;

		[DColumn(Name = "Updated", HasDefaultValue=true, Nullable=true)]
		public DateTime? Updated { get; set; } = DateTime.Now;

		[DColumn(Name = "Created", HasDefaultValue=true, Nullable=true)]
		public DateTime? Created { get; set; } = DateTime.Now;

		[DColumn(Name = "Decimal", HasDefaultValue=true, Nullable=true)]
		public double? Decimal { get; set; } = 0.0;

		[DColumn(Name = "IsBla", HasDefaultValue=true, Nullable=true)]
		public bool? IsBla { get; set; } = false;

		[DColumn(Name = "GuidBla", Nullable=true)]
		public Guid? GuidBla { get; set; } = null;


	}
}
