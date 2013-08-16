using Hex.AttributeBuilders;
using Hex.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;

namespace Hex.Html
{
	public static partial class CheckBoxExtensions
	{
		public static MvcHtmlString CheckBoxFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TProperty>>> expression, TProperty value )
		{
			return htmlHelper.CheckBoxFor( expression, value, ( IDictionary<string, object> )null );
		}

		public static MvcHtmlString CheckBoxFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TProperty>>> expression, TProperty value, object htmlAttributes )
		{
			return htmlHelper.CheckBoxFor( expression, value, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		public static MvcHtmlString CheckBoxFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TProperty>>> expression, TProperty value, IDictionary<string, object> htmlAttributes )
		{
			ModelMetadata modelMetadata = ModelMetadata.FromLambdaExpression( expression, htmlHelper.ViewData );

			return CheckBoxExtensions.CheckBoxWithValueBuilder( htmlHelper, modelMetadata, ExpressionHelper.GetExpressionText( expression ), value, htmlAttributes );
		}

		public static MvcHtmlString CheckBoxFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TProperty>>> expression, TProperty value, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.CheckBoxFor( expression, value, attributeExpression.GetAttributes() );
		}

		#region Internal Methods

		private static MvcHtmlString CheckBoxWithValueBuilder<TModel, TProperty>( HtmlHelper<TModel> htmlHelper, ModelMetadata modelMetadata, string name, TProperty value, IDictionary<string, object> htmlAttributes )
		{
			string fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName( name );
			string formattedValue = htmlHelper.FormatValue( value, null );

			TagBuilder tagBuilder = new TagBuilder( "input" );
			tagBuilder.MergeAttributes<string, object>( htmlAttributes );
			tagBuilder.MergeAttribute( HtmlAttributes.Type, HtmlHelper.GetInputTypeString( InputType.CheckBox ) );
			tagBuilder.MergeAttribute( HtmlAttributes.Name, fullHtmlFieldName, true );
			tagBuilder.MergeAttribute( HtmlAttributes.Id, CheckBoxExtensions.GetCheckBoxWithValueId( htmlHelper, fullHtmlFieldName, formattedValue ) );
			tagBuilder.MergeAttribute( HtmlAttributes.Value, formattedValue, true );
			tagBuilder.MergeAttributes( htmlHelper.GetUnobtrusiveValidationAttributes( name, modelMetadata ) );

			ModelState modelState;
			if( htmlHelper.ViewData.ModelState.TryGetValue( fullHtmlFieldName, out modelState ) )
			{
				if( modelState.Errors.Count > 0 )
				{
					tagBuilder.AddCssClass( HtmlHelper.ValidationInputCssClassName );
				}
			}

			if( modelMetadata.Model != null )
			{
				var modelValues = ( from TProperty currentValue in ( IEnumerable<TProperty> )modelMetadata.Model
									select htmlHelper.FormatValue( currentValue, null ) );

				if( modelValues.Any( x => x == formattedValue ) )
				{
					tagBuilder.MergeAttribute( HtmlAttributes.Checked, HtmlAttributes.Checked );
				}
			}

			return MvcHtmlString.Create( tagBuilder.ToString( TagRenderMode.SelfClosing ) );
		}

		private static string GetCheckBoxWithValueId( HtmlHelper htmlhelper, string fullHtmlFieldName, string formattedValue )
		{
			return TagBuilder.CreateSanitizedId( string.Format( "{0}.{1}", fullHtmlFieldName, formattedValue ) );
		}

		#endregion
	}
}
