using System;

namespace Hex.Extensions
{
	/// <summary>
	/// Extensions to <see cref="System.Enum"/>.
	/// </summary>
	public static class EnumExtensions
	{
		/// <summary>
		/// Returns the string representation of the enumeration value in lower case.
		/// </summary>
		/// <param name="enumeration">The instance of <see cref="System.Enum"/> that is being extended.</param>
		/// <returns>The lower case string of the enumeration value.</returns>
		public static string ToLowerString( this Enum enumeration )
		{
			return enumeration.ToString().ToLower().Replace( '_', '-' );
		}
	}
}