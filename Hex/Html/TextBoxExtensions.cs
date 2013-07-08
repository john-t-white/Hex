using Hex.AttributeBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Hex.Extensions;
using System.Linq.Expressions;

namespace Hex.Html
{
	/// <summary>
	/// Represents support for HTML text box inputs in an application with an expression for specifying HTML attributes.
	/// </summary>
	public static class TextBoxExtensions
	{
		/// <summary>
		/// Returns a text input element by using the specified HTML helper, the name of the form field, and the HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field and the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> key that is used to look up the value.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "text".</returns>
		public static MvcHtmlString TextBox( this HtmlHelper htmlHelper, string name, Action<TextBoxAttributeBuilder> attributeExpression )
		{
			return htmlHelper.TextBox( name, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a text input element by using the specified HTML helper, the name of the form field, the value, and the HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field and the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> key that is used to look up the value.</param>
		/// <param name="value">
		///		The value of the text input element.
		///		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		///		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		/// </param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "text".</returns>
		public static MvcHtmlString TextBox( this HtmlHelper htmlHelper, string name, string value, Action<TextBoxAttributeBuilder> attributeExpression )
		{
			return htmlHelper.TextBox( name, value, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a text input element by using the specified HTML helper, the name of the form field, the value, the format, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field and the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> key that is used to look up the value.</param>
		/// <param name="value">
		///		The value of the text input element.
		///		If this value is null, the value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		///		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		/// </param>
		/// <param name="format">A string that is used to format the input.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "text".</returns>
		public static MvcHtmlString TextBox( this HtmlHelper htmlHelper, string name, string value, string format, Action<TextBoxAttributeBuilder> attributeExpression )
		{
			return htmlHelper.TextBox( name, value, format, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a text input element for each property in the object that is represented by the specified expression, using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the value.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML input element whose type attribute is set to "text" for each property in the object that is represented by the expression.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="expression" /> parameter is null or empty.</exception>
		public static MvcHtmlString TextBoxFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Action<TextBoxAttributeBuilder> attributeExpression )
		{
			return htmlHelper.TextBoxFor( expression, attributeExpression.GetAttributes() );
		}
		
		/// <summary>
		/// Returns a text input element for each property in the object that is represented by the specified expression, the format, and the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the value.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="format">A string that is used to format the input.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML input element whose type attribute is set to "text" for each property in the object that is represented by the expression.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="expression" /> parameter is null or empty.</exception>
		public static MvcHtmlString TextBoxFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string format, Action<TextBoxAttributeBuilder> attributeExpression )
		{
			return htmlHelper.TextBoxFor( expression, format, attributeExpression.GetAttributes() );
		}
	}
}
