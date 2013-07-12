using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Hex.Extensions
{
	public static class ColorExtensions
	{
		private const string COLOR_PATTERN = "#{0:X2}{1:X2}{2:X2}";

		public static string ToHtml( this Color color )
		{
			return string.Format( COLOR_PATTERN, color.R, color.G, color.B );
		}
	}
}
