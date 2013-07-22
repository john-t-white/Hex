using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Hex.TestProject.Html.ColorExtensionsTests
{
	public class ColorViewModel
	{
		public ColorViewModel( string colorAsString )
		{
			this.ColorAsString = colorAsString;
		}

		public ColorViewModel( Color color )
		{
			this.Color = color;
		}

		public string ColorAsString { get; set; }

		public Color Color { get; set; }
	}
}
