using Hex.AttributeBuilders;
using Hex.Extensions;
using System;
using System.Collections;
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
	public static partial class CheckBoxListItemExtensions
	{
		public static MvcHtmlString CheckBoxListItem( this HtmlHelper htmlHelper, string name, object value )
		{
			return htmlHelper.CheckBoxListItem( name, value, null, ( IDictionary<string, object> )null );
		}

		public static MvcHtmlString CheckBoxListItem( this HtmlHelper htmlHelper, string name, object value, object htmlAttributes )
		{
			return htmlHelper.CheckBoxListItem( name, value, null, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		public static MvcHtmlString CheckBoxListItem( this HtmlHelper htmlHelper, string name, object value, IDictionary<string, object> htmlAttributes )
		{
			return htmlHelper.CheckBoxListItem( name, value, null, htmlAttributes );
		}

		public static MvcHtmlString CheckBoxListItem( this HtmlHelper htmlHelper, string name, object value, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.CheckBoxListItem( name, value, null, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString CheckBoxListItem( this HtmlHelper htmlHelper, string name, object value, IEnumerable selectedValues )
		{
			return htmlHelper.CheckBoxListItem( name, value, selectedValues, ( IDictionary<string, object> )null );
		}

		public static MvcHtmlString CheckBoxListItem( this HtmlHelper htmlHelper, string name, object value, IEnumerable selectedValues, object htmlAttributes )
		{
			return htmlHelper.CheckBoxListItem( name, value, selectedValues, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		public static MvcHtmlString CheckBoxListItem( this HtmlHelper htmlHelper, string name, object value, IEnumerable selectedValues, IDictionary<string, object> htmlAttributes )
		{
			ModelMetadata modelMetadata = ModelMetadata.FromStringExpression( name, htmlHelper.ViewData );

			return CheckBoxListItemExtensions.CheckBoxListItemBuilder( htmlHelper, modelMetadata, name, value, selectedValues, htmlAttributes );
		}

		public static MvcHtmlString CheckBoxListItem( this HtmlHelper htmlHelper, string name, object value, IEnumerable selectedValues, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.CheckBoxListItem( name, value, selectedValues, attributeExpression.GetAttributes() );
		}






		/// <summary>
		/// Returns a check box input element by using the specified HTML helper and the value.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="value">The value of the checkbox.</param>
		/// <returns>An input element whose type attribute is set to "checkbox" and the value attribute set to <paramref name="value"/>.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression"/> or <paramref name="value" /> parameter is null.</exception>
		public static MvcHtmlString CheckBoxListItemFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TProperty>>> expression, TProperty value )
		{
			return htmlHelper.CheckBoxListItemFor( expression, value, ( IDictionary<string, object> )null );
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
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression"/> or <paramref name="value" /> parameter is null.</exception>
		public static MvcHtmlString CheckBoxListItemFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TProperty>>> expression, TProperty value, object htmlAttributes )
		{
			return htmlHelper.CheckBoxListItemFor( expression, value, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
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
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression"/> or <paramref name="value" /> parameter is null.</exception>
		public static MvcHtmlString CheckBoxListItemFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TProperty>>> expression, TProperty value, IDictionary<string, object> htmlAttributes )
		{
			ModelMetadata modelMetadata = ModelMetadata.FromLambdaExpression( expression, htmlHelper.ViewData );

			return CheckBoxListItemExtensions.CheckBoxListItemBuilder( htmlHelper, modelMetadata, ExpressionHelper.GetExpressionText( expression ), value, null, htmlAttributes );
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
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="expression"/> or <paramref name="value" /> parameter is null.</exception>
		public static MvcHtmlString CheckBoxListItemFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TProperty>>> expression, TProperty value, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.CheckBoxListItemFor( expression, value, attributeExpression.GetAttributes() );
		}

		#region Internal Methods

		private static MvcHtmlString CheckBoxListItemBuilder( HtmlHelper htmlHelper, ModelMetadata modelMetadata, string name, object value, IEnumerable selectedValues, IDictionary<string, object> htmlAttributes )
		{
			if( value == null )
			{
				throw new ArgumentNullException( "value" );
			}

			string fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName( name );
			string formattedValue = htmlHelper.FormatValue( value, null );

			TagBuilder tagBuilder = new TagBuilder( "input" );
			tagBuilder.MergeAttributes<string, object>( htmlAttributes );
			tagBuilder.MergeAttribute( HtmlAttributes.Type, HtmlHelper.GetInputTypeString( InputType.CheckBox ) );
			tagBuilder.MergeAttribute( HtmlAttributes.Name, fullHtmlFieldName, true );
			tagBuilder.MergeAttribute( HtmlAttributes.Id, CheckBoxListItemExtensions.GetCheckBoxWithValueId( htmlHelper, fullHtmlFieldName, formattedValue ) );
			tagBuilder.MergeAttribute( HtmlAttributes.Value, formattedValue, true );
			tagBuilder.MergeAttributes( htmlHelper.GetUnobtrusiveValidationAttributes( name, modelMetadata ) );

			IEnumerable<string> modelValues = null;
			ModelState modelState = null;
			IEnumerable<string> modelStateValue = ( IEnumerable<string> )htmlHelper.ViewData.ModelState.GetModelStateValue( fullHtmlFieldName, typeof( IEnumerable<string> ), out modelState );
			if( modelStateValue != null || modelMetadata.Model != null )
			{
				if( selectedValues != null )
				{
					modelValues = modelStateValue;
				}
				else
				{
					modelValues = ( from object currentValue in ( IEnumerable )modelMetadata.Model
									select htmlHelper.FormatValue( currentValue, null ) );
				}
			}
			else if( selectedValues != null )
			{
				modelValues = ( from object currentValue in selectedValues
								select htmlHelper.FormatValue( currentValue, null ) );
			}

			if( modelValues != null && modelValues.Any( x => x == formattedValue ) )
			{
				tagBuilder.MergeAttribute( HtmlAttributes.Checked, HtmlAttributes.Checked );
			}

			if( modelState != null && modelState.Errors.Count > 0 )
			{
				tagBuilder.AddCssClass( HtmlHelper.ValidationInputCssClassName );
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
