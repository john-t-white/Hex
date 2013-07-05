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
	public static class CheckBoxExtensions
	{
		public static MvcHtmlString CheckBox( this HtmlHelper htmlHelper, string name, Action<CheckBoxAttributeBuilder> checkBoxAttributeExpression )
		{
			return htmlHelper.CheckBox( name, checkBoxAttributeExpression.GetAttributes() );
		}

		public static MvcHtmlString CheckBox( this HtmlHelper htmlHelper, string name, bool isChecked, Action<CheckBoxAttributeBuilder> checkBoxAttributeExpression )
		{
			return htmlHelper.CheckBox( name, isChecked, checkBoxAttributeExpression.GetAttributes() );
		}

		public static MvcHtmlString CheckBoxFor<TModel>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, Action<CheckBoxAttributeBuilder> checkBoxAttributeExpression )
		{
			return htmlHelper.CheckBoxFor( expression, checkBoxAttributeExpression.GetAttributes() );
		}
	}
}
