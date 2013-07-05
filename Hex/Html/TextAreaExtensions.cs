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
	public static class TextAreaExtensions
	{
		public static MvcHtmlString TextArea( this HtmlHelper htmlHelper, string name, Action<TextAreaAttributeBuilder> attributeExpression )
		{
			return htmlHelper.TextArea( name, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString TextArea( this HtmlHelper htmlHelper, string name, string value, Action<TextAreaAttributeBuilder> attributeExpression )
		{
			return htmlHelper.TextArea( name, value, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString TextArea( this HtmlHelper htmlHelper, string name, string value, int rows, int columns, Action<TextAreaAttributeBuilder> attributeExpression )
		{
			return htmlHelper.TextArea( name, value, rows, columns, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString TextAreaFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Action<TextAreaAttributeBuilder> attributeExpression )
		{
			return htmlHelper.TextAreaFor( expression, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString TextAreaFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int rows, int columns, Action<TextAreaAttributeBuilder> attributeExpression )
		{
			return htmlHelper.TextAreaFor( expression, rows, columns, attributeExpression.GetAttributes() );
		}
	}
}
