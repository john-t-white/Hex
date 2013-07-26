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
	/// Represents support for HTML links in an application with an expression for specifying HTML attributes.
	/// </summary>
	public static class BeginLinkExtensions
	{
		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="actionName">The name of the action.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this HtmlHelper htmlHelper, string actionName )
		{
			return htmlHelper.BeginActionLink( actionName, null, null, null, null, new RouteValueDictionary(), ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="actionName">The name of the action.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this HtmlHelper htmlHelper, string actionName, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginActionLink( actionName, null, null, null, null, new RouteValueDictionary(), attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="actionName">The name of the action.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this HtmlHelper htmlHelper, string actionName, object routeValues )
		{
			return htmlHelper.BeginActionLink( actionName, null, null, null, null, new RouteValueDictionary( routeValues ), ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="actionName">The name of the action.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="htmlAttributes">
		///		An object that contains the HTML attributes for the element.
		///		The attributes are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this HtmlHelper htmlHelper, string actionName, object routeValues, object htmlAttributes )
		{
			return htmlHelper.BeginActionLink( actionName, null, null, null, null, new RouteValueDictionary( routeValues ), new RouteValueDictionary( htmlAttributes ) );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="actionName">The name of the action.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this HtmlHelper htmlHelper, string actionName, object routeValues, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginActionLink( actionName, null, null, null, null, new RouteValueDictionary( routeValues ), attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="actionName">The name of the action.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this HtmlHelper htmlHelper, string actionName, RouteValueDictionary routeValues )
		{
			return htmlHelper.BeginActionLink( actionName, null, null, null, null, routeValues, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="actionName">The name of the action.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this HtmlHelper htmlHelper, string actionName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes )
		{
			return htmlHelper.BeginActionLink( actionName, null, null, null, null, routeValues, htmlAttributes );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="actionName">The name of the action.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this HtmlHelper htmlHelper, string actionName, RouteValueDictionary routeValues, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginActionLink( actionName, null, null, null, null, routeValues, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="actionName">The name of the action.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this HtmlHelper htmlHelper, string actionName, string controllerName )
		{
			return htmlHelper.BeginActionLink( actionName, controllerName, null, null, null, new RouteValueDictionary(), ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="actionName">The name of the action.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this HtmlHelper htmlHelper, string actionName, string controllerName, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginActionLink( actionName, controllerName, null, null, null, new RouteValueDictionary(), attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="actionName">The name of the action.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="htmlAttributes">
		///		An object that contains the HTML attributes for the element.
		///		The attributes are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this HtmlHelper htmlHelper, string actionName, string controllerName, object routeValues, object htmlAttributes )
		{
			return htmlHelper.BeginActionLink( actionName, controllerName, null, null, null, new RouteValueDictionary( routeValues ), new RouteValueDictionary( htmlAttributes ) );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="actionName">The name of the action.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this HtmlHelper htmlHelper, string actionName, string controllerName, object routeValues, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginActionLink( actionName, controllerName, null, null, null, new RouteValueDictionary( routeValues ), attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="actionName">The name of the action.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this HtmlHelper htmlHelper, string actionName, string controllerName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes )
		{
			return htmlHelper.BeginActionLink( actionName, controllerName, null, null, null, new RouteValueDictionary( routeValues ), htmlAttributes );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="actionName">The name of the action.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this HtmlHelper htmlHelper, string actionName, string controllerName, RouteValueDictionary routeValues, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginActionLink( actionName, controllerName, null, null, null, routeValues, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="actionName">The name of the action.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
		/// <param name="hostName">The host name for the URL.</param>
		/// <param name="fragment">The URL fragment name (the anchor name).</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this HtmlHelper htmlHelper, string actionName, string controllerName, string protocol, string hostName, string fragment, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginActionLink( actionName, controllerName, protocol, hostName, fragment, new RouteValueDictionary(), attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="actionName">The name of the action.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
		/// <param name="hostName">The host name for the URL.</param>
		/// <param name="fragment">The URL fragment name (the anchor name).</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="htmlAttributes">
		///		An object that contains the HTML attributes for the element.
		///		The attributes are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this HtmlHelper htmlHelper, string actionName, string controllerName, string protocol, string hostName, string fragment, object routeValues, object htmlAttributes )
		{
			return htmlHelper.BeginActionLink( actionName, controllerName, protocol, hostName, fragment, new RouteValueDictionary( routeValues ), new RouteValueDictionary( htmlAttributes ) );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="actionName">The name of the action.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
		/// <param name="hostName">The host name for the URL.</param>
		/// <param name="fragment">The URL fragment name (the anchor name).</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this HtmlHelper htmlHelper, string actionName, string controllerName, string protocol, string hostName, string fragment, object routeValues, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginActionLink( actionName, controllerName, protocol, hostName, fragment, new RouteValueDictionary( routeValues ), attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="actionName">The name of the action.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
		/// <param name="hostName">The host name for the URL.</param>
		/// <param name="fragment">The URL fragment name (the anchor name).</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this HtmlHelper htmlHelper, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes )
		{
			htmlHelper.GenerateLinkInternal( null, actionName, controllerName, protocol, hostName, fragment, routeValues, htmlAttributes, true );

			return new MvcLink( htmlHelper.ViewContext );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="actionName">The name of the action.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
		/// <param name="hostName">The host name for the URL.</param>
		/// <param name="fragment">The URL fragment name (the anchor name).</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginActionLink( this HtmlHelper htmlHelper, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginActionLink( actionName, controllerName, protocol, hostName, fragment, routeValues, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this HtmlHelper htmlHelper, object routeValues )
		{
			return htmlHelper.BeginRouteLink( null, null, null, null, new RouteValueDictionary( routeValues ), ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="htmlAttributes">
		///		An object that contains the HTML attributes for the element.
		///		The attributes are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this HtmlHelper htmlHelper, object routeValues, object htmlAttributes )
		{
			return htmlHelper.BeginRouteLink( null, null, null, null, new RouteValueDictionary( routeValues ), new RouteValueDictionary( htmlAttributes ) );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this HtmlHelper htmlHelper, object routeValues, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginRouteLink( null, null, null, null, new RouteValueDictionary( routeValues ), attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this HtmlHelper htmlHelper, RouteValueDictionary routeValues )
		{
			return htmlHelper.BeginRouteLink( null, null, null, null, routeValues, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this HtmlHelper htmlHelper, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes )
		{
			return htmlHelper.BeginRouteLink( null, null, null, null, routeValues, htmlAttributes );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this HtmlHelper htmlHelper, RouteValueDictionary routeValues, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginRouteLink( null, null, null, null, routeValues, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="routeName">The name of the route that is used to return a virtual path.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this HtmlHelper htmlHelper, string routeName )
		{
			return htmlHelper.BeginRouteLink( routeName, null, null, null, new RouteValueDictionary(), ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="routeName">The name of the route that is used to return a virtual path.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this HtmlHelper htmlHelper, string routeName, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginRouteLink( routeName, null, null, null, new RouteValueDictionary(), attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="routeName">The name of the route that is used to return a virtual path.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this HtmlHelper htmlHelper, string routeName, object routeValues )
		{
			return htmlHelper.BeginRouteLink( routeName, null, null, null, new RouteValueDictionary( routeValues ), ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="routeName">The name of the route that is used to return a virtual path.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="htmlAttributes">
		///		An object that contains the HTML attributes for the element.
		///		The attributes are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this HtmlHelper htmlHelper, string routeName, object routeValues, object htmlAttributes )
		{
			return htmlHelper.BeginRouteLink( routeName, null, null, null, new RouteValueDictionary( routeValues ), new RouteValueDictionary( htmlAttributes ) );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="routeName">The name of the route that is used to return a virtual path.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this HtmlHelper htmlHelper, string routeName, object routeValues, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginRouteLink( routeName, null, null, null, new RouteValueDictionary( routeValues ), attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="routeName">The name of the route that is used to return a virtual path.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this HtmlHelper htmlHelper, string routeName, RouteValueDictionary routeValues )
		{
			return htmlHelper.BeginRouteLink( routeName, null, null, null, routeValues, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="routeName">The name of the route that is used to return a virtual path.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this HtmlHelper htmlHelper, string routeName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes )
		{
			return htmlHelper.BeginRouteLink( routeName, null, null, null, routeValues, htmlAttributes );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="routeName">The name of the route that is used to return a virtual path.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this HtmlHelper htmlHelper, string routeName, RouteValueDictionary routeValues, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginRouteLink( routeName, null, null, null, routeValues, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="routeName">The name of the route that is used to return a virtual path.</param>
		/// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
		/// <param name="hostName">The host name for the URL.</param>
		/// <param name="fragment">The URL fragment name (the anchor name).</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this HtmlHelper htmlHelper, string routeName, string protocol, string hostName, string fragment, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginRouteLink( routeName, protocol, hostName, fragment, new RouteValueDictionary(), attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="routeName">The name of the route that is used to return a virtual path.</param>
		/// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
		/// <param name="hostName">The host name for the URL.</param>
		/// <param name="fragment">The URL fragment name (the anchor name).</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="htmlAttributes">
		///		An object that contains the HTML attributes for the element.
		///		The attributes are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this HtmlHelper htmlHelper, string routeName, string protocol, string hostName, string fragment, object routeValues, object htmlAttributes )
		{
			return htmlHelper.BeginRouteLink( routeName, protocol, hostName, fragment, new RouteValueDictionary( routeValues ), new RouteValueDictionary( htmlAttributes ) );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
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
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this HtmlHelper htmlHelper, string routeName, string protocol, string hostName, string fragment, object routeValues, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginRouteLink( routeName, protocol, hostName, fragment, new RouteValueDictionary( routeValues ), attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="routeName">The name of the route that is used to return a virtual path.</param>
		/// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
		/// <param name="hostName">The host name for the URL.</param>
		/// <param name="fragment">The URL fragment name (the anchor name).</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this HtmlHelper htmlHelper, string routeName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes )
		{
			htmlHelper.GenerateLinkInternal( routeName, null, null, protocol, hostName, fragment, routeValues, htmlAttributes, false );

			return new MvcLink( htmlHelper.ViewContext );
		}

		/// <summary>
		/// Writes an opening &lt;a&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="routeName">The name of the route that is used to return a virtual path.</param>
		/// <param name="protocol">The protocol for the URL, such as "http" or "https".</param>
		/// <param name="hostName">The host name for the URL.</param>
		/// <param name="fragment">The URL fragment name (the anchor name).</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;a&gt; tag.</returns>
		public static MvcLink BeginRouteLink( this HtmlHelper htmlHelper, string routeName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginRouteLink( routeName, protocol, hostName, fragment, routeValues, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes the closing &lt;/s&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		public static void EndLink( this HtmlHelper htmlHelper )
		{
			BeginLinkExtensions.EndLink( htmlHelper.ViewContext );
		}

		#region Internal Methods

		internal static void EndLink( ViewContext viewContext )
		{
			viewContext.Writer.Write( "</a>" );
		}

		private static void GenerateLinkInternal( this HtmlHelper htmlHelper, string routeName, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes, bool includeImplicitMvcValues )
		{
			string url = UrlHelper.GenerateUrl( routeName, actionName, controllerName, protocol, hostName, fragment, routeValues, htmlHelper.RouteCollection, htmlHelper.ViewContext.RequestContext, includeImplicitMvcValues );

			TagBuilder linkTagBuilder = new TagBuilder( "a" );
			linkTagBuilder.MergeAttributes( htmlAttributes );
			linkTagBuilder.MergeAttribute( HtmlAttributes.Href, url );

			htmlHelper.ViewContext.Writer.Write( linkTagBuilder.ToString( TagRenderMode.StartTag ) );
		}

		#endregion
	}
}
