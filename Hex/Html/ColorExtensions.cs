using Hex.AttributeBuilders;
using Hex.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Hex.Html
{
	/// <summary>
	/// Represents support for HTML5 color inputs in an application with an expression for specifying HTML attributes.
	/// </summary>
	public static class ColorExtensions
	{
		private const string COLOR_TYPE_ATTRIBUTE_VALUE = "color";

		public static MvcHtmlString Color( this HtmlHelper htmlHelper, string name )
		{
			return htmlHelper.Color( name, null, ( IDictionary<string, object> )null );
		}

		public static MvcHtmlString Color( this HtmlHelper htmlHelper, string name, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.Color( name, null, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString Color( this HtmlHelper htmlHelper, string name, object value )
		{
			return htmlHelper.Color( name, value, ( IDictionary<string, object> )null );
		}

		public static MvcHtmlString Color( this HtmlHelper htmlHelper, string name, object value, object htmlAttributes )
		{
			return htmlHelper.Color( name, value, new RouteValueDictionary( htmlAttributes ) );
		}

		public static MvcHtmlString Color( this HtmlHelper htmlHelper, string name, object value, IDictionary<string, object> htmlAttributes )
		{
			htmlAttributes = htmlAttributes ?? new RouteValueDictionary();
			htmlAttributes[ HtmlAttributes.Type ] = COLOR_TYPE_ATTRIBUTE_VALUE;

			return htmlHelper.TextBox( name, value, htmlAttributes );
		}

		public static MvcHtmlString Color( this HtmlHelper htmlHelper, string name, object value, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.Color( name, value, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString Color( this HtmlHelper htmlHelper, string name, Color value )
		{
			return htmlHelper.Color( name, value, ( IDictionary<string, object> )null );
		}

		public static MvcHtmlString Color( this HtmlHelper htmlHelper, string name, Color value, object htmlAttributes )
		{
			return htmlHelper.Color( name, value, new RouteValueDictionary( htmlAttributes ) );
		}

		public static MvcHtmlString Color( this HtmlHelper htmlHelper, string name, Color value, IDictionary<string, object> htmlAttributes )
		{
			return htmlHelper.Color( name, value.ToHtml(), htmlAttributes );
		}

		public static MvcHtmlString Color( this HtmlHelper htmlHelper, string name, Color value, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.Color( name, value, attributeExpression.GetAttributes() );
		}



		public static MvcHtmlString ColorFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression )
		{
			return htmlHelper.ColorFor( expression, ( IDictionary<string, object> )null );
		}

		public static MvcHtmlString ColorFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes )
		{
			return htmlHelper.ColorFor( expression, new RouteValueDictionary( htmlAttributes ) );
		}

		public static MvcHtmlString ColorFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes )
		{
			htmlAttributes = htmlAttributes ?? new RouteValueDictionary();
			htmlAttributes[ HtmlAttributes.Type ] = COLOR_TYPE_ATTRIBUTE_VALUE;

			return htmlHelper.TextBoxFor( expression, htmlAttributes );
		}

		public static MvcHtmlString ColorFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ColorFor( expression, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString ColorFor<TModel>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, Color>> expression )
		{
			return htmlHelper.ColorFor( expression, ( IDictionary<string, object> )null );
		}

		public static MvcHtmlString ColorFor<TModel>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, Color>> expression, object htmlAttributes )
		{
			return htmlHelper.ColorFor( expression, new RouteValueDictionary( htmlAttributes ) );
		}

		public static MvcHtmlString ColorFor<TModel>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, Color>> expression, IDictionary<string, object> htmlAttributes )
		{
			htmlAttributes = htmlAttributes ?? new RouteValueDictionary();
			htmlAttributes[ HtmlAttributes.Type ] = COLOR_TYPE_ATTRIBUTE_VALUE;

			Color value = expression.Compile()( htmlHelper.ViewData.Model );

			return htmlHelper.TextBox( ExpressionHelper.GetExpressionText( expression ), value.ToHtml(), htmlAttributes );
		}

		public static MvcHtmlString ColorFor<TModel>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, Color>> expression, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.ColorFor( expression, attributeExpression.GetAttributes() );
		}
	}
}
