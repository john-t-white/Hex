using Hex.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Extensions
{
	public static class TimeFormatExtensions
	{
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
