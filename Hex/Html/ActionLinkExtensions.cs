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
	/// <summary>
	/// Represents support for HTML links in an application with an expression for specifying HTML attributes.
	/// </summary>
	public static class ActionLinkExtensions
	{
		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified location.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="actionName">The name of the action.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element (a element).</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString ActionLink( this HtmlHelper htmlHelper, string linkText, string actionName, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ActionLink( linkText, actionName, null, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified location.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="actionName">The name of the action.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route. The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		///	</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element (a element).</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString ActionLink( this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ActionLink( linkText, actionName, new RouteValueDictionary( routeValues ), attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified location.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="actionName">The name of the action.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element (a element).</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString ActionLink( this HtmlHelper htmlHelper, string linkText, string actionName, RouteValueDictionary routeValues, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ActionLink( linkText, actionName, routeValues, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified location.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="actionName">The name of the action.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element (a element).</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString ActionLink( this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ActionLink( linkText, actionName, controllerName, null, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified location.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="actionName">The name of the action.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route. The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element (a element).</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString ActionLink( this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ActionLink( linkText, actionName, controllerName, new RouteValueDictionary( routeValues ), attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified location.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="actionName">The name of the action.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element (a element).</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString ActionLink( this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ActionLink( linkText, actionName, controllerName, routeValues, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified location.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="actionName">The name of the action.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
		/// <param name="hostName">The host name for the URL.</param>
		/// <param name="fragment">The URL fragment name (the anchor name).</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element (a element).</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString ActionLink( this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ActionLink( linkText, actionName, controllerName, protocol, hostName, fragment, null, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified location.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="actionName">The name of the action.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
		/// <param name="hostName">The host name for the URL.</param>
		/// <param name="fragment">The URL fragment name (the anchor name).</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route. The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element (a element).</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString ActionLink( this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, object routeValues, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ActionLink( linkText, actionName, controllerName, protocol, hostName, fragment, new RouteValueDictionary( routeValues ), attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified location.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="actionName">The name of the action.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
		/// <param name="hostName">The host name for the URL.</param>
		/// <param name="fragment">The URL fragment name (the anchor name).</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element (a element).</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString ActionLink( this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ActionLink( linkText, actionName, controllerName, protocol, hostName, fragment, routeValues, attributeExpression.GetAttributes() );
		}
	}
}
