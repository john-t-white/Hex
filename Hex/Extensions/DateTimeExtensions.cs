using Hex.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Extensions
{
	public static class DateTimeExtensions
	{
		private const string DATE_FORMAT = "yyyy-MM-ddT";
		private const string MINUTE_TIME_FORMAT = "HH:mm";
		private const string SECOND_TIME_FORMAT = "HH:mm:ss";
		private const string MILLISECOND_TIME_FORMAT = "HH:mm:ss.fff";

		public static string ToString( this DateTime dateTime, TimeFormat timeFormat, bool timeOnly )
		{
			string timeFormatString;
			switch( timeFormat )
			{
				case TimeFormat.Second:
					timeFormatString = SECOND_TIME_FORMAT;
					break;

				case TimeFormat.Millisecond:
					timeFormatString = MILLISECOND_TIME_FORMAT;
					break;

				default:
					timeFormatString = MINUTE_TIME_FORMAT;
					break;
			}

			return ( timeOnly ) ? dateTime.ToString( timeFormatString ) : dateTime.ToString( string.Format( "{0}{1}", DATE_FORMAT, timeFormatString ) );
		}
	}
}
