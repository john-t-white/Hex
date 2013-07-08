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
	/// Represents support for HTML list boxes in an application with an expression for specifying HTML attributes.
	/// </summary>
	public static class ListBoxExtensions
	{
		/// <summary>
		/// Returns a multi-select select element using the specified HTML helper, the name of the form field, and the specified HMTL attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML select element with an option subelement for each item in the list.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="name" /> parameter is null or empty.</exception>
		public static MvcHtmlString ListBox( this HtmlHelper htmlHelper, string name, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ListBox( name, null, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a multi-select select element using the specified HTML helper, the name of the form field, the specified list items, and the specified HMTL attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="selectList">A collection of <see cref="T:System.Web.Mvc.SelectListItem" /> objects that are used to populate the list box.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML select element with an option subelement for each item in the list.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="name" /> parameter is null or empty.</exception>
		public static MvcHtmlString ListBox( this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ListBox( name, selectList, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an HTML select element for each property in the object that is represented by the specified expression and the specified HMTL attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML select element for each property in the object that is represented by the expression.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString ListBoxFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ListBoxFor( expression, null, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an HTML select element for each property in the object that is represented by the specified expression using the specified list items and specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
		/// <param name="selectList">A collection of <see cref="T:System.Web.Mvc.SelectListItem" /> objects that are used to populate the list box.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML select element for each property in the object that is represented by the expression.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString ListBoxFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ListBoxFor( expression, selectList, attributeExpression.GetAttributes() );
		}
	}
}
