using Hex.Html;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Hex.Extensions
{
	public static class ObjectExtensions
	{
		public static object ConvertIfColor( this object obj )
		{
			if( obj is Color )
			{
				return ( ( Color )obj ).ToHexadecimal();
			}

			return obj;
		}

		public static object ConvertIfDateTime( this object obj, string format )
		{
			if( obj is DateTime )
			{
				return ( ( DateTime )obj ).ToString( format );
			}

			return obj;
		}

		public static object ConvertIfDateTime( this object obj, TimeFormat timeFormat, bool timeOnly )
		{
			if( obj is DateTime )
			{
				return ( ( DateTime )obj ).ToString( timeFormat, timeOnly );
			}

			return obj;
		}

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
