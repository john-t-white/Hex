using Hex.AttributeBuilders;
using Hex.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Routing;

namespace Hex.Ajax
{
	/// <summary>
	/// Represents support for ASP.NET AJAX route links within an ASP.NET MVC application with an expression for specifying HTML attributes.
	/// </summary>
	public static class RouteLinkExtensions
	{
		/// <summary>
		/// Returns an anchor element that contains the virtual path for the specified route values; when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		This object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString RouteLink( this AjaxHelper ajaxHelper, string linkText, object routeValues, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.RouteLink( linkText, null, new RouteValueDictionary( routeValues ), ajaxOptions, attributeExpression );
		}

		/// <summary>
		/// Returns an anchor element that contains the virtual path for the specified route values; when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString RouteLink( this AjaxHelper ajaxHelper, string linkText, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.RouteLink( linkText, null, routeValues, ajaxOptions, attributeExpression );
		}

		/// <summary>
		/// Returns an anchor element that contains the virtual path for the specified route values; when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString RouteLink( this AjaxHelper ajaxHelper, string linkText, string routeName, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.RouteLink( linkText, routeName, null, ajaxOptions, attributeExpression );
		}

		/// <summary>
		/// Returns an anchor element that contains the virtual path for the specified route values; when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		This object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString RouteLink( this AjaxHelper ajaxHelper, string linkText, string routeName, object routeValues, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.RouteLink( linkText, routeName, new RouteValueDictionary( routeValues ), ajaxOptions, attributeExpression );
		}

		/// <summary>
		/// Returns an anchor element that contains the virtual path for the specified route values; when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString RouteLink( this AjaxHelper ajaxHelper, string linkText, string routeName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.RouteLink( linkText, routeName, routeValues, ajaxOptions, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an anchor element that contains the virtual path for the specified route values; when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
		/// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
		/// <param name="hostName">The host name for the URL.</param>
		/// <param name="fragment">The URL fragment name (the anchor name).</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString RouteLink( this AjaxHelper ajaxHelper, string linkText, string routeName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.RouteLink( linkText, routeName, protocol, hostName, fragment, routeValues, ajaxOptions, attributeExpression.GetAttributes() );
		}
	}
}
