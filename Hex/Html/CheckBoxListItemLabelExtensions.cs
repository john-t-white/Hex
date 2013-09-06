using Hex.AttributeBuilders;
using Hex.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Hex.Html
{
	/// <summary>
	/// Represents support for HTML label element for individual checkboxes in a list.
	/// </summary>
	public static class CheckBoxListItemLabelExtensions
	{
		/// <summary>
		/// Returns an HTML label element and the property name of the property that is represented by the specified expression with the label text as the value of the checkbox.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the property to display.</param>
		/// <param name="value">The value of the checkbox.</param>
		/// <returns>An HTML label element and the property name of the property that is represented by the expression.</returns>
		public static MvcHtmlString CheckBoxListItemLabel( this HtmlHelper htmlHelper, string expression, object value )
		{
			return htmlHelper.CheckBoxListItemLabel( expression, value, null, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns an HTML label element and the property name of the property that is represented by the specified expression with the label text as the value of the checkbox.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the property to display.</param>
		/// <param name="value">The value of the checkbox.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML label element and the property name of the property that is represented by the expression.</returns>
		public static MvcHtmlString CheckBoxListItemLabel( this HtmlHelper htmlHelper, string expression, object value, object htmlAttributes )
		{
			return htmlHelper.CheckBoxListItemLabel( expression, value, null, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Returns an HTML label element and the property name of the property that is represented by the specified expression with the label text as the value of the checkbox.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the property to display.</param>
		/// <param name="value">The value of the checkbox.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML label element and the property name of the property that is represented by the expression.</returns>
		public static MvcHtmlString CheckBoxListItemLabel( this HtmlHelper htmlHelper, string expression, object value, IDictionary<string, object> htmlAttributes )
		{
			return htmlHelper.CheckBoxListItemLabel( expression, value, null, htmlAttributes );
		}

		/// <summary>
		/// Returns an HTML label element and the property name of the property that is represented by the specified expression with the label text as the value of the checkbox.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the property to display.</param>
		/// <param name="value">The value of the checkbox.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML label element and the property name of the property that is represented by the expression.</returns>
		public static MvcHtmlString CheckBoxListItemLabel( this HtmlHelper htmlHelper, string expression, object value, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.CheckBoxListItemLabel( expression, value, null, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an HTML label element and the property name of the property that is represented by the specified expression.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the property to display.</param>
		/// <param name="value">The value of the checkbox.</param>
		/// <param name="labelText">The label text.</param>
		/// <returns>An HTML label element and the property name of the property that is represented by the expression.</returns>
		public static MvcHtmlString CheckBoxListItemLabel( this HtmlHelper htmlHelper, string expression, object value, string labelText )
		{
			return htmlHelper.CheckBoxListItemLabel( expression, value, labelText, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns an HTML label element and the property name of the property that is represented by the specified expression.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the property to display.</param>
		/// <param name="value">The value of the checkbox.</param>
		/// <param name="labelText">The label text.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML label element and the property name of the property that is represented by the expression.</returns>
		public static MvcHtmlString CheckBoxListItemLabel( this HtmlHelper htmlHelper, string expression, object value, string labelText, object htmlAttributes )
		{
			return htmlHelper.CheckBoxListItemLabel( expression, value, labelText, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Returns an HTML label element and the property name of the property that is represented by the specified expression.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the property to display.</param>
		/// <param name="value">The value of the checkbox.</param>
		/// <param name="labelText">The label text.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML label element and the property name of the property that is represented by the expression.</returns>
		public static MvcHtmlString CheckBoxListItemLabel( this HtmlHelper htmlHelper, string expression, object value, string labelText, IDictionary<string, object> htmlAttributes )
		{
			string fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName( expression );
			string formattedValue = htmlHelper.FormatValue( value, null );

			htmlAttributes = htmlAttributes ?? new Dictionary<string, object>();
			htmlAttributes[ "for" ] = TagBuilder.CreateSanitizedId( string.Format( "{0}.{1}", fullHtmlFieldName, formattedValue ) );

			if( string.IsNullOrWhiteSpace( labelText ) )
			{
				labelText = formattedValue;
			}

			return htmlHelper.Label( expression, labelText, htmlAttributes );
		}

		/// <summary>
		/// Returns an HTML label element and the property name of the property that is represented by the specified expression.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the property to display.</param>
		/// <param name="value">The value of the checkbox.</param>
		/// <param name="labelText">The label text.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML label element and the property name of the property that is represented by the expression.</returns>
		public static MvcHtmlString CheckBoxListItemLabel( this HtmlHelper htmlHelper, string expression, object value, string labelText, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.CheckBoxListItemLabel( expression, value, labelText, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an HTML label element and the property name of the property that is represented by the specified expression with the label text as the value of the checkbox.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the property to display.</param>
		/// <param name="value">The value of the checkbox.</param>
		/// <returns>An HTML label element and the property name of the property that is represented by the expression.</returns>
		public static MvcHtmlString CheckBoxListItemLabelFor<TModel, TValue>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TValue>>> expression, TValue value )
		{
			return htmlHelper.CheckBoxListItemLabelFor( expression, value, null, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns an HTML label element and the property name of the property that is represented by the specified expression with the label text as the value of the checkbox.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the property to display.</param>
		/// <param name="value">The value of the checkbox.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML label element and the property name of the property that is represented by the expression.</returns>
		public static MvcHtmlString CheckBoxListItemLabelFor<TModel, TValue>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TValue>>> expression, TValue value, object htmlAttributes )
		{
			return htmlHelper.CheckBoxListItemLabelFor( expression, value, null, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Returns an HTML label element and the property name of the property that is represented by the specified expression with the label text as the value of the checkbox.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the property to display.</param>
		/// <param name="value">The value of the checkbox.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML label element and the property name of the property that is represented by the expression.</returns>
		public static MvcHtmlString CheckBoxListItemLabelFor<TModel, TValue>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TValue>>> expression, TValue value, IDictionary<string, object> htmlAttributes )
		{
			return htmlHelper.CheckBoxListItemLabelFor( expression, value, null, htmlAttributes );
		}

		/// <summary>
		/// Returns an HTML label element and the property name of the property that is represented by the specified expression with the label text as the value of the checkbox.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the property to display.</param>
		/// <param name="value">The value of the checkbox.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML label element and the property name of the property that is represented by the expression.</returns>
		public static MvcHtmlString CheckBoxListItemLabelFor<TModel, TValue>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TValue>>> expression, TValue value, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.CheckBoxListItemLabelFor( expression, value, null, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an HTML label element and the property name of the property that is represented by the specified expression.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the property to display.</param>
		/// <param name="value">The value of the checkbox.</param>
		/// <param name="labelText">The label text.</param>
		/// <returns>An HTML label element and the property name of the property that is represented by the expression.</returns>
		public static MvcHtmlString CheckBoxListItemLabelFor<TModel, TValue>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TValue>>> expression, TValue value, string labelText )
		{
			return htmlHelper.CheckBoxListItemLabelFor( expression, value, labelText, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns an HTML label element and the property name of the property that is represented by the specified expression.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the property to display.</param>
		/// <param name="value">The value of the checkbox.</param>
		/// <param name="labelText">The label text.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML label element and the property name of the property that is represented by the expression.</returns>
		public static MvcHtmlString CheckBoxListItemLabelFor<TModel, TValue>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TValue>>> expression, TValue value, string labelText, object htmlAttributes )
		{
			return htmlHelper.CheckBoxListItemLabelFor( expression, value, labelText, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Returns an HTML label element and the property name of the property that is represented by the specified expression.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the property to display.</param>
		/// <param name="value">The value of the checkbox.</param>
		/// <param name="labelText">The label text.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML label element and the property name of the property that is represented by the expression.</returns>
		public static MvcHtmlString CheckBoxListItemLabelFor<TModel, TValue>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TValue>>> expression, TValue value, string labelText, IDictionary<string, object> htmlAttributes )
		{
			string expressionText = ExpressionHelper.GetExpressionText( expression );

			return htmlHelper.CheckBoxListItemLabel( expressionText, value, labelText, htmlAttributes );
		}

		/// <summary>
		/// Returns an HTML label element and the property name of the property that is represented by the specified expression.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the property to display.</param>
		/// <param name="value">The value of the checkbox.</param>
		/// <param name="labelText">The label text.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML label element and the property name of the property that is represented by the expression.</returns>
		public static MvcHtmlString CheckBoxListItemLabelFor<TModel, TValue>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TValue>>> expression, TValue value, string labelText, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.CheckBoxListItemLabelFor( expression, value, labelText, attributeExpression.GetAttributes() );
		}
	}
}
