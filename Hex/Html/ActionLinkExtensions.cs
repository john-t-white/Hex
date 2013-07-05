using Hex.AttributeBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Hex.Extensions;

namespace Hex.Html
{
	public static class ActionLinkExtensions
	{
		public static MvcHtmlString ActionLink( this HtmlHelper htmlHelper, string linkText, string actionName, Action<ActionLinkAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ActionLink( linkText, actionName, null, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString ActionLink( this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues, Action<ActionLinkAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ActionLink( linkText, actionName, new RouteValueDictionary( routeValues ), attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString ActionLink( this HtmlHelper htmlHelper, string linkText, string actionName, RouteValueDictionary routeValues, Action<ActionLinkAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ActionLink( linkText, actionName, routeValues, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString ActionLink( this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, Action<ActionLinkAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ActionLink( linkText, actionName, controllerName, null, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString ActionLink( this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues, Action<ActionLinkAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ActionLink( linkText, actionName, controllerName, new RouteValueDictionary( routeValues ), attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString ActionLink( this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues, Action<ActionLinkAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ActionLink( linkText, actionName, controllerName, routeValues, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString ActionLink( this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, Action<ActionLinkAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ActionLink( linkText, actionName, controllerName, protocol, hostName, fragment, null, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString ActionLink( this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, object routeValues, Action<ActionLinkAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ActionLink( linkText, actionName, controllerName, protocol, hostName, fragment, new RouteValueDictionary( routeValues ), attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString ActionLink( this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, Action<ActionLinkAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ActionLink( linkText, actionName, controllerName, protocol, hostName, fragment, routeValues, attributeExpression.GetAttributes() );
		}
	}
}
