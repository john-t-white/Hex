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
	/// Represents support for HTML forms in an application with an expression for specifying HTML attributes.
	/// </summary>
	public static class FormExtensions
	{
		/// <summary>
		/// Writes an opening &lt;form&gt; tag to the response. When the user submits the form, the request will be processed by an action method.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;form&gt; tag.</returns>
		public static MvcForm BeginForm( this HtmlHelper htmlHelper, Action<HtmlAttributeBuilder> attributeExpression )
		{
			string rawUrl = htmlHelper.ViewContext.HttpContext.Request.RawUrl;
			return FormHelper.Execute( htmlHelper, rawUrl, FormMethod.Post, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;form&gt; tag to the response. When the user submits the form, the request will be processed by an action method.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route. The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;form&gt; tag.</returns>
		public static MvcForm BeginForm( this HtmlHelper htmlHelper, object routeValues, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginForm( null, null, new RouteValueDictionary( routeValues ), FormMethod.Post, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;form&gt; tag to the response. When the user submits the form, the request will be processed by an action method.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;form&gt; tag.</returns>
		public static MvcForm BeginForm( this HtmlHelper htmlHelper, RouteValueDictionary routeValues, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginForm( null, null, routeValues, FormMethod.Post, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;form&gt; tag to the response. When the user submits the form, the request will be processed by an action method.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;form&gt; tag.</returns>
		public static MvcForm BeginForm( this HtmlHelper htmlHelper, string actionName, string controllerName, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginForm( actionName, controllerName, null, FormMethod.Post, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;form&gt; tag to the response. When the user submits the form, the request will be processed by an action method.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="method">The HTTP method for processing the form, either GET or POST.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;form&gt; tag.</returns>
		public static MvcForm BeginForm( this HtmlHelper htmlHelper, string actionName, string controllerName, FormMethod method, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginForm( actionName, controllerName, null, method, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;form&gt; tag to the response. When the user submits the form, the request will be processed by an action method.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route. The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;form&gt; tag.</returns>
		public static MvcForm BeginForm( this HtmlHelper htmlHelper, string actionName, string controllerName, object routeValues, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginForm( actionName, controllerName, new RouteValueDictionary( routeValues ), FormMethod.Post, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;form&gt; tag to the response. When the user submits the form, the request will be processed by an action method.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;form&gt; tag.</returns>
		public static MvcForm BeginForm( this HtmlHelper htmlHelper, string actionName, string controllerName, RouteValueDictionary routeValues, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginForm( actionName, controllerName, routeValues, FormMethod.Post, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;form&gt; tag to the response. When the user submits the form, the request will be processed by an action method.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route. The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="method">The HTTP method for processing the form, either GET or POST.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;form&gt; tag.</returns>
		public static MvcForm BeginForm( this HtmlHelper htmlHelper, string actionName, string controllerName, object routeValues, FormMethod method, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginForm( actionName, controllerName, new RouteValueDictionary( routeValues ), method, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;form&gt; tag to the response. When the user submits the form, the request will be processed by an action method.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="actionName">The name of the action method.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="method">The HTTP method for processing the form, either GET or POST.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;form&gt; tag.</returns>
		public static MvcForm BeginForm( this HtmlHelper htmlHelper, string actionName, string controllerName, RouteValueDictionary routeValues, FormMethod method, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginForm( actionName, controllerName, routeValues, method, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;form&gt; tag to the response. When the user submits the form, the request will be processed by the route target.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route. The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;form&gt; tag.</returns>
		public static MvcForm BeginRouteForm( this HtmlHelper htmlHelper, object routeValues, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginRouteForm( null, new RouteValueDictionary( routeValues ), FormMethod.Post, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;form&gt; tag to the response. When the user submits the form, the request will be processed by the route target.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;form&gt; tag.</returns>
		public static MvcForm BeginRouteForm( this HtmlHelper htmlHelper, RouteValueDictionary routeValues, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginRouteForm( null, routeValues, FormMethod.Post, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;form&gt; tag to the response. When the user submits the form, the request will be processed by the route target.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="routeName">The name of the route to use to obtain the form-post URL.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;form&gt; tag.</returns>
		public static MvcForm BeginRouteForm( this HtmlHelper htmlHelper, string routeName, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginRouteForm( routeName, null, FormMethod.Post, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;form&gt; tag to the response. When the user submits the form, the request will be processed by the route target.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="routeName">The name of the route to use to obtain the form-post URL.</param>
		/// <param name="method">The HTTP method for processing the form, either GET or POST.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;form&gt; tag.</returns>
		public static MvcForm BeginRouteForm( this HtmlHelper htmlHelper, string routeName, FormMethod method, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginRouteForm( routeName, null, method, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;form&gt; tag to the response. When the user submits the form, the request will be processed by the route target.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="routeName">The name of the route to use to obtain the form-post URL.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route. The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;form&gt; tag.</returns>
		public static MvcForm BeginRouteForm( this HtmlHelper htmlHelper, string routeName, object routeValues, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginRouteForm( routeName, new RouteValueDictionary( routeValues ), FormMethod.Post, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;form&gt; tag to the response. When the user submits the form, the request will be processed by the route target.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="routeName">The name of the route to use to obtain the form-post URL.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;form&gt; tag.</returns>
		public static MvcForm BeginRouteForm( this HtmlHelper htmlHelper, string routeName, RouteValueDictionary routeValues, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginRouteForm( routeName, routeValues, FormMethod.Post, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;form&gt; tag to the response. When the user submits the form, the request will be processed by the route target.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="routeName">The name of the route to use to obtain the form-post URL.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route. The parameters are retrieved through reflection by examining the properties of the object.
		///		The object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="method">The HTTP method for processing the form, either GET or POST.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;form&gt; tag.</returns>
		public static MvcForm BeginRouteForm( this HtmlHelper htmlHelper, string routeName, object routeValues, FormMethod method, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginRouteForm( routeName, new RouteValueDictionary( routeValues ), method, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;form&gt; tag to the response. When the user submits the form, the request will be processed by the route target.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="routeName">The name of the route to use to obtain the form-post URL.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="method">The HTTP method for processing the form, either GET or POST.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;form&gt; tag.</returns>
		public static MvcForm BeginRouteForm( this HtmlHelper htmlHelper, string routeName, RouteValueDictionary routeValues, FormMethod method, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginRouteForm( routeName, routeValues, method, attributeExpression.GetAttributes() );
		}
	}
}
