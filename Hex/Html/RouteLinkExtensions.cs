using Hex.AttributeBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Hex.Extensions;
using System.Web.Routing;

namespace Hex.Html
{
	public static class RouteLinkExtensions
	{
		public static MvcHtmlString RouteLink( this HtmlHelper htmlHelper, string linkText, Action<RouteLinkAttributeBuilder> attributeExpression )
		{
			return htmlHelper.RouteLink( linkText, null, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString RouteLink( this HtmlHelper htmlHelper, string linkText, object routeValues, Action<RouteLinkAttributeBuilder> attributeExpression )
		{
			return htmlHelper.RouteLink( linkText, new RouteValueDictionary( routeValues ), attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString RouteLink( this HtmlHelper htmlHelper, string linkText, RouteValueDictionary routeValues, Action<RouteLinkAttributeBuilder> attributeExpression )
		{
			return htmlHelper.RouteLink( linkText, routeValues, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString RouteLink( this HtmlHelper htmlHelper, string linkText, string routeName, Action<RouteLinkAttributeBuilder> attributeExpression )
		{
			return htmlHelper.RouteLink( linkText, routeName, null, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString RouteLink( this HtmlHelper htmlHelper, string linkText, string routeName, object routeValues, Action<RouteLinkAttributeBuilder> attributeExpression )
		{
			return htmlHelper.RouteLink( linkText, routeName, new RouteValueDictionary( routeValues ), attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString RouteLink( this HtmlHelper htmlHelper, string linkText, string routeName, RouteValueDictionary routeValues, Action<RouteLinkAttributeBuilder> attributeExpression )
		{
			return htmlHelper.RouteLink( linkText, routeName, routeValues, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString RouteLink( this HtmlHelper htmlHelper, string linkText, string routeName, string protocol, string hostName, string fragment, Action<RouteLinkAttributeBuilder> attributeExpression )
		{
			return htmlHelper.RouteLink( linkText, routeName, protocol, hostName, fragment, null, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString RouteLink( this HtmlHelper htmlHelper, string linkText, string routeName, string protocol, string hostName, string fragment, object routeValues, Action<RouteLinkAttributeBuilder> attributeExpression )
		{
			return htmlHelper.RouteLink( linkText, routeName, protocol, hostName, fragment, new RouteValueDictionary( routeValues ), attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString RouteLink( this HtmlHelper htmlHelper, string linkText, string routeName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, Action<RouteLinkAttributeBuilder> attributeExpression )
		{
			return htmlHelper.RouteLink( linkText, routeName, protocol, hostName, fragment, routeValues, attributeExpression.GetAttributes() );
		}
	}
}
