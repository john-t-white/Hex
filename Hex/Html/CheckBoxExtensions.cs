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
using System.Collections;

namespace Hex.Html
{
	/// <summary>
	/// Represents support for HTML check boxes in an application with an expression for specifying HTML attributes.
	/// </summary>
	public static class CheckBoxExtensions
	{
		/// <summary>
		/// Returns a check box input element by using the specified HTML helper, the name of the form field, and the HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "checkbox".</returns>
		public static MvcHtmlString CheckBox( this HtmlHelper htmlHelper, string name, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.CheckBox( name, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a check box input element by using the specified HTML helper, the name of the form field, a value that indicates whether the check box is selected, and the HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field.</param>
		/// <param name="isChecked">true to select the check box; otherwise, false.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "checkbox".</returns>
		public static MvcHtmlString CheckBox( this HtmlHelper htmlHelper, string name, bool isChecked, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.CheckBox( name, isChecked, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a check box input element for each property in the object that is represented by the specified expression, using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML input element whose type attribute is set to "checkbox" for each property in the object that is represented by the specified expression.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression" /> parameter is null.</exception>
		public static MvcHtmlString CheckBoxFor<TModel>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.CheckBoxFor( expression, attributeExpression.GetAttributes() );
		}



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

			return htmlHelper.CheckBoxBuilder( modelMetadata, ExpressionHelper.GetExpressionText( expression ), value, htmlAttributes );
		}

		public static MvcHtmlString CheckBoxFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TProperty>>> expression, TProperty value, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.CheckBoxFor( expression, value, attributeExpression.GetAttributes() );
		}

		private static MvcHtmlString CheckBoxBuilder<TProperty>( this HtmlHelper htmlHelper, ModelMetadata modelMetadata, string name, TProperty value, IDictionary<string, object> htmlAttributes )
		{
			string fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName( name );
			string formattedValue = htmlHelper.FormatValue( value, null );

			TagBuilder tagBuilder = new TagBuilder( "input" );
			tagBuilder.MergeAttributes<string, object>( htmlAttributes );
			tagBuilder.MergeAttribute( HtmlAttributes.Type, HtmlHelper.GetInputTypeString( InputType.CheckBox ) );
			tagBuilder.MergeAttribute( HtmlAttributes.Name, fullHtmlFieldName, true );
			tagBuilder.MergeAttribute( HtmlAttributes.Value, formattedValue, true );

			IEnumerable<string> modelValues = new string[] {};
			ModelState modelState;
			if( htmlHelper.ViewData.ModelState.TryGetValue( fullHtmlFieldName, out modelState ) )
			{
				if( modelState.Value != null )
				{
					modelValues = ( IEnumerable<string> )modelState.Value.RawValue;
				}

				if( modelState.Errors.Count > 0 )
				{
					tagBuilder.AddCssClass( HtmlHelper.ValidationInputCssClassName );
				}
			}
			else if( modelMetadata.Model != null )
			{
				IEnumerable<TProperty> enumerableModel = ( IEnumerable<TProperty> )modelMetadata.Model;
				modelValues = ( from TProperty currentValue in enumerableModel
								select htmlHelper.FormatValue( currentValue, null ) ).ToArray();
			}

			if( modelValues.Any( x => x == formattedValue ) )
			{
				tagBuilder.MergeAttribute( HtmlAttributes.Checked, HtmlAttributes.Checked );
			}

			tagBuilder.MergeAttributes( htmlHelper.GetUnobtrusiveValidationAttributes( name, modelMetadata ) );
			tagBuilder.GenerateId( fullHtmlFieldName );

			return MvcHtmlString.Create( tagBuilder.ToString( TagRenderMode.SelfClosing ) );
		}
	}
}
