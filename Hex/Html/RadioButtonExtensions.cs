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
	/// Represents support for HTML radio buttons in an application with an expression for specifying HTML attributes.
	/// </summary>
	public static class RadioButtonExtensions
	{
		/// <summary>
		/// Returns a radio button input element that is used to present mutually exclusive options.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field and the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> key that is used to look up the value.</param>
		/// <param name="value">
		///		If this radio button is selected, the value of the radio button that is submitted when the form is posted.
		///		If the value of the selected radio button in the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> or the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object matches this value, this radio button is selected.
		/// </param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "radio".</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="name" /> parameter is null or empty.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="value" /> parameter is null.</exception>
		public static MvcHtmlString RadioButton( this HtmlHelper htmlHelper, string name, object value, Action<RadioButtonAttributeBuilder> attributeExpression )
		{
			return htmlHelper.RadioButton( name, value, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a radio button input element that is used to present mutually exclusive options.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field and the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> key that is used to look up the value.</param>
		/// <param name="value">
		///		If this radio button is selected, the value of the radio button that is submitted when the form is posted.
		///		If the value of the selected radio button in the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> or the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object matches this value, this radio button is selected.
		///	</param>
		/// <param name="isChecked">true to select the radio button; otherwise, false.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "radio".</returns>
		/// <exception cref="T:System.ArgumentException">The <paramref name="name" /> parameter is null or empty.</exception>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="value" /> parameter is null.</exception>
		public static MvcHtmlString RadioButton( this HtmlHelper htmlHelper, string name, object value, bool isChecked, Action<RadioButtonAttributeBuilder> attributeExpression )
		{
			return htmlHelper.RadioButton( name, value, isChecked, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a radio button input element for each property in the object that is represented by the specified expression, using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the value.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="value">
		///		If this radio button is selected, the value of the radio button that is submitted when the form is posted.
		///		If the value of the selected radio button in the <see cref="T:System.Web.Mvc.ViewDataDictionary" /> or the <see cref="T:System.Web.Mvc.ModelStateDictionary" /> object matches this value, this radio button is selected.
		/// </param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML input element whose type attribute is set to "radio" for each property in the object that is represented by the specified expression, using the specified HTML attributes.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="value" /> parameter is null.</exception>
		public static MvcHtmlString RadioButtonFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object value, Action<RadioButtonAttributeBuilder> attributeExpression )
		{
			return htmlHelper.RadioButtonFor( expression, value, attributeExpression.GetAttributes() );
		}
	}
}
