using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Hex.Extensions;
using Hex.AttributeBuilders;
using System.Linq.Expressions;

namespace Hex.Html
{
	public static class DropDownListExtensions
	{
		public static MvcHtmlString DropDownList( this HtmlHelper htmlHelper, string name, Action<DropDownListAttributeBuilder> attributeExpression )
		{
			return htmlHelper.DropDownList( name, null, null, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString DropDownList( this HtmlHelper htmlHelper, string name, string optionLabel, Action<DropDownListAttributeBuilder> attributeExpression )
		{
			return htmlHelper.DropDownList( name, null, optionLabel, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString DropDownList( this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, Action<DropDownListAttributeBuilder> attributeExpression )
		{
			return htmlHelper.DropDownList( name, selectList, null, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString DropDownList( this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, string optionLabel, Action<DropDownListAttributeBuilder> attributeExpression )
		{
			return htmlHelper.DropDownList( name, selectList, optionLabel, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString DropDownListFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Action<DropDownListAttributeBuilder> attributeExpression )
		{
			return htmlHelper.DropDownListFor<TModel, TProperty>( expression, null, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString DropDownListFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, Action<DropDownListAttributeBuilder> attributeExpression )
		{
			return htmlHelper.DropDownListFor<TModel, TProperty>( expression, selectList, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString DropDownListFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, Action<DropDownListAttributeBuilder> attributeExpression )
		{
			return htmlHelper.DropDownListFor<TModel, TProperty>( expression, selectList, optionLabel, attributeExpression.GetAttributes() );
		}
	}
}
