using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex
{
	/// <summary>
	/// Contains a collection of name/value pairs for an attribute.
	/// </summary>
	public class AttributeNameValueCollection
		: Dictionary<string, object>
	{

		/// <summary>
		/// Returns a semi-color separated string with the name/value separated by a colon.
		/// </summary>
		/// <returns>A semi-color separated string with the name/value separated by a colon.</returns>
		public override string ToString()
		{
			var attributeValues = ( from currentValue in this
									select string.Format( "{0}:{1}", currentValue.Key, currentValue.Value ) )
									.ToArray();

			return string.Join( ";", attributeValues );
		}
	}
}
