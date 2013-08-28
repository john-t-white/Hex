using Hex.AttributeBuilders;
using Hex.Extensions;
using Hex.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;

namespace Hex.Html
{
	/// <summary>
	/// Represents support for HTML inputs of type "submit".
	/// </summary>
	public static class SubmitInputButtonExtensions
	{
		private const string INPUT_TYPE_SUBMIT = "submit";

		/// <summary>
		/// Returns a submit input element by using the specified HTML helper, the name of the form field and the value.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the submit button.</param>
		/// <param name="value">The value of the submit button.</param>
		/// <returns>An input element whose type attribute is set to "submit".</returns>
		public static MvcHtmlString SubmitInputButton( this HtmlHelper htmlHelper, string name, object value )
		{
			return htmlHelper.SubmitInputButton( name, value, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns a submit input element by using the specified HTML helper, the name of the form field, the value and the HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the submit button.</param>
		/// <param name="value">The value of the submit button.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "submit".</returns>
		public static MvcHtmlString SubmitInputButton( this HtmlHelper htmlHelper, string name, object value, object htmlAttributes )
		{
			return htmlHelper.SubmitInputButton( name, value, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Returns a submit input element by using the specified HTML helper, the name of the form field, the value and the HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the submit button.</param>
		/// <param name="value">The value of the submit button.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "submit".</returns>
		public static MvcHtmlString SubmitInputButton( this HtmlHelper htmlHelper, string name, object value, IDictionary<string, object> htmlAttributes )
		{
			return SubmitInputButtonExtensions.SubmitInputButtonBuilder( htmlHelper, name, value, htmlAttributes );
		}

		/// <summary>
		/// Returns a submit input element by using the specified HTML helper, the name of the form field, the value and the HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the submit button.</param>
		/// <param name="value">The value of the submit button.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "submit".</returns>
		public static MvcHtmlString SubmitInputButton( this HtmlHelper htmlHelper, string name, object value, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.SubmitInputButton( name, value, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a text input element for each property in the object that is represented by the specified expression.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the value.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="value">The value of the submit button.</param>
		/// <returns>An input element whose type attribute is set to "submit".</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="expression" /> parameter is null or empty.</exception>
		public static MvcHtmlString SubmitInputButtonFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, TProperty value )
		{
			return htmlHelper.SubmitInputButtonFor( expression, value, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns a text input element for each property in the object that is represented by the specified expression, using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the value.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="value">The value of the submit button.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "submit".</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="expression" /> parameter is null or empty.</exception>
		public static MvcHtmlString SubmitInputButtonFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, TProperty value, object htmlAttributes )
		{
			return htmlHelper.SubmitInputButtonFor( expression, value, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Returns a text input element for each property in the object that is represented by the specified expression, using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the value.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="value">The value of the submit button.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "submit".</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="expression" /> parameter is null or empty.</exception>
		public static MvcHtmlString SubmitInputButtonFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, TProperty value, IDictionary<string, object> htmlAttributes )
		{
			if( expression == null )
			{
				throw new ArgumentNullException( "expression" );
			}

			return SubmitInputButtonExtensions.SubmitInputButtonBuilder( htmlHelper, ExpressionHelper.GetExpressionText( expression ), value, htmlAttributes );
		}

		/// <summary>
		/// Returns a text input element for each property in the object that is represented by the specified expression, using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the value.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="value">The value of the submit button.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "submit".</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="expression" /> parameter is null or empty.</exception>
		public static MvcHtmlString SubmitInputButtonFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, TProperty value, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.SubmitInputButtonFor( expression, value, attributeExpression.GetAttributes() );
		}

		#region Internal Methods

		private static MvcHtmlString SubmitInputButtonBuilder( HtmlHelper htmlHelper, string name, object value, IDictionary<string, object> htmlAttributes )
		{
			string fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName( name );

			if( string.IsNullOrWhiteSpace( fullHtmlFieldName ) )
			{
				throw new ArgumentException( ExceptionMessages.VALUE_CANNOT_BE_NULL_OR_EMPTY, "name" );
			}

			TagBuilder tagBuilder = new TagBuilder( HtmlElements.Input );
			tagBuilder.MergeAttributes( htmlAttributes );
			tagBuilder.MergeAttribute( HtmlAttributes.Type, INPUT_TYPE_SUBMIT, true );
			tagBuilder.MergeAttribute( HtmlAttributes.Name, fullHtmlFieldName, true );
			tagBuilder.MergeAttribute( HtmlAttributes.Value, htmlHelper.FormatValue( value, null ), true );

			return new MvcHtmlString( tagBuilder.ToString( TagRenderMode.SelfClosing ) );
		}

		#endregion
	}
}
