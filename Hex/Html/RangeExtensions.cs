﻿using Hex.AttributeBuilders;
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
	/// Represents support for HTML5 range inputs in an application with an expression for specifying HTML attributes.
	/// </summary>
	public static class RangeExtensions
	{
		private const string RANGE_TYPE_ATTRIBUTE_VALUE = "range";

		/// <summary>
		/// Returns a range input element by using the specified HTML helper and the name of the form field.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <returns>An input element whose type attribute is set to "range".</returns>
		public static MvcHtmlString Range( this HtmlHelper htmlHelper, string name )
		{
			return htmlHelper.Range( name, null, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns a range input element by using the specified HTML helper, the name of the form field, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "range".</returns>
		public static MvcHtmlString Range( this HtmlHelper htmlHelper, string name, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.Range( name, null, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a range input element by using the specified HTML helper, the name of the form field, and the value.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">
		///		The url of the range input element.
		///		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		///		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		/// </param>
		/// <returns>An input element whose type attribute is set to "range".</returns>
		public static MvcHtmlString Range( this HtmlHelper htmlHelper, string name, object value )
		{
			return htmlHelper.Range( name, value, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns a range input element by using the specified HTML helper, the name of the form field, the value, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">
		///		The value of the range input element.
		///		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		///		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		/// </param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "range".</returns>
		public static MvcHtmlString Range( this HtmlHelper htmlHelper, string name, object value, object htmlAttributes )
		{
			return htmlHelper.Range( name, value, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Returns a range input element by using the specified HTML helper, the name of the form field, the value, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">
		///		The value of the range input element.
		///		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		///		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		/// </param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "range".</returns>
		public static MvcHtmlString Range( this HtmlHelper htmlHelper, string name, object value, IDictionary<string, object> htmlAttributes )
		{
			htmlAttributes = htmlAttributes ?? new Dictionary<string, object>();
			htmlAttributes[ HtmlAttributes.Type ] = RANGE_TYPE_ATTRIBUTE_VALUE;

			return htmlHelper.TextBox( name, value, htmlAttributes );
		}

		/// <summary>
		/// Returns a range input element by using the specified HTML helper, the name of the form field, the value, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">
		///		The value of the range input element.
		///		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		///		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		/// </param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "range".</returns>
		public static MvcHtmlString Range( this HtmlHelper htmlHelper, string name, object value, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.Range( name, value, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a range input element by using the specified HTML helper, the name of the form field, the value, and maximum and minimum values.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">
		///		The url of the range input element.
		///		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		///		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		/// </param>
		/// <param name="min">The minimum value.</param>
		/// <param name="max">The maximum value.</param>
		/// <returns>An input element whose type attribute is set to "range".</returns>
		public static MvcHtmlString Range( this HtmlHelper htmlHelper, string name, object value, object min, object max )
		{
			return htmlHelper.Range( name, value, min, max, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns a range input element by using the specified HTML helper, the name of the form field, the value, and maximum and minimum values.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">
		///		The url of the range input element.
		///		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		///		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		/// </param>
		/// <param name="min">The minimum value.</param>
		/// <param name="max">The maximum value.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "range".</returns>
		public static MvcHtmlString Range( this HtmlHelper htmlHelper, string name, object value, object min, object max, object htmlAttributes )
		{
			return htmlHelper.Range( name, value, min, max, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Returns a range input element by using the specified HTML helper, the name of the form field, the value, and maximum and minimum values.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">
		///		The url of the range input element.
		///		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		///		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		/// </param>
		/// <param name="min">The minimum value.</param>
		/// <param name="max">The maximum value.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "range".</returns>
		public static MvcHtmlString Range( this HtmlHelper htmlHelper, string name, object value, object min, object max, IDictionary<string, object> htmlAttributes )
		{
			htmlAttributes = htmlAttributes ?? new Dictionary<string, object>();
			htmlAttributes[ HtmlAttributes.Min ] = min;
			htmlAttributes[ HtmlAttributes.Max ] = max;

			return htmlHelper.Range( name, value, htmlAttributes );
		}

		/// <summary>
		/// Returns a range input element by using the specified HTML helper, the name of the form field, the value, and maximum and minimum values.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">
		///		The url of the range input element.
		///		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		///		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		/// </param>
		/// <param name="min">The minimum value.</param>
		/// <param name="max">The maximum value.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "range".</returns>
		public static MvcHtmlString Range( this HtmlHelper htmlHelper, string name, object value, object min, object max, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.Range( name, value, min, max, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a range input element for each property in the object that is represented by the specified expression.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <returns>An input element whose type attribute is set to "range".</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString RangeFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression )
		{
			return htmlHelper.RangeFor( expression, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns a range input element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "range".</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString RangeFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes )
		{
			return htmlHelper.RangeFor( expression, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Returns a range input element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "range".</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString RangeFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes )
		{
			ModelMetadata valueMetadata = ModelMetadata.FromLambdaExpression( expression, htmlHelper.ViewData );

			return htmlHelper.Range( ExpressionHelper.GetExpressionText( expression ), valueMetadata.Model, htmlAttributes );
		}

		/// <summary>
		/// Returns a range input element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "range".</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString RangeFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.RangeFor( expression, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a range input element for each property in the object that is represented by the specified expression.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="min">The minimum value.</param>
		/// <param name="max">The maximum value.</param>
		/// <returns>An input element whose type attribute is set to "range".</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString RangeFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object min, object max )
		{
			return htmlHelper.RangeFor( expression, min, max, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns a range input element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="min">The minimum value.</param>
		/// <param name="max">The maximum value.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "range".</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString RangeFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object min, object max, object htmlAttributes )
		{
			return htmlHelper.RangeFor( expression, min, max, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Returns a range input element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="min">The minimum value.</param>
		/// <param name="max">The maximum value.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "range".</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString RangeFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object min, object max, IDictionary<string, object> htmlAttributes )
		{
			htmlAttributes = htmlAttributes ?? new Dictionary<string, object>();
			htmlAttributes[ HtmlAttributes.Min ] = min;
			htmlAttributes[ HtmlAttributes.Max ] = max;

			return htmlHelper.RangeFor( expression, htmlAttributes );
		}

		/// <summary>
		/// Returns a range input element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="min">The minimum value.</param>
		/// <param name="max">The maximum value.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "range".</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString RangeFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object min, object max, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.RangeFor( expression, min, max, attributeExpression.GetAttributes() );
		}
	}
}
