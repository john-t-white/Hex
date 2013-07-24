using Hex.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Extensions
{
	/// <summary>
	/// Extensions to <see cref="System.DateTime"/>.
	/// </summary>
	public static class DateTimeExtensions
	{
		private const string DATE_FORMAT = "yyyy-MM-ddT";
		private const string MINUTE_TIME_FORMAT = "HH:mm";
		private const string SECOND_TIME_FORMAT = "HH:mm:ss";
		private const string MILLISECOND_TIME_FORMAT = "HH:mm:ss.fff";

		/// <summary>
		/// Returns the appropriate time only format string based on the <see cref="Hex.TimeFormat"/>.
		/// </summary>
		/// <param name="dateTime">The <see cref="System.DateTime"/> instance this method extends.</param>
		/// <param name="timeFormat">The time format.</param>
		/// <returns>The appropriate format string.</returns>
		public static string ToString( this DateTime dateTime, TimeFormat timeFormat )
		{
			return dateTime.ToString( timeFormat, true );
		}

		/// <summary>
		/// Returns the appropriate full date/time format string based on the <see cref="Hex.TimeFormat"/>.  The date format will always be yyyy-MM-ddT.
		/// </summary>
		/// <param name="dateTime">The <see cref="System.DateTime"/> instance this method extends.</param>
		/// <param name="timeFormat">The time format.</param>
		/// <param name="timeOnly">Whether or not the returned format only contains the time or date and time.</param>
		/// <returns>The appropriate format string.</returns>
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
