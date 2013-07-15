using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Hex.ExampleWebsite.ViewModels
{
	public class TimeViewModel
	{
		public string TimeAsString { get; set; }

		public DateTime Time { get; set; }

		public DateTime? NullableTime { get; set; }
	}
}