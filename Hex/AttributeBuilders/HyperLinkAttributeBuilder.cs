using Hex.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hex.Extensions;

namespace Hex.AttributeBuilders
{
	public abstract class HyperLinkAttributeBuilder<TSelf>
		: HtmlAttributeBuilder<TSelf>
		where TSelf : HyperLinkAttributeBuilder<TSelf>, new()
	{
		public TSelf HrefLang( string languageCode )
		{
			this.Attributes[ HtmlAttributes.HrefLang ] = languageCode;

			return ( TSelf )this;
		}

		public TSelf Media( string value )
		{
			this.Attributes[ HtmlAttributes.Media ] = value;

			return ( TSelf )this;
		}

		public TSelf Rel( RelType rel )
		{
			this.Attributes[ HtmlAttributes.Rel ] = rel.ToLowerString();

			return ( TSelf )this;
		}

		public TSelf Target( TargetType target )
		{
			return this.Target( string.Format( "_{0}", target.ToLowerString() ) );
		}

		public TSelf Target( string target )
		{
			this.Attributes[ HtmlAttributes.Target ] = target;

			return ( TSelf )this;
		}

		public TSelf Type( string mimeType )
		{
			this.Attributes[ HtmlAttributes.Type ] = mimeType;

			return ( TSelf )this;
		}
	}
}
