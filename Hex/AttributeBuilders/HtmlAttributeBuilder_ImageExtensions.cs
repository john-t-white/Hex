using Hex.Html;
using Hex.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.AttributeBuilders
{
	public partial class HtmlAttributeBuilder
	{
		/// <summary>
		/// Represents the HTML attribute "src".
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder CrossOrigin( CrossOriginType value )
		{
			return this.CrossOrigin( value.ToLowerString() );
		}

		/// <summary>
		/// Represents the HTML attribute "src".
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder CrossOrigin( object value )
		{
			this.Attributes[ HtmlAttributes.CrossOrigin ] = value;

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "height".
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Height( object value )
		{
			this.Attributes[ HtmlAttributes.Height ] = value;

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "ismap" with the value of "ismap".
		/// </summary>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder IsMap()
		{
			return this.IsMap( true );
		}

		/// <summary>
		/// Represents the HTML attribute "ismap". True will add the attribute, false will remove the attribute if it has been specified.
		/// </summary>
		/// <param name="isMap">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder IsMap( bool isMap )
		{
			this.Attributes.AddOrRemoveMinimizedAttribute( HtmlAttributes.IsMap, isMap );

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "src".
		/// </summary>
		/// <param name="src">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Src( object src )
		{
			this.Attributes[ HtmlAttributes.Src ] = src.ConvertIfUri();

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "usemap".
		/// </summary>
		/// <param name="mapName">The name of the map.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder UseMap( object mapName )
		{
			this.Attributes[ HtmlAttributes.UseMap ] = mapName;

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "width".
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Width( object value )
		{
			this.Attributes[ HtmlAttributes.Width ] = value;

			return this;
		}
	}
}
