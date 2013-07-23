using Hex.Html;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Hex.Extensions
{
	/// <summary>
	/// Extensions to <see cref="System.Object"/>.
	/// </summary>
	public static class ObjectExtensions
	{
		/// <summary>
		/// Will convert a <see cref="System.Drawing.Color"/> to hexadecimal, otherwise it will return the object passed in.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object"/> instance this method extends.</param>
		/// <returns>A color in hexadecimal, otherwise it will return the object passed in.</returns>
		public static object ConvertIfColor( this object obj )
		{
			if( obj is Color )
			{
				return ( ( Color )obj ).ToHexadecimal();
			}

			return obj;
		}

		/// <summary>
		/// Will convert a <see cref="System.DateTime"/> to format specified, otherwise it will return the object passed in.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object"/> instance this method extends.</param>
		/// <param name="format">The format of the <see cref="System.DateTime"/>.</param>
		/// <returns>A formatted <see cref="System.DateTime"/>, otherwise it will return the object passed in.</returns>
		public static object ConvertIfDateTime( this object obj, string format )
		{
			if( obj is DateTime )
			{
				return ( ( DateTime )obj ).ToString( format );
			}

			return obj;
		}

		/// <summary>
		/// Will convert a <see cref="System.DateTime"/> using the format based on <see cref="Hex.Html.TimeFormat"/>, otherwise it will return the object passed in.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object"/> instance this method extends.</param>
		/// <param name="timeFormat">The time format.</param>
		/// <returns>A formatted <see cref="System.DateTime"/>, otherwise it will return the object passed in.</returns>
		public static object ConvertIfDateTime( this object obj, TimeFormat timeFormat )
		{
			if( obj is DateTime )
			{
				return ( ( DateTime )obj ).ToString( timeFormat );
			}

			return obj;
		}

		/// <summary>
		/// Will convert a <see cref="System.DateTime"/> using the format based on <see cref="Hex.Html.TimeFormat"/>, otherwise it will return the object passed in.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object"/> instance this method extends.</param>
		/// <param name="timeFormat">The time format.</param>
		/// <param name="timeOnly">Whether the result should only be time or date and time.</param>
		/// <returns>A formatted <see cref="System.DateTime"/>, otherwise it will return the object passed in.</returns>
		public static object ConvertIfDateTime( this object obj, TimeFormat timeFormat, bool timeOnly )
		{
			if( obj is DateTime )
			{
				return ( ( DateTime )obj ).ToString( timeFormat, timeOnly );
			}

			return obj;
		}

		/// <summary>
		/// Will convert a <see cref="System.Uri"/> to a string, otherwise it will return the object passed in.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object"/> instance this method extends.</param>
		/// <returns>A <see cref="System.Uri"/> as a string, otherwise it will return the object passed in.</returns>
		public static object ConvertIfUri( this object obj )
		{
			if( obj is Uri )
			{
				return ( ( Uri )obj ).OriginalString;
			}

			return obj;
		}
	}
}
