﻿using Hex.AttributeBuilders;
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
	/// <summary>
	/// Represents support for HTML links in an application with an expression for specifying HTML attributes.
	/// </summary>
	public static class RouteLinkExtensions
	{
		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified action.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element (a element).</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString RouteLink( this HtmlHelper htmlHelper, string linkText, object routeValues, Action<RouteLinkAttributeBuilder> attributeExpression )
		{
			return htmlHelper.RouteLink( linkText, new RouteValueDictionary( routeValues ), attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified action.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element (a element).</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString RouteLink( this HtmlHelper htmlHelper, string linkText, RouteValueDictionary routeValues, Action<RouteLinkAttributeBuilder> attributeExpression )
		{
			return htmlHelper.RouteLink( linkText, routeValues, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified action.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="routeName">The name of the route that is used to return a virtual path.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element (a element).</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString RouteLink( this HtmlHelper htmlHelper, string linkText, string routeName, Action<RouteLinkAttributeBuilder> attributeExpression )
		{
			return htmlHelper.RouteLink( linkText, routeName, null, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified action.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="routeName">The name of the route that is used to return a virtual path.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element (a element).</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString RouteLink( this HtmlHelper htmlHelper, string linkText, string routeName, object routeValues, Action<RouteLinkAttributeBuilder> attributeExpression )
		{
			return htmlHelper.RouteLink( linkText, routeName, new RouteValueDictionary( routeValues ), attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified action.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="routeName">The name of the route that is used to return a virtual path.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element (a element).</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString RouteLink( this HtmlHelper htmlHelper, string linkText, string routeName, RouteValueDictionary routeValues, Action<RouteLinkAttributeBuilder> attributeExpression )
		{
			return htmlHelper.RouteLink( linkText, routeName, routeValues, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified action.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="routeName">The name of the route that is used to return a virtual path.</param>
		/// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
		/// <param name="hostName">The host name for the URL.</param>
		/// <param name="fragment">The URL fragment name (the anchor name).</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element (a element).</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString RouteLink( this HtmlHelper htmlHelper, string linkText, string routeName, string protocol, string hostName, string fragment, Action<RouteLinkAttributeBuilder> attributeExpression )
		{
			return htmlHelper.RouteLink( linkText, routeName, protocol, hostName, fragment, null, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified action.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="routeName">The name of the route that is used to return a virtual path.</param>
		/// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
		/// <param name="hostName">The host name for the URL.</param>
		/// <param name="fragment">The URL fragment name (the anchor name).</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element (a element).</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString RouteLink( this HtmlHelper htmlHelper, string linkText, string routeName, string protocol, string hostName, string fragment, object routeValues, Action<RouteLinkAttributeBuilder> attributeExpression )
		{
			return htmlHelper.RouteLink( linkText, routeName, protocol, hostName, fragment, new RouteValueDictionary( routeValues ), attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an anchor element (a element) that contains the virtual path of the specified action.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="routeName">The name of the route that is used to return a virtual path.</param>
		/// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
		/// <param name="hostName">The host name for the URL.</param>
		/// <param name="fragment">The URL fragment name (the anchor name).</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element (a element).</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString RouteLink( this HtmlHelper htmlHelper, string linkText, string routeName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, Action<RouteLinkAttributeBuilder> attributeExpression )
		{
			return htmlHelper.RouteLink( linkText, routeName, protocol, hostName, fragment, routeValues, attributeExpression.GetAttributes() );
		}
	}
}
