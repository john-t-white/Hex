using Hex.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hex.Extensions;

namespace Hex.AttributeBuilders
{
	public static class HtmlAttributeBuilder_LinkExtensions
	{
		public static HtmlAttributeBuilder HrefLang( this HtmlAttributeBuilder htmlAttributeBuilder, string languageCode )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.HrefLang ] = languageCode;

			return htmlAttributeBuilder;
		}

		public static HtmlAttributeBuilder Media( this HtmlAttributeBuilder htmlAttributeBuilder, string value )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Media ] = value;

			return htmlAttributeBuilder;
		}

		public static HtmlAttributeBuilder Rel( this HtmlAttributeBuilder htmlAttributeBuilder, RelType rel )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Rel ] = rel.ToLowerString();

			return htmlAttributeBuilder;
		}

		public static HtmlAttributeBuilder Target( this HtmlAttributeBuilder htmlAttributeBuilder, TargetType target )
		{
			return htmlAttributeBuilder.Target( string.Format( "_{0}", target.ToLowerString() ) );
		}

		public static HtmlAttributeBuilder Target( this HtmlAttributeBuilder htmlAttributeBuilder, string target )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Target ] = target;

			return htmlAttributeBuilder;
		}
	}
}
