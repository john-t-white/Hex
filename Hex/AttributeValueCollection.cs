using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex
{
	public class AttributeValueCollection
		: ArrayList
	{
		public override string ToString()
		{
			var values = ( from string currentValue in this
						   select Convert.ToString( currentValue ) )
						  .ToArray();

			return string.Join( " ", values );
		}
	}
}
