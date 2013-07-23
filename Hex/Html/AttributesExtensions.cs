using Hex.AttributeBuilders;
using Hex.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hex.Html
{
	public static class AttributesExtensions
	{
		public static MvcHtmlString Attributes( this HtmlHelper htmlHelper, object htmlAttributes )
		{
			return htmlHelper.Attributes( new RouteValueDictionary( htmlAttributes ) );
		}

		public static MvcHtmlString Attributes( this HtmlHelper htmlHelper, IDictionary<string, object> htmlAttributes )
		{
			if( htmlAttributes == null )
			{
				return MvcHtmlString.Empty;
			}

			var attributeValues = ( from currentValue in htmlAttributes
									select string.Format( "{0}=\"{1}\"", currentValue.Key, htmlHelper.AttributeEncode( currentValue.Value ) ) )
									.ToArray();

			return MvcHtmlString.Create( string.Join( " ", attributeValues ) );
		}

		public static MvcHtmlString Attributes( this HtmlHelper htmlHelper, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.Attributes( attributeExpression.GetAttributes() );
		}
	}
}
