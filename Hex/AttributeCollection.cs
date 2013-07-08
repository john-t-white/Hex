using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex
{
	/// <summary>
	/// Contains the collection of attributes and their values.
	/// </summary>
	public class AttributeCollection : Dictionary<string, object>
	{
		/// <summary>
		/// Support for adding an attribute that supports minimization.
		/// </summary>
		/// <param name="attributeName">The name of the attribute.</param>
		/// <param name="value">true adds the attribute with support for XHTML; false removes the attribute.</param>
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

		/// <summary>
		/// Retrieves an attribute value cast to the specified type.  If the attribute doesn't exist in the collection, the default value of <typeparamref name="TAttributeValue"/> is returned."
		/// </summary>
		/// <typeparam name="TAttributeValue">The type of attribute value.</typeparam>
		/// <param name="key">The name of the attribute.</param>
		/// <returns>The attribute value, otherwise the default value of <typeparamref name="TAttributeValue"/> is returned.</returns>
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
