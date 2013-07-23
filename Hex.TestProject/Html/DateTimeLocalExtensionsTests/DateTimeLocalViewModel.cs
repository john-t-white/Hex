using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.TestProject.Html.DateTimeLocalExtensionsTests
{
	public class DateTimeLocalViewModel
	{
		public DateTimeLocalViewModel( string dateTimeLocalAsString )
		{
			this.DateTimeLocalAsString = dateTimeLocalAsString;
		}

		public DateTimeLocalViewModel( DateTime dateTimeLocal )
		{
			this.DateTimeLocal = dateTimeLocal;
		}

		public string DateTimeLocalAsString { get; set; }

		public DateTime DateTimeLocal { get; set; }
	}
}
