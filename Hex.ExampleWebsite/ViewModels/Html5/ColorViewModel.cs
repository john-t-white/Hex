using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Hex.ExampleWebsite.ViewModels.Html5
{
	public class ColorViewModel
	{
		public string ColorAsString { get; set; }

		public Color Color { get; set; }

		public Color? NullableColor { get; set; }
	}
}