using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Hex.ExampleWebsite.ViewModels
{
	public class NumberViewModel
	{
		public int Number { get; set; }

		public int? NullableNumber { get; set; }

		public string NumberAsString { get; set; }
	}
}