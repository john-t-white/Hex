using Hex.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hex.Extensions;

namespace Hex.AttributeBuilders
{
	/// <summary>
	/// Extension methods for <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/> to provide link-based HTML attributes and their values.
	/// </summary>
	public partial class HtmlAttributeBuilder
	{
		/// <summary>
		/// Represents the HTML attribute "href".
		/// </summary>
		/// <param name="url">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Href( object url )
		{
			this.Attributes[ HtmlAttributes.Href ] = url.ConvertIfUri();

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "hreflang".
		/// </summary>
		/// <param name="languageCode">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder HrefLang( string languageCode )
		{
			this.Attributes[ HtmlAttributes.HrefLang ] = languageCode;

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "media".
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Media( string value )
		{
			this.Attributes[ HtmlAttributes.Media ] = value;

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "rel".
		/// </summary>
		/// <param name="rel">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Rel( RelType rel )
		{
			return this.Rel( rel.ToLowerString() );
		}

		/// <summary>
		/// Represents the HTML attribute "rel".
		/// </summary>
		/// <param name="rel">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Rel( string rel )
		{
			this.Attributes[ HtmlAttributes.Rel ] = rel;

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "target".
		/// </summary>
		/// <param name="target">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Target( TargetType target )
		{
			return this.Target( string.Format( "_{0}", target.ToLowerString() ) );
		}

		/// <summary>
		/// Represents the HTML attribute "target".
		/// </summary>
		/// <param name="target">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Target( string target )
		{
			this.Attributes[ HtmlAttributes.Target ] = target;

			return this;
		}
	}
}
