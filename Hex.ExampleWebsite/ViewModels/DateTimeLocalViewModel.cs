using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Hex.ExampleWebsite.ViewModels
{
	public class DateTimeLocalViewModel
	{
		public string DateTimeLocalAsString { get; set; }

		public DateTime DateTimeLocal { get; set; }

		public DateTime? NullableDateTimeLocal { get; set; }
	}
}