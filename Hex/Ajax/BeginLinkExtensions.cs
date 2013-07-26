using Hex.AttributeBuilders;
using Hex.Extensions;
using Hex.Html;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Routing;

namespace Hex.Ajax
{
	/// <summary>
	/// Represents support for ASP.NET AJAX links within an ASP.NET MVC application with an expression for specifying HTML attributes.
	/// </summary>
	public static class BeginLinkExtensions
	{
		private const string LINK_ON_CLICK_FORMAT = "Sys.Mvc.AsyncHyperlink.handleClick(this, new Sys.UI.DomEvent(event), {0});";

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the URL to the specified action method;
		/// when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this AjaxHelper ajaxHelper, string actionName, AjaxOptions ajaxOptions )
		{
			return ajaxHelper.BeginActionLink( actionName, null, null, null, null, null, ajaxOptions, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the URL to the specified action method;
		/// when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this AjaxHelper ajaxHelper, string actionName, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.BeginActionLink( actionName, null, null, null, null, null, ajaxOptions, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the URL to the specified action method;
		/// when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this AjaxHelper ajaxHelper, string actionName, object routeValues, AjaxOptions ajaxOptions )
		{
			return ajaxHelper.BeginActionLink( actionName, null, null, null, null, new RouteValueDictionary( routeValues ), ajaxOptions, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the URL to the specified action method;
		/// when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="htmlAttributes">
		///		An object that contains the HTML attributes for the element.
		///		The attributes are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this AjaxHelper ajaxHelper, string actionName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes )
		{
			return ajaxHelper.BeginActionLink( actionName, null, null, null, null, new RouteValueDictionary( routeValues ), ajaxOptions, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the URL to the specified action method;
		/// when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		///	</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this AjaxHelper ajaxHelper, string actionName, object routeValues, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.BeginActionLink( actionName, null, null, null, null, new RouteValueDictionary( routeValues ), ajaxOptions, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the URL to the specified action method;
		/// when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this AjaxHelper ajaxHelper, string actionName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions )
		{
			return ajaxHelper.BeginActionLink( actionName, null, null, null, null, routeValues, ajaxOptions, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the URL to the specified action method;
		/// when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this AjaxHelper ajaxHelper, string actionName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes )
		{
			return ajaxHelper.BeginActionLink( actionName, null, null, null, null, routeValues, ajaxOptions, htmlAttributes );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the URL to the specified action method;
		/// when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this AjaxHelper ajaxHelper, string actionName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.BeginActionLink( actionName, null, null, null, null, routeValues, ajaxOptions, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the URL to the specified action method;
		/// when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this AjaxHelper ajaxHelper, string actionName, string controllerName, AjaxOptions ajaxOptions )
		{
			return ajaxHelper.BeginActionLink( actionName, controllerName, null, null, null, null, ajaxOptions, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the URL to the specified action method;
		/// when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this AjaxHelper ajaxHelper, string actionName, string controllerName, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.BeginActionLink( actionName, controllerName, null, null, null, null, ajaxOptions, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the URL to the specified action method;
		/// when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this AjaxHelper ajaxHelper, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions )
		{
			return ajaxHelper.BeginActionLink( actionName, controllerName, null, null, null, new RouteValueDictionary( routeValues ), ajaxOptions, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the URL to the specified action method;
		/// when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="htmlAttributes">
		///		An object that contains the HTML attributes for the element.
		///		The attributes are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this AjaxHelper ajaxHelper, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes )
		{
			return ajaxHelper.BeginActionLink( actionName, controllerName, null, null, null, new RouteValueDictionary( routeValues ), ajaxOptions, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the URL to the specified action method;
		/// when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this AjaxHelper ajaxHelper, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.BeginActionLink( actionName, controllerName, null, null, null, new RouteValueDictionary( routeValues ), ajaxOptions, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the URL to the specified action method;
		/// when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this AjaxHelper ajaxHelper, string actionName, string controllerName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions )
		{
			return ajaxHelper.BeginActionLink( actionName, controllerName, null, null, null, routeValues, ajaxOptions, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the URL to the specified action method;
		/// when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this AjaxHelper ajaxHelper, string actionName, string controllerName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes )
		{
			return ajaxHelper.BeginActionLink( actionName, controllerName, null, null, null, routeValues, ajaxOptions, htmlAttributes );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the URL to the specified action method;
		/// when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this AjaxHelper ajaxHelper, string actionName, string controllerName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.BeginActionLink( actionName, controllerName, null, null, null, routeValues, ajaxOptions, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the URL to the specified action method;
		/// when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
		/// <param name="hostName">The host name for the URL.</param>
		/// <param name="fragment">The URL fragment name (the anchor name).</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="htmlAttributes">
		///		An object that contains the HTML attributes for the element.
		///		The attributes are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this AjaxHelper ajaxHelper, string actionName, string controllerName, string protocol, string hostName, string fragment, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes )
		{
			return ajaxHelper.BeginActionLink( actionName, controllerName, protocol, hostName, fragment, new RouteValueDictionary( routeValues ), ajaxOptions, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the URL to the specified action method;
		/// when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
		/// <param name="hostName">The host name for the URL.</param>
		/// <param name="fragment">The URL fragment name (the anchor name).</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this AjaxHelper ajaxHelper, string actionName, string controllerName, string protocol, string hostName, string fragment, object routeValues, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.BeginActionLink( actionName, controllerName, protocol, hostName, fragment, new RouteValueDictionary( routeValues ), ajaxOptions, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the URL to the specified action method;
		/// when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
		/// <param name="hostName">The host name for the URL.</param>
		/// <param name="fragment">The URL fragment name (the anchor name).</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this AjaxHelper ajaxHelper, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes )
		{
			ajaxHelper.GenerateLinkInternal( null, actionName, controllerName, protocol, hostName, fragment, routeValues, ajaxOptions, htmlAttributes, true );

			return new MvcLink( ajaxHelper.ViewContext );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the URL to the specified action method;
		/// when the action link is clicked, the action method is invoked asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
		/// <param name="hostName">The host name for the URL.</param>
		/// <param name="fragment">The URL fragment name (the anchor name).</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this AjaxHelper ajaxHelper, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.BeginActionLink( actionName, controllerName, protocol, hostName, fragment, routeValues, ajaxOptions, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the virtual path for the specified route values;
		/// when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this AjaxHelper ajaxHelper, object routeValues, AjaxOptions ajaxOptions )
		{
			return ajaxHelper.BeginRouteLink( null, null, null, null, new RouteValueDictionary( routeValues ), ajaxOptions, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the virtual path for the specified route values;
		/// when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="htmlAttributes">
		///		An object that contains the HTML attributes for the element.
		///		The attributes are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this AjaxHelper ajaxHelper, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes )
		{
			return ajaxHelper.BeginRouteLink( null, null, null, null, new RouteValueDictionary( routeValues ), ajaxOptions, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the virtual path for the specified route values;
		/// when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this AjaxHelper ajaxHelper, object routeValues, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.BeginRouteLink( null, null, null, null, new RouteValueDictionary( routeValues ), ajaxOptions, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the virtual path for the specified route values;
		/// when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this AjaxHelper ajaxHelper, RouteValueDictionary routeValues, AjaxOptions ajaxOptions )
		{
			return ajaxHelper.BeginRouteLink( null, null, null, null, routeValues, ajaxOptions, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the virtual path for the specified route values;
		/// when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this AjaxHelper ajaxHelper, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes )
		{
			return ajaxHelper.BeginRouteLink( null, null, null, null, routeValues, ajaxOptions, htmlAttributes );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the virtual path for the specified route values;
		/// when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this AjaxHelper ajaxHelper, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.BeginRouteLink( null, null, null, null, routeValues, ajaxOptions, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the virtual path for the specified route values;
		/// when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this AjaxHelper ajaxHelper, string routeName, AjaxOptions ajaxOptions )
		{
			return ajaxHelper.BeginRouteLink( routeName, null, null, null, null, ajaxOptions, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the virtual path for the specified route values;
		/// when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="htmlAttributes">
		///		An object that contains the HTML attributes for the element.
		///		The attributes are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this AjaxHelper ajaxHelper, string routeName, AjaxOptions ajaxOptions, object htmlAttributes )
		{
			return ajaxHelper.BeginRouteLink( routeName, null, null, null, null, ajaxOptions, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the virtual path for the specified route values;
		/// when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this AjaxHelper ajaxHelper, string routeName, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes )
		{
			return ajaxHelper.BeginRouteLink( routeName, null, null, null, null, ajaxOptions, htmlAttributes );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the virtual path for the specified route values;
		/// when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this AjaxHelper ajaxHelper, string routeName, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.BeginRouteLink( routeName, null, null, null, null, ajaxOptions, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the virtual path for the specified route values;
		/// when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this AjaxHelper ajaxHelper, string routeName, object routeValues, AjaxOptions ajaxOptions )
		{
			return ajaxHelper.BeginRouteLink( routeName, null, null, null, new RouteValueDictionary( routeValues ), ajaxOptions, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the virtual path for the specified route values;
		/// when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="htmlAttributes">
		///		An object that contains the HTML attributes for the element.
		///		The attributes are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this AjaxHelper ajaxHelper, string routeName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes )
		{
			return ajaxHelper.BeginRouteLink( routeName, null, null, null, new RouteValueDictionary( routeValues ), ajaxOptions, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the virtual path for the specified route values;
		/// when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this AjaxHelper ajaxHelper, string routeName, object routeValues, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.BeginRouteLink( routeName, null, null, null, new RouteValueDictionary( routeValues ), ajaxOptions, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the virtual path for the specified route values;
		/// when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this AjaxHelper ajaxHelper, string routeName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions )
		{
			return ajaxHelper.BeginRouteLink( routeName, null, null, null, routeValues, ajaxOptions, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the virtual path for the specified route values;
		/// when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this AjaxHelper ajaxHelper, string routeName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes )
		{
			return ajaxHelper.BeginRouteLink( routeName, null, null, null, routeValues, ajaxOptions, htmlAttributes );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the virtual path for the specified route values;
		/// when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this AjaxHelper ajaxHelper, string routeName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.BeginRouteLink( routeName, null, null, null, routeValues, ajaxOptions, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the virtual path for the specified route values;
		/// when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
		/// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
		/// <param name="hostName">The host name for the URL.</param>
		/// <param name="fragment">The URL fragment name (the anchor name).</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this AjaxHelper ajaxHelper, string routeName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes )
		{
			ajaxHelper.GenerateLinkInternal( routeName, null, null, protocol, hostName, fragment, routeValues, ajaxOptions, htmlAttributes, false );

			return new MvcLink( ajaxHelper.ViewContext );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response that contains the virtual path for the specified route values;
		/// when the link is clicked, a request is made to the virtual path asynchronously by using JavaScript.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="routeName">The name of the route to use to obtain the form post URL.</param>
		/// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
		/// <param name="hostName">The host name for the URL.</param>
		/// <param name="fragment">The URL fragment name (the anchor name).</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this AjaxHelper ajaxHelper, string routeName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.BeginRouteLink( routeName, protocol, hostName, fragment, routeValues, ajaxOptions, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes the closing &lt;/s&gt; tag to the response.
		/// </summary>
		/// <param name="ajaxHelper">The HTML helper instance that this method extends.</param>
		public static void EndLink( this AjaxHelper ajaxHelper )
		{
			BeginLinkExtensions.EndLink( ajaxHelper.ViewContext );
		}

		#region Internal Methods

		internal static void EndLink( ViewContext viewContext )
		{
			viewContext.Writer.Write( "</a>" );
		}

		private static void GenerateLinkInternal( this AjaxHelper ajaxHelper, string routeName, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes, bool includeImplicitMvcValues )
		{
			string url = UrlHelper.GenerateUrl( routeName, actionName, controllerName, protocol, hostName, fragment, routeValues, ajaxHelper.RouteCollection, ajaxHelper.ViewContext.RequestContext, includeImplicitMvcValues );

			TagBuilder linkTagBuilder = new TagBuilder( "a" );
			linkTagBuilder.MergeAttributes( htmlAttributes );
			linkTagBuilder.MergeAttribute( HtmlAttributes.Href, url );

			if( !ajaxHelper.ViewContext.UnobtrusiveJavaScriptEnabled )
			{
				string onClickScript = string.Format( CultureInfo.InvariantCulture, LINK_ON_CLICK_FORMAT, BeginLinkExtensions.InvokeAjaxOptionsToJavascriptString( ajaxOptions ) );
				linkTagBuilder.MergeAttribute( HtmlAttributes.Events.OnClick, onClickScript );
			}
			else
			{
				linkTagBuilder.MergeAttributes<string, object>( ajaxOptions.ToUnobtrusiveHtmlAttributes() );
			}

			ajaxHelper.ViewContext.Writer.Write( linkTagBuilder.ToString( TagRenderMode.StartTag ) );
		}

		private static string InvokeAjaxOptionsToJavascriptString( AjaxOptions ajaxOptions )
		{
			BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod;

			Type ajaxOptionsType = typeof( AjaxOptions );
			var returnValue = ajaxOptionsType.InvokeMember( "ToJavascriptString", bindingFlags, null, ajaxOptions, null );

			return ( string )returnValue;
		}

		#endregion
	}
}
