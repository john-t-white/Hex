using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Hex.ExampleWebsite.ViewModels
{
	public class DateViewModel
	{
		public string DateAsString { get; set; }

		public DateTime Date { get; set; }

		public DateTime? NullableDate { get; set; }
	}
}