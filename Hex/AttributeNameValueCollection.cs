using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex
{
	public class AttributeNameValueCollection
		: Dictionary<string, object>
	{
		public override string ToString()
		{
			var attributeValues = ( from currentValue in this
									select string.Format( "{0}:{1}", currentValue.Key, currentValue.Value ) )
									.ToArray();

			return string.Join( ";", attributeValues );
		}
	}
}
