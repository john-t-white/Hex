using Hex.AttributeBuilders;
using Hex.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Hex.Ajax
{
	/// <summary>
	/// Represents support for ASP.NET AJAX form within an ASP.NET MVC application with an expression for specifying HTML attributes.
	/// </summary>
	public static class FormExtensions
	{
		/// <summary>
		/// Writes an opening &lt;form&gt; tag to the response.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="actionName">The name of the action method that will handle the request.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;form&gt; tag.</returns>
		public static MvcForm BeginForm( this AjaxHelper ajaxHelper, string actionName, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.BeginForm( actionName, null, null, ajaxOptions, attributeExpression );
		}

		/// <summary>
		/// Writes an opening &lt;form&gt; tag to the response.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="actionName">The name of the action method that will handle the request.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		This object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;form&gt; tag.</returns>
		public static MvcForm BeginForm( this AjaxHelper ajaxHelper, string actionName, object routeValues, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.BeginForm( actionName, null, new RouteValueDictionary( routeValues ), ajaxOptions, attributeExpression );
		}

		/// <summary>
		/// Writes an opening &lt;form&gt; tag to the response.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="actionName">The name of the action method that will handle the request.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;form&gt; tag.</returns>
		public static MvcForm BeginForm( this AjaxHelper ajaxHelper, string actionName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.BeginForm( actionName, null, routeValues, ajaxOptions, attributeExpression );
		}

		/// <summary>
		/// Writes an opening &lt;form&gt; tag to the response.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="actionName">The name of the action method that will handle the request.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;form&gt; tag.</returns>
		public static MvcForm BeginForm( this AjaxHelper ajaxHelper, string actionName, string controllerName, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.BeginForm( actionName, controllerName, null, ajaxOptions, attributeExpression );
		}

		/// <summary>
		/// Writes an opening &lt;form&gt; tag to the response.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="actionName">The name of the action method that will handle the request.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="routeValues">
		///		An object that contains the parameters for a route.
		///		The parameters are retrieved through reflection by examining the properties of the object.
		///		This object is typically created by using object initializer syntax.
		/// </param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;form&gt; tag.</returns>
		public static MvcForm BeginForm( this AjaxHelper ajaxHelper, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.BeginForm( actionName, controllerName, new RouteValueDictionary( routeValues ), ajaxOptions, attributeExpression );
		}

		/// <summary>
		/// Writes an opening &lt;form&gt; tag to the response.
		/// </summary>
		/// <param name="ajaxHelper">The AJAX helper.</param>
		/// <param name="actionName">The name of the action method that will handle the request.</param>
		/// <param name="controllerName">The name of the controller.</param>
		/// <param name="routeValues">An object that contains the parameters for a route.</param>
		/// <param name="ajaxOptions">An object that provides options for the asynchronous request.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;form&gt; tag.</returns>
		public static MvcForm BeginForm( this AjaxHelper ajaxHelper, string actionName, string controllerName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return ajaxHelper.BeginForm( actionName, controllerName, routeValues, ajaxOptions, attributeExpression.GetAttributes() );
		}
	}
}
