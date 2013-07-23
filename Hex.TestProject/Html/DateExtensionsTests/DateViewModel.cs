using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.TestProject.Html.DateExtensionsTests
{
	public class DateViewModel
	{
		public DateViewModel( string dateAsString )
		{
			this.DateAsString = dateAsString;
		}

		public DateViewModel( DateTime date )
		{
			this.Date = date;
		}

		public string DateAsString { get; set; }

		public DateTime Date { get; set; }
	}
}
