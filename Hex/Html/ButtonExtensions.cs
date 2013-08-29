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
	/// Represents support for HTML5 button in an application with HTML attributes.
	/// </summary>
	public static class ButtonExtensions
	{
		/// <summary>
		/// Returns a button element by using the specified HTML helper, the name of the form field, the button text and the value.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="buttonText">The value of the form field to return.</param>
		/// <param name="value">The value of the button.</param>
		/// <returns>A button element whose type attribute is set to "button".</returns>
		public static MvcHtmlString Button( this HtmlHelper htmlHelper, string name, string buttonText, object value )
		{
			return htmlHelper.Button( name, buttonText, value, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns a button element by using the specified HTML helper, the name of the form field, the button text, the value and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="buttonText">The text of the button.</param>
		/// <param name="value">The value of the form field to return.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>A button element whose type attribute is set to "button".</returns>
		public static MvcHtmlString Button( this HtmlHelper htmlHelper, string name, string buttonText, object value, object htmlAttributes )
		{
			return htmlHelper.Button( name, buttonText, value, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Returns a button element by using the specified HTML helper, the name of the form field, the button text, the value and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="buttonText">The text of the button.</param>
		/// <param name="value">The value of the form field to return.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>A button element whose type attribute is set to "button".</returns>
		public static MvcHtmlString Button( this HtmlHelper htmlHelper, string name, string buttonText, object value, IDictionary<string, object> htmlAttributes )
		{
			return ButtonExtensions.ButtonBuilder( htmlHelper, name, buttonText, value, ButtonType.Button, htmlAttributes );
		}

		/// <summary>
		/// Returns a button element by using the specified HTML helper, the name of the form field, the button text, the value and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="buttonText">The text of the button.</param>
		/// <param name="value">The value of the form field to return.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>A button element whose type attribute is set to "button".</returns>
		public static MvcHtmlString Button( this HtmlHelper htmlHelper, string name, string buttonText, object value, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.Button( name, buttonText, value, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a button element for each property in the object that is represented by the specified expression.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="buttonText">The text of the button.</param>
		/// <param name="value">The value of the form field to return.</param>
		/// <returns>A button element whose type attribute is set to "button".</returns>
		public static MvcHtmlString ButtonFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string buttonText, TProperty value )
		{
			return htmlHelper.ButtonFor( expression, buttonText, value, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns a button element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="buttonText">The text of the button.</param>
		/// <param name="value">The value of the form field to return.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>A button element whose type attribute is set to "button".</returns>
		public static MvcHtmlString ButtonFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string buttonText, TProperty value, object htmlAttributes )
		{
			return htmlHelper.ButtonFor( expression, buttonText, value, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Returns a button element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="buttonText">The text of the button.</param>
		/// <param name="value">The value of the form field to return.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>A button element whose type attribute is set to "button".</returns>
		public static MvcHtmlString ButtonFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string buttonText, TProperty value, IDictionary<string, object> htmlAttributes )
		{
			return ButtonExtensions.ButtonBuilder( htmlHelper, ExpressionHelper.GetExpressionText( expression ), buttonText, value, ButtonType.Button, htmlAttributes );
		}

		/// <summary>
		/// Returns a button element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="buttonText">The text of the button.</param>
		/// <param name="value">The value of the form field to return.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>A button element whose type attribute is set to "button".</returns>
		public static MvcHtmlString ButtonFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string buttonText, TProperty value, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ButtonFor( expression, buttonText, value, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a button element by using the specified HTML helper, the name of the form field, the button text and the value.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="buttonText">The text of the button.</param>
		/// <param name="value">The value of the button.</param>
		/// <returns>A button element whose type attribute is set to "submit".</returns>
		public static MvcHtmlString SubmitButton( this HtmlHelper htmlHelper, string name, string buttonText, object value )
		{
			return htmlHelper.SubmitButton( name, buttonText, value, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns a button element by using the specified HTML helper, the name of the form field, the button text, the value and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="buttonText">The text of the button.</param>
		/// <param name="value">The value of the button.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>A button element whose type attribute is set to "submit".</returns>
		public static MvcHtmlString SubmitButton( this HtmlHelper htmlHelper, string name, string buttonText, object value, object htmlAttributes )
		{
			return htmlHelper.SubmitButton( name, buttonText, value, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Returns a button element by using the specified HTML helper, the name of the form field, the button text, the value and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="buttonText">The text of the button.</param>
		/// <param name="value">The value of the button.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>A button element whose type attribute is set to "submit".</returns>
		public static MvcHtmlString SubmitButton( this HtmlHelper htmlHelper, string name, string buttonText, object value, IDictionary<string, object> htmlAttributes )
		{
			return ButtonExtensions.ButtonBuilder( htmlHelper, name, buttonText, value, ButtonType.Submit, htmlAttributes );
		}

		/// <summary>
		/// Returns a button element by using the specified HTML helper, the name of the form field, the button text, the value and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="buttonText">The text of the button.</param>
		/// <param name="value">The value of the button.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>A button element whose type attribute is set to "submit".</returns>
		public static MvcHtmlString SubmitButton( this HtmlHelper htmlHelper, string name, string buttonText, object value, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.SubmitButton( name, buttonText, value, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a button element for each property in the object that is represented by the specified expression.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="buttonText">The text of the button.</param>
		/// <param name="value">The value of the button.</param>
		/// <returns>A button element whose type attribute is set to "submit".</returns>
		public static MvcHtmlString SubmitButtonFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string buttonText, TProperty value )
		{
			return htmlHelper.SubmitButtonFor( expression, buttonText, value, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns a button element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="buttonText">The text of the button.</param>
		/// <param name="value">The value of the button.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>A button element whose type attribute is set to "submit".</returns>
		public static MvcHtmlString SubmitButtonFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string buttonText, TProperty value, object htmlAttributes )
		{
			return htmlHelper.SubmitButtonFor( expression, buttonText, value, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Returns a button element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="buttonText">The text of the button.</param>
		/// <param name="value">The value of the button.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>A button element whose type attribute is set to "submit".</returns>
		public static MvcHtmlString SubmitButtonFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string buttonText, TProperty value, IDictionary<string, object> htmlAttributes )
		{
			return ButtonExtensions.ButtonBuilder( htmlHelper, ExpressionHelper.GetExpressionText( expression ), buttonText, value, ButtonType.Submit, htmlAttributes );
		}

		/// <summary>
		/// Returns a button element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="buttonText">The text of the button.</param>
		/// <param name="value">The value of the button.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>A button element whose type attribute is set to "submit".</returns>
		public static MvcHtmlString SubmitButtonFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string buttonText, TProperty value, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.SubmitButtonFor( expression, buttonText, value, attributeExpression.GetAttributes() );
		}

		#region Internal Methods

		private static MvcHtmlString ButtonBuilder( HtmlHelper htmlHelper, string name, string buttonText, object value, ButtonType buttonType, IDictionary<string, object> htmlAttributes )
		{
			string fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName( name );

			if( string.IsNullOrWhiteSpace( fullHtmlFieldName ) )
			{
				throw new ArgumentException( ExceptionMessages.VALUE_CANNOT_BE_NULL_OR_EMPTY, "name" );
			}

			string formattedValue = htmlHelper.FormatValue( value, null );

			TagBuilder tagBuilder = new TagBuilder( HtmlElements.Button );
			tagBuilder.MergeAttributes( htmlAttributes );
			tagBuilder.MergeAttribute( HtmlAttributes.Type, buttonType.ToLowerString(), true );
			tagBuilder.MergeAttribute( HtmlAttributes.Name, fullHtmlFieldName, true );
			tagBuilder.MergeAttribute( HtmlAttributes.Value, formattedValue, true );
			tagBuilder.SetInnerText( string.IsNullOrWhiteSpace( buttonText ) ? formattedValue : buttonText );

			return new MvcHtmlString( tagBuilder.ToString( TagRenderMode.Normal ) );
		}

		#endregion
	}
}
