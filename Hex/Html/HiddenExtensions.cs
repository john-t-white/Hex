﻿using Hex.AttributeBuilders;
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
	/// Represents support for HTML hidden inputs in an application with an expression for specifying HTML attributes.
	/// </summary>
	public static class HiddenExtensions
	{
		/// <summary>
		/// Returns a hidden input element by using the specified HTML helper, the name of the form field, and the HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field and the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> key that is used to look up the value.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "hidden".</returns>
		public static MvcHtmlString Hidden( this HtmlHelper htmlHelper, string name, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.Hidden( name, null, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a hidden input element by using the specified HTML helper, the name of the form field, the value, and the HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field and the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> key that is used to look up the value.</param>
		/// <param name="value">
		///		The value of the hidden input element The value of the element is retrieved from the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object.
		///		If no value exists there, the value is retrieved from the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object.
		///		If the element is not found in the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> object or the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object, the value parameter is used.
		/// </param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "hidden".</returns>
		public static MvcHtmlString Hidden( this HtmlHelper htmlHelper, string name, object value, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.Hidden( name, value, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns an HTML hidden input element for each property in the object that is represented by the specified expression, using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "hidden" for each property in the object that is represented by the expression.</returns>
		public static MvcHtmlString HiddenFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.HiddenFor( expression, attributeExpression.GetAttributes() );
		}
	}
}
