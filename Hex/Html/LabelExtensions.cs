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
	public static class LabelExtensions
	{
		public static MvcHtmlString Label( this HtmlHelper htmlHelper, string expression, Action<LabelAttributeBuilder> attributeExpression )
		{
			return htmlHelper.Label( expression, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString Label( this HtmlHelper htmlHelper, string expression, string labelText, Action<LabelAttributeBuilder> attributeExpression )
		{
			return htmlHelper.Label( expression, labelText, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString LabelFor<TModel, TValue>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, Action<LabelAttributeBuilder> attributeExpression )
		{
			return htmlHelper.LabelFor( expression, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString LabelFor<TModel, TValue>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, string labelText, Action<LabelAttributeBuilder> attributeExpression )
		{
			return htmlHelper.LabelFor( expression, labelText, attributeExpression.GetAttributes() );
		}
	}
}
