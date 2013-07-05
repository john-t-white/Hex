using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex
{
	public class AttributeCollection : Dictionary<string, object>
	{
		public void AddOrRemoveMinimizedAttribute( string attributeName, bool value )
		{
			if (!value)
			{
				this.Remove( attributeName );
			}
			else
			{
				this[ attributeName ] = attributeName;
			}
		}

		public TAttributeValue GetAttributeValue<TAttributeValue>( string key )
		{
			object attributeValue;
			if( !this.TryGetValue( key, out attributeValue ) )
			{
				return default( TAttributeValue );
			}

			return ( TAttributeValue )attributeValue;
		}
	}
}
