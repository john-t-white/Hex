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
	/// <summary>
	/// Represents support for specifying HTML attributes at anytime.
	/// </summary>
	public static class AttributesExtensions
	{
		/// <summary>
		/// Returns a string of HTML attributes with the specified values.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>A string of HTML attributes with the specified values.</returns>
		public static MvcHtmlString Attributes( this HtmlHelper htmlHelper, object htmlAttributes )
		{
			return htmlHelper.Attributes( HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Returns a string of HTML attributes with the specified values.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>A string of HTML attributes with the specified values.</returns>
		public static MvcHtmlString Attributes( this HtmlHelper htmlHelper, IDictionary<string, object> htmlAttributes )
		{
			if( htmlAttributes == null )
			{
				return MvcHtmlString.Empty;
			}

			return MvcHtmlString.Create( htmlAttributes.ToHtmlAttributeString() );
		}

		/// <summary>
		/// Returns a string of HTML attributes with the specified values.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>A string of HTML attributes with the specified values.</returns>
		public static MvcHtmlString Attributes( this HtmlHelper htmlHelper, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.Attributes( attributeExpression.GetAttributes() );
		}
	}
}
