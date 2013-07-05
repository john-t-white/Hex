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
	public static class HiddenExtensions
	{
		public static MvcHtmlString Hidden( this HtmlHelper htmlHelper, string name, Action<HiddenAttributeBuilder> attributeExpression )
		{
			return htmlHelper.Hidden( name, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString Hidden( this HtmlHelper htmlHelper, string name, object value, Action<HiddenAttributeBuilder> attributeExpression )
		{
			return htmlHelper.Hidden( name, value, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString HiddenFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Action<HiddenAttributeBuilder> attributeExpression )
		{
			return htmlHelper.HiddenFor<TModel, TProperty>( expression, attributeExpression.GetAttributes() );
		}
	}
}
