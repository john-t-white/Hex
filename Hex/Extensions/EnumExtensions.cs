using System;

namespace Hex.Extensions
{
	public static class EnumExtensions
	{
		public static string ToLowerString( this Enum enumeration )
		{
			return enumeration.ToString().ToLower();
		}
	}
}