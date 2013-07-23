using Hex.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Extensions
{
	/// <summary>
	/// Extensions to <see cref="Hex.Html.TimeFormat"/>.
	/// </summary>
	public static class TimeFormatExtensions
	{
		/// <summary>
		/// Gets the appropriate HTML attribute step value based on the <see cref="Hex.Html.TimeFormat"/>.
		/// If <see cref="Hex.Html.TimeFormat.Minute"/> is specified, null is returned because that is the default value.
		/// </summary>
		/// <param name="timeFormat">The <see cref="Hex.Html.TimeFormat"/> instance this method extends.</param>
		/// <returns>The appropriate HTML attribute step value.</returns>
		public static double? GetStepValue( this TimeFormat timeFormat )
		{
			switch( timeFormat )
			{
				case TimeFormat.Second:
					return 1;

				case TimeFormat.Millisecond:
					return .001;

				default:
					return null;
			}
		}
	}
}
