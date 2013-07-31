using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex.AttributeBuilders
{
	/// <summary>
	/// Provides a fluent way to specify HTML style attribute values.
	/// </summary>
	public class StyleAttributeBuilder
	{
		/// <summary>
		/// Instaniates a new instance of <see cref="Hex.AttributeBuilders.StyleAttributeBuilder"/>.
		/// </summary>
		/// <param name="styles"></param>
		public StyleAttributeBuilder( StyleCollection styles )
		{
			this.Styles = styles;
		}

		/// <summary>
		/// Contains all of the style definitions.
		/// </summary>
		public StyleCollection Styles { get; private set; }

		/// <summary>
		/// Provides a way of adding a style value.
		/// </summary>
		/// <param name="name">The name of the style value.</param>
		/// <param name="value">The style value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.StyleAttributeBuilder"/>.</returns>
		public StyleAttributeBuilder Style( string name, object value )
		{
			if( !string.IsNullOrWhiteSpace( name ) )
			{
				this.Styles[ name ] = value;
			}

			return this;
		}
	}
}
