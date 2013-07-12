using Hex.AttributeBuilders;
using Hex.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Hex.Html
{
	/// <summary>
	/// Represents support for HTML5 number inputs in an application with an expression for specifying HTML attributes.
	/// </summary>
	public static class NumberExtensions
	{
		private const string NUMBER_TYPE_ATTRIBUTE_VALUE = "number";

		/// <summary>
		/// Returns a number input element by using the specified HTML helper and the name of the form field.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <returns>An number element whose type attribute is set to "number".</returns>
		public static MvcHtmlString Number( this HtmlHelper htmlHelper, string name )
		{
			return htmlHelper.Number( name, null, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns a number input element by using the specified HTML helper, the name of the form field, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An number element whose type attribute is set to "number".</returns>
		public static MvcHtmlString Number( this HtmlHelper htmlHelper, string name, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.Number( name, null, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a number input element by using the specified HTML helper, the name of the form field, and the value.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">
		///		The value of the number input element.
		///		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		///		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		/// </param>
		/// <returns>An input element whose type attribute is set to "number".</returns>
		public static MvcHtmlString Number( this HtmlHelper htmlHelper, string name, object value )
		{
			return htmlHelper.Number( name, value, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns a number input element by using the specified HTML helper, the name of the form field, the value, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">
		///		The value of the number input element.
		///		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		///		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		/// </param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "number".</returns>
		public static MvcHtmlString Number( this HtmlHelper htmlHelper, string name, object value, object htmlAttributes )
		{
			return htmlHelper.Number( name, value, new RouteValueDictionary( htmlAttributes ) );
		}

		/// <summary>
		/// Returns a number input element by using the specified HTML helper, the name of the form field, the value, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">
		///		The value of the number input element.
		///		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		///		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		/// </param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "number".</returns>
		public static MvcHtmlString Number( this HtmlHelper htmlHelper, string name, object value, IDictionary<string, object> htmlAttributes )
		{
			htmlAttributes = htmlAttributes ?? new RouteValueDictionary();
			htmlAttributes[ HtmlAttributes.Type ] = NUMBER_TYPE_ATTRIBUTE_VALUE;

			return htmlHelper.TextBox( name, value, htmlAttributes );
		}

		/// <summary>
		/// Returns a number input element by using the specified HTML helper, the name of the form field, the value, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">
		///		The value of the number input element.
		///		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		///		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		/// </param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "number".</returns>
		public static MvcHtmlString Number( this HtmlHelper htmlHelper, string name, object value, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.Number( name, value, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a number input element for each property in the object that is represented by the specified expression.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <returns>An input element whose type attribute is set to "number".</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString NumberFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression )
		{
			return htmlHelper.NumberFor( expression, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns a number input element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "number".</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString NumberFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes )
		{
			return htmlHelper.NumberFor( expression, new RouteValueDictionary( htmlAttributes ) );
		}

		/// <summary>
		/// Returns a number input element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "number".</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString NumberFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes )
		{
			htmlAttributes = htmlAttributes ?? new RouteValueDictionary();
			htmlAttributes[ HtmlAttributes.Type ] = NUMBER_TYPE_ATTRIBUTE_VALUE;

			return htmlHelper.TextBoxFor( expression, htmlAttributes );
		}

		/// <summary>
		/// Returns a number input element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "number".</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString NumberFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.NumberFor( expression, attributeExpression.GetAttributes() );
		}
	}
}
