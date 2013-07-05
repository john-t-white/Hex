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
	public static class TextBoxExtensions
	{
		public static MvcHtmlString TextBox( this HtmlHelper htmlHelper, string name, Action<TextBoxAttributeBuilder> attributeExpression )
		{
			return htmlHelper.TextBox( name, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString TextBox( this HtmlHelper htmlHelper, string name, string value, Action<TextBoxAttributeBuilder> attributeExpression )
		{
			return htmlHelper.TextBox( name, value, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString TextBox( this HtmlHelper htmlHelper, string name, string value, string format, Action<TextBoxAttributeBuilder> attributeExpression )
		{
			return htmlHelper.TextBox( name, value, format, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString TextBoxFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Action<TextBoxAttributeBuilder> attributeExpression )
		{
			return htmlHelper.TextBoxFor( expression, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString TTextBoxFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string format, Action<TextBoxAttributeBuilder> attributeExpression )
		{
			return htmlHelper.TextBoxFor( expression, format, attributeExpression.GetAttributes() );
		}
	}
}
