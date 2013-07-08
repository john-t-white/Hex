using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex
{
	/// <summary>
	/// Contains multiple values for one attribute.
	/// </summary>
	public class AttributeValueCollection
		: ArrayList
	{
		/// <summary>
		/// Returns a space separated string of the values.
		/// </summary>
		/// <returns>A space separated string of the values.</returns>
		public override string ToString()
		{
			var values = ( from string currentValue in this
						   select Convert.ToString( currentValue ) )
						  .ToArray();

			return string.Join( " ", values );
		}
	}
}
