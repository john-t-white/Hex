using Hex.AttributeBuilders;
using Hex.Extensions;
using Hex.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;

namespace Hex.Html
{
	/// <summary>
	/// Represents support for HTML5 button in an application with HTML attributes.
	/// </summary>
	public static class BeginButtonExtensions
	{
		/// <summary>
		/// Writes an opening &lt;button&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">The value of the form field to return.</param>
		/// <returns>An opening &lt;button&gt; tag.</returns>
		public static MvcButton BeginButton( this HtmlHelper htmlHelper, string name, object value )
		{
			return htmlHelper.BeginButton( name, value, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Writes an opening &lt;button&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">The value of the form field to return.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;button&gt; tag.</returns>
		public static MvcButton BeginButton( this HtmlHelper htmlHelper, string name, object value, object htmlAttributes )
		{
			return htmlHelper.BeginButton( name, value, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Writes an opening &lt;button&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">The value of the form field to return.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;button&gt; tag.</returns>
		public static MvcButton BeginButton( this HtmlHelper htmlHelper, string name, object value, IDictionary<string, object> htmlAttributes )
		{
			BeginButtonExtensions.BeginButtonBuilder( htmlHelper, name, value, ButtonType.Button, htmlAttributes );

			return new MvcButton( htmlHelper.ViewContext );
		}

		/// <summary>
		/// Writes an opening &lt;button&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="name">The name of the form field to return.</param>
		/// <param name="value">The value of the form field to return.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;button&gt; tag.</returns>
		public static MvcButton BeginButton( this HtmlHelper htmlHelper, string name, object value, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginButton( name, value, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;button&gt; tag to the response.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="value">The value of the form field to return.</param>
		/// <returns>An opening &lt;button&gt; tag.</returns>
		public static MvcButton BeginButtonFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, TProperty value )
		{
			return htmlHelper.BeginButtonFor( expression, value, ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Writes an opening &lt;button&gt; tag to the response.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="value">The value of the form field to return.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;button&gt; tag.</returns>
		public static MvcButton BeginButtonFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, TProperty value, object htmlAttributes )
		{
			return htmlHelper.BeginButtonFor( expression, value, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Writes an opening &lt;button&gt; tag to the response.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="value">The value of the form field to return.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;button&gt; tag.</returns>
		public static MvcButton BeginButtonFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, TProperty value, IDictionary<string, object> htmlAttributes )
		{
			BeginButtonExtensions.BeginButtonBuilder( htmlHelper, ExpressionHelper.GetExpressionText( expression ), value, ButtonType.Button, htmlAttributes );

			return new MvcButton( htmlHelper.ViewContext );
		}

		/// <summary>
		/// Writes an opening &lt;button&gt; tag to the response.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TProperty">The type of the property.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
		/// <param name="value">The value of the form field to return.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;button&gt; tag.</returns>
		public static MvcButton BeginButtonFor<TModel, TProperty>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, TProperty value, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginButtonFor( expression, value, attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes the closing &lt;/button&gt; tag to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		public static void EndButton( this HtmlHelper htmlHelper )
		{
			BeginButtonExtensions.EndButton( htmlHelper.ViewContext );
		}

		#region Internal Methods

		private static void BeginButtonBuilder( HtmlHelper htmlHelper, string name, object value, ButtonType buttonType, IDictionary<string, object> htmlAttributes )
		{
			string fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName( name );

			if( string.IsNullOrWhiteSpace( fullHtmlFieldName ) )
			{
				throw new ArgumentException( ExceptionMessages.VALUE_CANNOT_BE_NULL_OR_EMPTY, "name" );
			}

			string formattedValue = htmlHelper.FormatValue( value, null );

			TagBuilder tagBuilder = new TagBuilder( HtmlElements.Button );
			tagBuilder.MergeAttributes( htmlAttributes );
			tagBuilder.MergeAttribute( HtmlAttributes.Type, buttonType.ToLowerString(), true );
			tagBuilder.MergeAttribute( HtmlAttributes.Name, fullHtmlFieldName, true );
			tagBuilder.MergeAttribute( HtmlAttributes.Value, formattedValue, true );

			htmlHelper.ViewContext.Writer.Write( tagBuilder.ToString( TagRenderMode.StartTag ) );
		}

		internal static void EndButton( ViewContext viewContext )
		{
			viewContext.Writer.Write( string.Format( "</{0}>", HtmlElements.Button ) );
		}

		#endregion
	}
}
