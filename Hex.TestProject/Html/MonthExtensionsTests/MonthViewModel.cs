using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.TestProject.Html.MonthExtensionsTests
{
	public class MonthViewModel
	{
		public MonthViewModel( string monthAsString )
		{
			this.MonthAsString = monthAsString;
		}

		public MonthViewModel( DateTime month )
		{
			this.Month = month;
		}

		public string MonthAsString { get; set; }

		public DateTime Month { get; set; }
	}
}
