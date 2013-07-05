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
	public static class PasswordExtensions
	{
		public static MvcHtmlString Password( this HtmlHelper htmlHelper, string name, Action<PasswordAttributeBuilder> attributeExpression )
		{
			return htmlHelper.Password( name, null, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString Password( this HtmlHelper htmlHelper, string name, object value, Action<PasswordAttributeBuilder> attributeExpression )
		{
			return htmlHelper.Password( name, value, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString PasswordFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Action<PasswordAttributeBuilder> attributeExpression )
		{
			return htmlHelper.PasswordFor( expression, attributeExpression.GetAttributes() );
		}
	}
}
