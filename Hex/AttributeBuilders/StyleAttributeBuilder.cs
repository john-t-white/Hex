using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex.AttributeBuilders
{
	public class StyleAttributeBuilder
	{
		private AttributeNameValueCollection _attributeNameValues;

		public StyleAttributeBuilder( AttributeNameValueCollection attributeNameValues )
		{
			this._attributeNameValues = attributeNameValues;
		}

		public StyleAttributeBuilder Style( string name, object value )
		{
			if( !string.IsNullOrWhiteSpace( name ) )
			{
				this._attributeNameValues[ name ] = value;
			}

			return this;
		}
	}
}
