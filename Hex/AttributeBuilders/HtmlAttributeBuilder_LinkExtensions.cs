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
	public static class HtmlAttributeBuilder_LinkExtensions
	{
		/// <summary>
		/// Represents the HTML attribute "hreflang".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="languageCode">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder HrefLang( this HtmlAttributeBuilder htmlAttributeBuilder, string languageCode )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.HrefLang ] = languageCode;

			return htmlAttributeBuilder;
		}

		/// <summary>
		/// Represents the HTML attribute "media".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="value">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder Media( this HtmlAttributeBuilder htmlAttributeBuilder, string value )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Media ] = value;

			return htmlAttributeBuilder;
		}

		/// <summary>
		/// Represents the HTML attribute "rel".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="rel">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder Rel( this HtmlAttributeBuilder htmlAttributeBuilder, RelType rel )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Rel ] = rel.ToLowerString();

			return htmlAttributeBuilder;
		}

		/// <summary>
		/// Represents the HTML attribute "target".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="target">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder Target( this HtmlAttributeBuilder htmlAttributeBuilder, TargetType target )
		{
			return htmlAttributeBuilder.Target( string.Format( "_{0}", target.ToLowerString() ) );
		}

		/// <summary>
		/// Represents the HTML attribute "target".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="target">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder Target( this HtmlAttributeBuilder htmlAttributeBuilder, string target )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Target ] = target;

			return htmlAttributeBuilder;
		}
	}
}
