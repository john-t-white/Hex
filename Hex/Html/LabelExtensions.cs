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
	/// Represents support for HTML label element with an expression for specifying HTML attributes.
	/// </summary>
	public static class LabelExtensions
	{
		/// <summary>
		/// Returns an HTML label element and the property name of the property that is represented by the specified expression.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the property to display.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML label element and the property name of the property that is represented by the expression.</returns>
		public static MvcHtmlString Label( this HtmlHelper htmlHelper, string expression, Action<LabelAttributeBuilder> attributeExpression )
		{
			return htmlHelper.Label( expression, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an HTML label element and the property name of the property that is represented by the specified expression.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the property to display.</param>
		/// <param name="labelText">The label text.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML label element and the property name of the property that is represented by the expression.</returns>
		public static MvcHtmlString Label( this HtmlHelper htmlHelper, string expression, string labelText, Action<LabelAttributeBuilder> attributeExpression )
		{
			return htmlHelper.Label( expression, labelText, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an HTML label element and the property name of the property that is represented by the specified expression.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TValue">The type of value.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the property to display.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML label element and the property name of the property that is represented by the expression.</returns>
		public static MvcHtmlString LabelFor<TModel, TValue>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, Action<LabelAttributeBuilder> attributeExpression )
		{
			return htmlHelper.LabelFor( expression, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an HTML label element and the property name of the property that is represented by the specified expression.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TValue">The type of value.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the property to display.</param>
		/// <param name="labelText">The label text.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML label element and the property name of the property that is represented by the expression.</returns>
		public static MvcHtmlString LabelFor<TModel, TValue>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, string labelText, Action<LabelAttributeBuilder> attributeExpression )
		{
			return htmlHelper.LabelFor( expression, labelText, attributeExpression.GetAttributes() );
		}
	}
}
