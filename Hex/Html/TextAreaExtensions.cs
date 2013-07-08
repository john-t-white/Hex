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
	/// Represents support for HTML textarea controls with an expression for specifying HTML attributes.
	/// </summary>
	public static class TextAreaExtensions
	{
		/// <summary>
		/// Returns the specified textarea element by using the specified HTML helper and HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>The textarea element.</returns>
		public static MvcHtmlString TextArea( this HtmlHelper htmlHelper, string name, Action<TextAreaAttributeBuilder> attributeExpression )
		{
			return htmlHelper.TextArea( name, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns the specified textarea element by using the specified HTML helper, the name of the form field, the text content, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">The text content.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>The textarea element.</returns>
		public static MvcHtmlString TextArea( this HtmlHelper htmlHelper, string name, string value, Action<TextAreaAttributeBuilder> attributeExpression )
		{
			return htmlHelper.TextArea( name, value, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns the specified textarea element by using the specified HTML helper, the name of the form field, the text content, the number of rows and columns, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">The text content.</param>
		/// <param name="rows">The number of rows.</param>
		/// <param name="columns">The number of columns.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>The textarea element.</returns>
		public static MvcHtmlString TextArea( this HtmlHelper htmlHelper, string name, string value, int rows, int columns, Action<TextAreaAttributeBuilder> attributeExpression )
		{
			return htmlHelper.TextArea( name, value, rows, columns, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an HTML textarea element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML textarea element for each property in the object that is represented by the expression.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString TextAreaFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Action<TextAreaAttributeBuilder> attributeExpression )
		{
			return htmlHelper.TextAreaFor( expression, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an HTML textarea element for each property in the object that is represented by the specified expression using the specified HTML attributes and the number of rows and columns.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="rows">The number of rows.</param>
		/// <param name="columns">The number of columns.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML textarea element for each property in the object that is represented by the expression.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString TextAreaFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int rows, int columns, Action<TextAreaAttributeBuilder> attributeExpression )
		{
			return htmlHelper.TextAreaFor( expression, rows, columns, attributeExpression.GetAttributes() );
		}
	}
}
