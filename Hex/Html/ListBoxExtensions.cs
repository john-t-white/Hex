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
	public static class ListBoxExtensions
	{
		public static MvcHtmlString ListBox( this HtmlHelper htmlHelper, string name, Action<ListBoxAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ListBox( name, null, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString ListBox( this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, Action<ListBoxAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ListBox( name, selectList, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString ListBoxFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Action<ListBoxAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ListBoxFor<TModel, TProperty>( expression, null, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString ListBoxFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, Action<ListBoxAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ListBoxFor<TModel, TProperty>( expression, selectList, attributeExpression.GetAttributes() );
		}
	}
}
