using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Hex
{
	/// <summary>
	/// Contains the collection of attributes and their values.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable" )]
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
	}
}
