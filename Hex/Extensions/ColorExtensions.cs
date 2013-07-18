using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Hex.Extensions
{
	/// <summary>
	/// Extensions to <see cref="System.Drawing.Color"/>.
	/// </summary>
	public static class ColorExtensions
	{
		private const string COLOR_PATTERN = "#{0:X2}{1:X2}{2:X2}";

		/// <summary>
		/// Returns the HTML RGB color.
		/// </summary>
		/// <param name="color">The <see cref="System.Drawing.Color"/> instance that this method extends.</param>
		/// <returns>The HTML RGB color.</returns>
		public static string ToHexadecimal( this Color color )
		{
			return string.Format( COLOR_PATTERN, color.R, color.G, color.B );
		}
	}
}
