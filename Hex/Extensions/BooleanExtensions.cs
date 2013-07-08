using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex.Extensions
{
	/// <summary>
	/// Extensions to <see cref="System.Boolean"/>.
	/// </summary>
	public static class BooleanExtensions
	{
		/// <summary>
		/// Returns the string representation of boolean in lower case.
		/// </summary>
		/// <param name="boolean">The instance of <see cref="System.Boolean"/> that is being extended.</param>
		/// <returns>Either "true" or "false".</returns>
		public static string ToLowerString( this bool boolean )
		{
			return boolean.ToString().ToLower();
		}
	}
}
