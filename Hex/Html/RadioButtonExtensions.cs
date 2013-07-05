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
	public static class RadioButtonExtensions
	{
		public static MvcHtmlString RadioButton( this HtmlHelper htmlHelper, string name, object value, Action<RadioButtonAttributeBuilder> attributeExpression )
		{
			return htmlHelper.RadioButton( name, value, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString RadioButton( this HtmlHelper htmlHelper, string name, object value, bool isChecked, Action<RadioButtonAttributeBuilder> attributeExpression )
		{
			return htmlHelper.RadioButton( name, value, isChecked, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString RadioButtonFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object value, Action<RadioButtonAttributeBuilder> attributeExpression )
		{
			return htmlHelper.RadioButtonFor( expression, value, attributeExpression.GetAttributes() );
		}
	}
}
