using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Hex.Extensions;
using Hex.AttributeBuilders;
using System.Linq.Expressions;

namespace Hex.Html
{
	/// <summary>
	/// Represents support for HTML drop down lists in an application with an expression for specifying HTML attributes.
	/// </summary>
	public static class DropDownListExtensions
	{
		/// <summary>
		/// Returns a single-selection select element using the specified HTML helper, the name of the form field, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML select element.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="name" /> parameter is null or empty.</exception>
		public static MvcHtmlString DropDownList( this HtmlHelper htmlHelper, string name, Action<DropDownListAttributeBuilder> attributeExpression )
		{
			return htmlHelper.DropDownList( name, null, null, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a single-selection select element using the specified HTML helper, the name of the form field, an option label, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="optionLabel">The text for a default empty item. This parameter can be null.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML select element.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="name" /> parameter is null or empty.</exception>
		public static MvcHtmlString DropDownList( this HtmlHelper htmlHelper, string name, string optionLabel, Action<DropDownListAttributeBuilder> attributeExpression )
		{
			return htmlHelper.DropDownList( name, null, optionLabel, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a single-selection select element using the specified HTML helper, the name of the form field, the specified list items, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="selectList">A collection of <see cref="T:System.Web.Mvc.SelectListItem" /> objects that are used to populate the drop-down list.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML select element.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="name" /> parameter is null or empty.</exception>
		public static MvcHtmlString DropDownList( this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, Action<DropDownListAttributeBuilder> attributeExpression )
		{
			return htmlHelper.DropDownList( name, selectList, null, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a single-selection select element using the specified HTML helper, the name of the form field, the specified list items, an option label, and the specified HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="selectList">A collection of <see cref="T:System.Web.Mvc.SelectListItem" /> objects that are used to populate the drop-down list.</param>
		/// <param name="optionLabel">The text for a default empty item. This parameter can be null.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML select element.</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="name" /> parameter is null or empty.</exception>
		public static MvcHtmlString DropDownList( this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, string optionLabel, Action<DropDownListAttributeBuilder> attributeExpression )
		{
			return htmlHelper.DropDownList( name, selectList, optionLabel, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an HTML select element for each property in the object that is represented by the specified expression using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the value.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML select element for each property in the object that is represented by the expression.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString DropDownListFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Action<DropDownListAttributeBuilder> attributeExpression )
		{
			return htmlHelper.DropDownListFor( expression, null, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an HTML select element for each property in the object that is represented by the specified expression, an option label, and the specified HTML attributes
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the value.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
		/// <param name="optionLabel">The text for a default empty item. This parameter can be null.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML select element for each property in the object that is represented by the expression.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString DropDownListFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string optionLabel, Action<DropDownListAttributeBuilder> attributeExpression )
		{
			return htmlHelper.DropDownListFor( expression, null, optionLabel, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an HTML select element for each property in the object that is represented by the specified expression using the specified list items and HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the value.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
		/// <param name="selectList">A collection of <see cref="T:System.Web.Mvc.SelectListItem" /> objects that are used to populate the drop-down list.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML select element for each property in the object that is represented by the expression.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString DropDownListFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, Action<DropDownListAttributeBuilder> attributeExpression )
		{
			return htmlHelper.DropDownListFor( expression, selectList, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an HTML select element for each property in the object that is represented by the specified expression using the specified list items, option label, and HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the value.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
		/// <param name="selectList">A collection of <see cref="T:System.Web.Mvc.SelectListItem" /> objects that are used to populate the drop-down list.</param>
		/// <param name="optionLabel">The text for a default empty item. This parameter can be null.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML select element for each property in the object that is represented by the expression.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString DropDownListFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, Action<DropDownListAttributeBuilder> attributeExpression )
		{
			return htmlHelper.DropDownListFor( expression, selectList, optionLabel, attributeExpression.GetAttributes() );
		}
	}
}
