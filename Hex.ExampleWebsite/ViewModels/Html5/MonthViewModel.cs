using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Hex.ExampleWebsite.ViewModels.Html5
{
	public class MonthViewModel
	{
		public string MonthAsString { get; set; }

		public DateTime Month { get; set; }

		public DateTime? NullableMonth { get; set; }
	}
}