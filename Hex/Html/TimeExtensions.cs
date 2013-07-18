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
	/// Represents support for HTML5 time inputs in an application with an expression for specifying HTML attributes.
	/// </summary>
	public static class TimeExtensions
	{
		private const TimeFormat DEFAULT_TIME_FORMAT = TimeFormat.Minute;
		private const string TIME_TYPE_ATTRIBUTE_VALUE = "time";
		//private const string MINUTE_TIME_FORMAT = "HH:mm";
		//private const string SECOND_TIME_FORMAT = "HH:mm:ss";
		//private const string MILLISECOND_TIME_FORMAT = "HH:mm:ss.fff";

		/// <summary>
		/// Returns a time input element by using the specified HTML helper and the name of the form field.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <returns>An input element whose type attribute is set to "time".</returns>
		public static MvcHtmlString Time( this HtmlHelper htmlHelper, string name )
		{
			return htmlHelper.Time( name, null, DEFAULT_TIME_FORMAT, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns a time input element by using the specified HTML helper, the name of the form field, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "time".</returns>
		public static MvcHtmlString Time( this HtmlHelper htmlHelper, string name, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.Time( name, null, DEFAULT_TIME_FORMAT, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a time input element by using the specified HTML helper, the name of the form field, and the value.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">
		///		The value of the time input element.
		///		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		///		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		/// </param>
		/// <returns>An input element whose type attribute is set to "time".</returns>
		public static MvcHtmlString Time( this HtmlHelper htmlHelper, string name, object value )
		{
			return htmlHelper.Time( name, value, DEFAULT_TIME_FORMAT, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns a time input element by using the specified HTML helper, the name of the form field, the value, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">
		///		The value of the time input element.
		///		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		///		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		/// </param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "time".</returns>
		public static MvcHtmlString Time( this HtmlHelper htmlHelper, string name, object value, object htmlAttributes )
		{
			return htmlHelper.Time( name, value, DEFAULT_TIME_FORMAT, new RouteValueDictionary( htmlAttributes ) );
		}

		/// <summary>
		/// Returns a time input element by using the specified HTML helper, the name of the form field, the value, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">
		///		The value of the time input element.
		///		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		///		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		/// </param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "time".</returns>
		public static MvcHtmlString Time( this HtmlHelper htmlHelper, string name, object value, IDictionary<string, object> htmlAttributes )
		{
			return htmlHelper.Time( name, value, DEFAULT_TIME_FORMAT, htmlAttributes );
		}

		/// <summary>
		/// Returns a time input element by using the specified HTML helper, the name of the form field, the value, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">
		///		The value of the time input element.
		///		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		///		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		/// </param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "time".</returns>
		public static MvcHtmlString Time( this HtmlHelper htmlHelper, string name, object value, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.Time( name, value, DEFAULT_TIME_FORMAT, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a time input element by using the specified HTML helper, the name of the form field, and the time format.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="timeFormat">The format of the time.</param>
		/// <returns>An input element whose type attribute is set to "time".</returns>
		public static MvcHtmlString Time( this HtmlHelper htmlHelper, string name, TimeFormat timeFormat )
		{
			return htmlHelper.Time( name, null, timeFormat, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns a time input element by using the specified HTML helper, the name of the form field, the time format, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="timeFormat">The format of the time.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "time".</returns>
		public static MvcHtmlString Time( this HtmlHelper htmlHelper, string name, TimeFormat timeFormat, object htmlAttributes )
		{
			return htmlHelper.Time( name, null, timeFormat, new RouteValueDictionary( htmlAttributes ) );
		}

		/// <summary>
		/// Returns a time input element by using the specified HTML helper, the name of the form field, the time format, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="timeFormat">The format of the time.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "time".</returns>
		public static MvcHtmlString Time( this HtmlHelper htmlHelper, string name, TimeFormat timeFormat, IDictionary<string, object> htmlAttributes )
		{
			return htmlHelper.Time( name, null, timeFormat, htmlAttributes );
		}

		/// <summary>
		/// Returns a time input element by using the specified HTML helper, the name of the form field, the time format, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="timeFormat">The format of the time.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "time".</returns>
		public static MvcHtmlString Time( this HtmlHelper htmlHelper, string name, TimeFormat timeFormat, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.Time( name, null, timeFormat, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a time input element by using the specified HTML helper, the name of the form field, the value, and the time format.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">
		///		The value of the time input element.
		///		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		///		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		/// </param>
		/// <param name="timeFormat">The format of the time.</param>
		/// <returns>An input element whose type attribute is set to "time".</returns>
		public static MvcHtmlString Time( this HtmlHelper htmlHelper, string name, object value, TimeFormat timeFormat )
		{
			return htmlHelper.Time( name, value, timeFormat, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns a time input element by using the specified HTML helper, the name of the form field, the value, the time format, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">
		///		The value of the time input element.
		///		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		///		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		///	</param>
		/// <param name="timeFormat">The format of the time.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "time".</returns>
		public static MvcHtmlString Time( this HtmlHelper htmlHelper, string name, object value, TimeFormat timeFormat, object htmlAttributes )
		{
			return htmlHelper.Time( name, value, timeFormat, new RouteValueDictionary( htmlAttributes ) );
		}

		/// <summary>
		/// Returns a time input element by using the specified HTML helper, the name of the form field, the value, the time format, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">
		///		The value of the time input element.
		///		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		///		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		/// </param>
		/// <param name="timeFormat">The format of the time.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "time".</returns>
		public static MvcHtmlString Time( this HtmlHelper htmlHelper, string name, object value, TimeFormat timeFormat, IDictionary<string, object> htmlAttributes )
		{
			htmlAttributes = htmlAttributes ?? new RouteValueDictionary();
			htmlAttributes[ HtmlAttributes.Type ] = TIME_TYPE_ATTRIBUTE_VALUE;

			TimeExtensions.AddStepAttribute( timeFormat, htmlAttributes );

			return htmlHelper.TextBox( name, value.ConvertIfDateTime( timeFormat, true ), htmlAttributes );
		}

		/// <summary>
		/// Returns a time input element by using the specified HTML helper, the name of the form field, the value, the time format, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">
		///		The value of the time input element.
		///		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		///		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		/// </param>
		/// <param name="timeFormat">The format of the time.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "time".</returns>
		public static MvcHtmlString Time( this HtmlHelper htmlHelper, string name, object value, TimeFormat timeFormat, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.Time( name, value, timeFormat, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a time input element for each property in the object that is represented by the specified expression.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <returns>An input element whose type attribute is set to "time".</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString TimeFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression )
		{
			return htmlHelper.TimeFor( expression, DEFAULT_TIME_FORMAT, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns a time input element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "time".</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString TimeFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes )
		{
			return htmlHelper.TimeFor( expression, DEFAULT_TIME_FORMAT, new RouteValueDictionary( htmlAttributes ) );
		}

		/// <summary>
		/// Returns a time input element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "time".</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString TimeFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes )
		{
			return htmlHelper.TimeFor( expression, DEFAULT_TIME_FORMAT, htmlAttributes );
		}

		/// <summary>
		/// Returns a time input element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "time".</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString TimeFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.TimeFor( expression, DEFAULT_TIME_FORMAT, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a time input element for each property in the object that is represented by the specified expression.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="timeFormat">The format of the time.</param>
		/// <returns>An input element whose type attribute is set to "time".</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString TimeFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, TimeFormat timeFormat )
		{
			return htmlHelper.TimeFor( expression, timeFormat, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns a time input element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="timeFormat">The format of the time.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "time".</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString TimeFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, TimeFormat timeFormat, object htmlAttributes )
		{
			return htmlHelper.TimeFor( expression, timeFormat, new RouteValueDictionary( htmlAttributes ) );
		}

		/// <summary>
		/// Returns a time input element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="timeFormat">The format of the time.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "time".</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString TimeFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, TimeFormat timeFormat, IDictionary<string, object> htmlAttributes )
		{
			ModelMetadata valueMetadata = ModelMetadata.FromLambdaExpression( expression, htmlHelper.ViewData );

			return htmlHelper.Time( ExpressionHelper.GetExpressionText( expression ), valueMetadata.Model, timeFormat, htmlAttributes );
		}

		/// <summary>
		/// Returns a time input element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="timeFormat">The format of the time.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "time".</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString TimeFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, TimeFormat timeFormat, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.TimeFor( expression, timeFormat, attributeExpression.GetAttributes() );
		}

		#region Internal Methods

		private static void AddStepAttribute( TimeFormat timeFormat, IDictionary<string, object> htmlAttributes )
		{
			if( !htmlAttributes.ContainsKey( HtmlAttributes.Step ) )
			{
				double? stepValue = timeFormat.GetStepValue();
				if( stepValue.HasValue )
				{
					htmlAttributes[ HtmlAttributes.Step ] = stepValue.Value;
				}
			}
		}

		#endregion
	}
}
