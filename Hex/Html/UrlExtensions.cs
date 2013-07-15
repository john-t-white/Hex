using Hex.AttributeBuilders;
using Hex.Extensions;
using Hex.Resources;
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
	/// Represents support for HTML5 url inputs in an application with an expression for specifying HTML attributes.
	/// </summary>
	public static class UrlExtensions
	{
		private const string URL_TYPE_ATTRIBUTE_VALUE = "url";

		/// <summary>
		/// Returns a url input element by using the specified HTML helper and the name of the form field.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <returns>An input element whose type attribute is set to "url".</returns>
		public static MvcHtmlString Url( this HtmlHelper htmlHelper, string name )
		{
			return htmlHelper.Url( name, null, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns a url input element by using the specified HTML helper, the name of the form field, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "url".</returns>
		public static MvcHtmlString Url( this HtmlHelper htmlHelper, string name, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.Url( name, null, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a url input element by using the specified HTML helper, the name of the form field, and the value.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">
		///		The url of the url input element.
		///		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		///		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		/// </param>
		/// <returns>An input element whose type attribute is set to "url".</returns>
		public static MvcHtmlString Url( this HtmlHelper htmlHelper, string name, object value )
		{
			return htmlHelper.Url( name, value, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns a url input element by using the specified HTML helper, the name of the form field, the value, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">
		///		The value of the url input element.
		///		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		///		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		/// </param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "url".</returns>
		public static MvcHtmlString Url( this HtmlHelper htmlHelper, string name, object value, object htmlAttributes )
		{
			return htmlHelper.Url( name, value, new RouteValueDictionary( htmlAttributes ) );
		}

		/// <summary>
		/// Returns a url input element by using the specified HTML helper, the name of the form field, the value, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">
		///		The value of the url input element.
		///		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		///		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		/// </param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "url".</returns>
		public static MvcHtmlString Url( this HtmlHelper htmlHelper, string name, object value, IDictionary<string, object> htmlAttributes )
		{
			htmlAttributes = htmlAttributes ?? new RouteValueDictionary();
			htmlAttributes[ HtmlAttributes.Type ] = URL_TYPE_ATTRIBUTE_VALUE;

			return htmlHelper.TextBox( name, UrlExtensions.ConvertIfUri( value ), htmlAttributes );
		}

		/// <summary>
		/// Returns a url input element by using the specified HTML helper, the name of the form field, the value, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">
		///		The value of the url input element.
		///		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		///		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		/// </param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "url".</returns>
		public static MvcHtmlString Url( this HtmlHelper htmlHelper, string name, object value, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.Url( name, value, attributeExpression.GetAttributes() );
		}

		///// <summary>
		///// Returns a url input element by using the specified HTML helper, the name of the form field, and the value.
		///// </summary>
		///// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		///// <param name="name">The name of the form field to return.</param>
		///// <param name="value">
		/////		The url of the range input element.
		/////		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		/////		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		///// </param>
		///// <returns>An input element whose type attribute is set to "url".</returns>
		///// <exception cref="T:System.ArgumentException">The <paramref name="value" /> must be an absolute url.</exception>
		//public static MvcHtmlString Url( this HtmlHelper htmlHelper, string name, Uri value )
		//{
		//	return htmlHelper.Url( name, value, ( IDictionary<string, object> )null );
		//}

		///// <summary>
		///// Returns a url input element by using the specified HTML helper, the name of the form field, the value, and the specified HTML attributes.
		///// </summary>
		///// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		///// <param name="name">The name of the form field to return.</param>
		///// <param name="value">
		/////		The value of the url input element.
		/////		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		/////		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		///// </param>
		///// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		///// <returns>An input element whose type attribute is set to "url".</returns>
		///// <exception cref="T:System.ArgumentException">The <paramref name="value" /> must be an absolute url.</exception>
		//public static MvcHtmlString Url( this HtmlHelper htmlHelper, string name, Uri value, object htmlAttributes )
		//{
		//	return htmlHelper.Url( name, value, new RouteValueDictionary( htmlAttributes ) );
		//}

		///// <summary>
		///// Returns a url input element by using the specified HTML helper, the name of the form field, the value, and the specified HTML attributes.
		///// </summary>
		///// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		///// <param name="name">The name of the form field to return.</param>
		///// <param name="value">
		/////		The value of the url input element.
		/////		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		/////		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		///// </param>
		///// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		///// <returns>An input element whose type attribute is set to "url".</returns>
		///// <exception cref="T:System.ArgumentException">The <paramref name="value" /> must be an absolute url.</exception>
		//public static MvcHtmlString Url( this HtmlHelper htmlHelper, string name, Uri value, IDictionary<string, object> htmlAttributes )
		//{
		//	if( value != null && !value.IsAbsoluteUri )
		//	{
		//		throw new ArgumentException( ExceptionMessages.ABSOLUTE_URI_REQUIRED, "value" );
		//	}

		//	string urlValue = ( value != null ) ? value.AbsoluteUri : null;

		//	return htmlHelper.Url( name, urlValue, htmlAttributes );
		//}

		///// <summary>
		///// Returns a url input element by using the specified HTML helper, the name of the form field, the value, and the specified HTML attributes.
		///// </summary>
		///// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		///// <param name="name">The name of the form field to return.</param>
		///// <param name="value">
		/////		The value of the url input element.
		/////		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		/////		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		///// </param>
		///// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		///// <returns>An input element whose type attribute is set to "url".</returns>
		///// <exception cref="T:System.ArgumentException">The <paramref name="value" /> must be an absolute url.</exception>
		//public static MvcHtmlString Url( this HtmlHelper htmlHelper, string name, Uri value, Action<HtmlAttributeBuilder> attributeExpression )
		//{
		//	return htmlHelper.Url( name, value, attributeExpression.GetAttributes() );
		//}

		/// <summary>
		/// Returns a url input element for each property in the object that is represented by the specified expression.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <returns>An input element whose type attribute is set to "url".</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString UrlFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression )
		{
			return htmlHelper.UrlFor( expression, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns a url input element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "url".</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString UrlFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes )
		{
			return htmlHelper.UrlFor( expression, new RouteValueDictionary( htmlAttributes ) );
		}

		/// <summary>
		/// Returns a url input element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "url".</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString UrlFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes )
		{
			ModelMetadata valueMetadata = ModelMetadata.FromLambdaExpression( expression, htmlHelper.ViewData );

			return htmlHelper.Url( ExpressionHelper.GetExpressionText( expression ), valueMetadata.Model, htmlAttributes );
		}

		/// <summary>
		/// Returns a url input element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "url".</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString UrlFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.UrlFor( expression, attributeExpression.GetAttributes() );
		}

		///// <summary>
		///// Returns a url input element for each property in the object that is represented by the specified expression.
		///// </summary>
		///// <typeparam name="TModel">The type of the model.</typeparam>
		///// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		///// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		///// <returns>An input element whose type attribute is set to "url".</returns>
		///// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		///// <exception cref="T:System.ArgumentException">The <paramref name="expression" /> parameter is not an absolute url.</exception>
		//public static MvcHtmlString UrlFor<TModel>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, Uri>> expression )
		//{
		//	return htmlHelper.UrlFor( expression, ( IDictionary<string, object> )null );
		//}

		///// <summary>
		///// Returns a url input element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		///// </summary>
		///// <typeparam name="TModel">The type of the model.</typeparam>
		///// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		///// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		///// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		///// <returns>An input element whose type attribute is set to "url".</returns>
		///// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		///// <exception cref="T:System.ArgumentException">The <paramref name="expression" /> parameter is not an absolute url.</exception>
		//public static MvcHtmlString UrlFor<TModel>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, Uri>> expression, object htmlAttributes )
		//{
		//	return htmlHelper.UrlFor( expression, new RouteValueDictionary( htmlAttributes ) );
		//}

		///// <summary>
		///// Returns a url input element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		///// </summary>
		///// <typeparam name="TModel">The type of the model.</typeparam>
		///// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		///// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		///// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		///// <returns>An input element whose type attribute is set to "url".</returns>
		///// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		///// <exception cref="T:System.ArgumentException">The <paramref name="expression" /> parameter is not an absolute url.</exception>
		//public static MvcHtmlString UrlFor<TModel>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, Uri>> expression, IDictionary<string, object> htmlAttributes )
		//{
		//	ModelMetadata valueMetadata = ModelMetadata.FromLambdaExpression( expression, htmlHelper.ViewData );

		//	Uri value = ( Uri )valueMetadata.Model;

		//	if( value != null && !value.IsAbsoluteUri )
		//	{
		//		throw new ArgumentException( ExceptionMessages.ABSOLUTE_URI_REQUIRED, "expression" );
		//	}

		//	return htmlHelper.Url( ExpressionHelper.GetExpressionText( expression ), ( Uri )valueMetadata.Model, htmlAttributes );
		//}

		///// <summary>
		///// Returns a url input element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		///// </summary>
		///// <typeparam name="TModel">The type of the model.</typeparam>
		///// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		///// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		///// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		///// <returns>An input element whose type attribute is set to "url".</returns>
		///// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		///// <exception cref="T:System.ArgumentException">The <paramref name="expression" /> parameter is not an absolute url.</exception>
		//public static MvcHtmlString UrlFor<TModel>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, Uri>> expression, Action<HtmlAttributeBuilder> attributeExpression )
		//{
		//	return htmlHelper.UrlFor( expression, attributeExpression.GetAttributes() );
		//}

		#region Internal Methods

		private static object ConvertIfUri( object value )
		{
			if( value is Uri )
			{
				value = ( ( Uri )value ).AbsoluteUri;
			}

			return value;
		}

		#endregion
	}
}
