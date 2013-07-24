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
	/// Represents support for ASP.NET AJAX action links within an ASP.NET MVC application with an expression for specifying HTML attributes.
	/// </summary>
	public static class ActionLinkExtensions
	{
		/// <summary>
		/// Returns an anchor element that contains the URL to the specified action method; when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString ActionLink( this AjaxHelper ajaxHelper, string linkText, string actionName, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.ActionLink( linkText, actionName, null, null, ajaxOptions, attributeExpression );
		}

		/// <summary>
		/// Returns an anchor element that contains the URL to the specified action method; when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		This object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString ActionLink( this AjaxHelper ajaxHelper, string linkText, string actionName, object routeValues, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.ActionLink( linkText, actionName, null, new RouteValueDictionary( routeValues ), ajaxOptions, attributeExpression );
		}

		/// <summary>
		/// Returns an anchor element that contains the URL to the specified action method; when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString ActionLink( this AjaxHelper ajaxHelper, string linkText, string actionName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.ActionLink( linkText, actionName, null, routeValues, ajaxOptions, attributeExpression );
		}

		/// <summary>
		/// Returns an anchor element that contains the URL to the specified action method; when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString ActionLink( this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.ActionLink( linkText, actionName, controllerName, null, ajaxOptions, attributeExpression );
		}

		/// <summary>
		/// Returns an anchor element that contains the URL to the specified action method; when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		This object is typically created by using object initializer syntax.
		///	</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString ActionLink( this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.ActionLink( linkText, actionName, controllerName, new RouteValueDictionary( routeValues ), ajaxOptions, attributeExpression );
		}

		/// <summary>
		/// Returns an anchor element that contains the URL to the specified action method; when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString ActionLink( this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.ActionLink( linkText, actionName, controllerName, routeValues, ajaxOptions, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an anchor element that contains the URL to the specified action method; when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
		/// <param name="hostName">The host name for the URL.</param>
		/// <param name="fragment">The URL fragment name (the anchor name).</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		This object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString ActionLink( this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, object routeValues, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.ActionLink( linkText, actionName, controllerName, protocol, hostName, fragment, new RouteValueDictionary( routeValues ), ajaxOptions, attributeExpression );
		}

		/// <summary>
		/// Returns an anchor element that contains the URL to the specified action method; when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="linkText">The inner text of the anchor element.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
		/// <param name="hostName">The host name for the URL.</param>
		/// <param name="fragment">The URL fragment name (the anchor name).</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An anchor element.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="linkText" /> parameter is null or empty.</exception>
		public static MvcHtmlString ActionLink( this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.ActionLink( linkText, actionName, controllerName, protocol, hostName, fragment, routeValues, ajaxOptions, attributeExpression.GetAttributes() );
		}
	}
}
