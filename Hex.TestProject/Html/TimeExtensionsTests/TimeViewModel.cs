using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.TestProject.Html.TimeExtensionsTests
{
	public class TimeViewModel
	{
		public TimeViewModel( string timeAsString )
		{
			this.TimeAsString = timeAsString;
		}

		public TimeViewModel( DateTime time )
		{
			this.Time = time;
		}

		public string TimeAsString { get; set; }

		public DateTime Time { get; set; }
	}
}
