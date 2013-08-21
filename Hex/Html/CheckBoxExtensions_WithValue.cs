using Hex.AttributeBuilders;
using Hex.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Linq.Expressions;
using System.Collections;

namespace Hex.Html
{
	/// <summary>
	/// Represents support for HTML checkbox with a value in an application with an expression for specifying HTML attributes.
	/// </summary>
	public static partial class CheckBoxExtensions
	{
		private const string INPUT_ELEMENT = "input";

		/// <summary>
		/// Returns a check box input element with the specified values for checked and unchecked by using the specified HTML helper and the name of the form field.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field.</param>
		/// <param name="checkedValue">The value when it is checked.</param>
		/// <param name="uncheckedValue">The value when it is unchecked.</param>
		/// <returns>An input element whose type attribute is set to "checkbox".</returns>
		public static MvcHtmlString CheckBox( this HtmlHelper htmlHelper, string name, object checkedValue, object uncheckedValue )
		{
			return htmlHelper.CheckBox( name, checkedValue, uncheckedValue, false, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns a check box input element with the specified values for checked and unchecked by using the specified HTML helper, the name of the form field and the HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field.</param>
		/// <param name="checkedValue">The value when it is checked.</param>
		/// <param name="uncheckedValue">The value when it is unchecked.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "checkbox".</returns>
		public static MvcHtmlString CheckBox( this HtmlHelper htmlHelper, string name, object checkedValue, object uncheckedValue, object htmlAttributes )
		{
			return htmlHelper.CheckBox( name, checkedValue, uncheckedValue, false, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Returns a check box input element with the specified values for checked and unchecked by using the specified HTML helper and the name of the form field.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field.</param>
		/// <param name="checkedValue">The value when it is checked.</param>
		/// <param name="uncheckedValue">The value when it is unchecked.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "checkbox".</returns>
		public static MvcHtmlString CheckBox( this HtmlHelper htmlHelper, string name, object checkedValue, object uncheckedValue, IDictionary<string, object> htmlAttributes )
		{
			return htmlHelper.CheckBox( name, checkedValue, uncheckedValue, false, htmlAttributes );
		}

		/// <summary>
		/// Returns a check box input element with the specified values for checked and unchecked by using the specified HTML helper and the name of the form field.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field.</param>
		/// <param name="checkedValue">The value when it is checked.</param>
		/// <param name="uncheckedValue">The value when it is unchecked.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "checkbox".</returns>
		public static MvcHtmlString CheckBox( this HtmlHelper htmlHelper, string name, object checkedValue, object uncheckedValue, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.CheckBox( name, checkedValue, uncheckedValue, false, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a check box input element with the specified values for checked and unchecked by using the specified HTML helper, the name of the form field and a value to indicate whether the check box is selected.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field.</param>
		/// <param name="checkedValue">The value when it is checked.</param>
		/// <param name="uncheckedValue">The value when it is unchecked.</param>
		/// <param name="isChecked">true to select the check box; otherwise, false.</param>
		/// <returns>An input element whose type attribute is set to "checkbox".</returns>
		public static MvcHtmlString CheckBox( this HtmlHelper htmlHelper, string name, object checkedValue, object uncheckedValue, bool isChecked )
		{
			return htmlHelper.CheckBox( name, checkedValue, uncheckedValue, isChecked, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns a check box input element with the specified values for checked and unchecked by using the specified HTML helper, the name of the form field, a value to indicate whether the check box is selected and the HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field.</param>
		/// <param name="checkedValue">The value when it is checked.</param>
		/// <param name="uncheckedValue">The value when it is unchecked.</param>
		/// <param name="isChecked">true to select the check box; otherwise, false.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "checkbox".</returns>
		public static MvcHtmlString CheckBox( this HtmlHelper htmlHelper, string name, object checkedValue, object uncheckedValue, bool isChecked, object htmlAttributes )
		{
			return htmlHelper.CheckBox( name, checkedValue, uncheckedValue, isChecked, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Returns a check box input element with the specified values for checked and unchecked by using the specified HTML helper, the name of the form field, a value to indicate whether the check box is selected and the HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field.</param>
		/// <param name="checkedValue">The value when it is checked.</param>
		/// <param name="uncheckedValue">The value when it is unchecked.</param>
		/// <param name="isChecked">true to select the check box; otherwise, false.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "checkbox".</returns>
		public static MvcHtmlString CheckBox( this HtmlHelper htmlHelper, string name, object checkedValue, object uncheckedValue, bool isChecked, IDictionary<string, object> htmlAttributes )
		{
			var modelMetadata = ModelMetadata.FromStringExpression( name, htmlHelper.ViewData );

			return CheckBoxExtensions.CheckBoxWithValueBuilder( htmlHelper, modelMetadata, name, checkedValue, uncheckedValue, isChecked, htmlAttributes );
		}

		/// <summary>
		/// Returns a check box input element with the specified values for checked and unchecked by using the specified HTML helper, the name of the form field, a value to indicate whether the check box is selected and the HTML attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field.</param>
		/// <param name="checkedValue">The value when it is checked.</param>
		/// <param name="uncheckedValue">The value when it is unchecked.</param>
		/// <param name="isChecked">true to select the check box; otherwise, false.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An input element whose type attribute is set to "checkbox".</returns>
		public static MvcHtmlString CheckBox( this HtmlHelper htmlHelper, string name, object checkedValue, object uncheckedValue, bool isChecked, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.CheckBox( name, checkedValue, uncheckedValue, isChecked, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Returns a check box input element for each property in the object that is represented by the specified expression.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="checkedValue">The value when it is checked.</param>
		/// <param name="uncheckedValue">The value when it is unchecked.</param>
		/// <returns>An HTML input element whose type attribute is set to "checkbox" for each property in the object that is represented by the specified expression.</returns>
		public static MvcHtmlString CheckBoxFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, TProperty checkedValue, TProperty uncheckedValue )
		{
			return htmlHelper.CheckBoxFor( expression, checkedValue, uncheckedValue, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Returns a check box input element for each property in the object that is represented by the specified expression, using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="checkedValue">The value when it is checked.</param>
		/// <param name="uncheckedValue">The value when it is unchecked.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML input element whose type attribute is set to "checkbox" for each property in the object that is represented by the specified expression.</returns>
		public static MvcHtmlString CheckBoxFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, TProperty checkedValue, TProperty uncheckedValue, object htmlAttributes )
		{
			return htmlHelper.CheckBoxFor( expression, checkedValue, uncheckedValue, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Returns a check box input element for each property in the object that is represented by the specified expression, using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="checkedValue">The value when it is checked.</param>
		/// <param name="uncheckedValue">The value when it is unchecked.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML input element whose type attribute is set to "checkbox" for each property in the object that is represented by the specified expression.</returns>
		public static MvcHtmlString CheckBoxFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, TProperty checkedValue, TProperty uncheckedValue, IDictionary<string, object> htmlAttributes )
		{
			var modelMetadata = ModelMetadata.FromLambdaExpression( expression, htmlHelper.ViewData );

			return CheckBoxExtensions.CheckBoxWithValueBuilder( htmlHelper, modelMetadata, ExpressionHelper.GetExpressionText( expression ), checkedValue, uncheckedValue, null, htmlAttributes );
		}

		/// <summary>
		/// Returns a check box input element for each property in the object that is represented by the specified expression, using the specified HTML attributes.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="checkedValue">The value when it is checked.</param>
		/// <param name="uncheckedValue">The value when it is unchecked.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An HTML input element whose type attribute is set to "checkbox" for each property in the object that is represented by the specified expression.</returns>
		public static MvcHtmlString CheckBoxFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, TProperty checkedValue, TProperty uncheckedValue, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.CheckBoxFor( expression, checkedValue, uncheckedValue, attributeExpression.GetAttributes() );
		}

		#region Intenal Methods

		private static MvcHtmlString CheckBoxWithValueBuilder( HtmlHelper htmlHelper, ModelMetadata modelMetadata, string name, object checkedValue, object uncheckedValue, bool? isChecked, IDictionary<string, object> htmlAttributes )
		{
			if( checkedValue == null )
			{
				throw new ArgumentNullException( "checkedValue" );
			}

			if( uncheckedValue == null )
			{
				throw new ArgumentNullException( "uncheckedValue" );
			}

			string fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName( name );
			string formattedCheckedValue = htmlHelper.FormatValue( checkedValue, null );

			TagBuilder checkedTagBuilder = new TagBuilder( INPUT_ELEMENT );
			checkedTagBuilder.MergeAttributes<string, object>( htmlAttributes );
			checkedTagBuilder.MergeAttribute( HtmlAttributes.Type, HtmlHelper.GetInputTypeString( InputType.CheckBox ) );
			checkedTagBuilder.MergeAttribute( HtmlAttributes.Name, fullHtmlFieldName, true );
			checkedTagBuilder.MergeAttribute( HtmlAttributes.Id, TagBuilder.CreateSanitizedId( fullHtmlFieldName ) );
			checkedTagBuilder.MergeAttribute( HtmlAttributes.Value, formattedCheckedValue, true );
			checkedTagBuilder.MergeAttributes( htmlHelper.GetUnobtrusiveValidationAttributes( name, modelMetadata ) );

			ModelState modelState = null;
			object modelStateValue = htmlHelper.ViewData.ModelState.GetModelStateValue( fullHtmlFieldName, modelMetadata.ModelType, out modelState );
			if( modelStateValue != null || modelMetadata.Model != null )
			{
				var modelValue = ( isChecked.HasValue ) ? modelStateValue : modelMetadata.Model;

				var formattedModelValue = htmlHelper.FormatValue( modelValue, null );
				isChecked = string.Equals( formattedCheckedValue, formattedModelValue, StringComparison.Ordinal );
			}

			if( isChecked.HasValue && isChecked.Value )
			{
				checkedTagBuilder.MergeAttribute( HtmlAttributes.Checked, HtmlAttributes.Checked );
			}

			if( modelState != null && modelState.Errors.Count > 0 )
			{
				checkedTagBuilder.AddCssClass( HtmlHelper.ValidationInputCssClassName );
			}

			string formattedUncheckedValue = htmlHelper.FormatValue( uncheckedValue, null );

			TagBuilder uncheckedTagBuilder = new TagBuilder( INPUT_ELEMENT );
			uncheckedTagBuilder.MergeAttribute( HtmlAttributes.Type, HtmlHelper.GetInputTypeString( InputType.Hidden ) );
			uncheckedTagBuilder.MergeAttribute( HtmlAttributes.Name, fullHtmlFieldName );
			uncheckedTagBuilder.MergeAttribute( HtmlAttributes.Value, formattedUncheckedValue );

			StringBuilder checkBoxStringBuilder = new StringBuilder( checkedTagBuilder.ToString( TagRenderMode.SelfClosing ) );
			checkBoxStringBuilder.Append( uncheckedTagBuilder.ToString( TagRenderMode.SelfClosing ) );

			return MvcHtmlString.Create( checkBoxStringBuilder.ToString() );
		}

		#endregion
	}
}
