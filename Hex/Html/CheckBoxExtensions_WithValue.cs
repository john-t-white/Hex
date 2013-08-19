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
	/// <summary>
	/// Represents support for HTML check boxes and specifying a value in an application.
	/// </summary>
	public static partial class CheckBoxExtensions
	{
		/// <summary>
		/// Returns a check box input element by using the specified HTML helper and the value.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="value">The value of the checkbox.</param>
		/// <returns>An input element whose type attribute is set to "checkbox" and the value attribute set to <paramref name="value"/>.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="value" /> parameter is null.</exception>
		public static MvcHtmlString CheckBoxFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TProperty>>> expression, TProperty value )
		{
			return htmlHelper.CheckBoxFor( expression, value, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns a check box input element by using the specified HTML helper, the value and the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="value">The value of the checkbox.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "checkbox" and the value attribute set to <paramref name="value"/>.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="value" /> parameter is null.</exception>
		public static MvcHtmlString CheckBoxFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TProperty>>> expression, TProperty value, object htmlAttributes )
		{
			return htmlHelper.CheckBoxFor( expression, value, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Returns a check box input element by using the specified HTML helper, the value and the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="value">The value of the checkbox.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "checkbox" and the value attribute set to <paramref name="value"/>.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="value" /> parameter is null.</exception>
		public static MvcHtmlString CheckBoxFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TProperty>>> expression, TProperty value, IDictionary<string, object> htmlAttributes )
		{
			ModelMetadata modelMetadata = ModelMetadata.FromLambdaExpression( expression, htmlHelper.ViewData );

			return CheckBoxExtensions.CheckBoxWithValueBuilder( htmlHelper, modelMetadata, ExpressionHelper.GetExpressionText( expression ), value, htmlAttributes );
		}

		/// <summary>
		/// Returns a check box input element by using the specified HTML helper, the value and the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="value">The value of the checkbox.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "checkbox" and the value attribute set to <paramref name="value"/>.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="value" /> parameter is null.</exception>
		public static MvcHtmlString CheckBoxFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TProperty>>> expression, TProperty value, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.CheckBoxFor( expression, value, attributeExpression.GetAttributes() );
		}

		#region Internal Methods

		private static MvcHtmlString CheckBoxWithValueBuilder<TModel, TProperty>( HtmlHelper<TModel> htmlHelper, ModelMetadata modelMetadata, string name, TProperty value, IDictionary<string, object> htmlAttributes )
		{
			if( value == null )
			{
				throw new ArgumentNullException( "value " );
			}

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
