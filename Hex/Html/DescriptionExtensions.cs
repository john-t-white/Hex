using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;

namespace Hex.Html
{
	public static class DescriptionExtensions
	{
		/// <summary>
		/// Gets the description.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the description.</param>
		/// <returns>The description.</returns>
		public static MvcHtmlString Description( this HtmlHelper htmlHelper, string expression )
		{
			return DescriptionExtensions.DescriptionBuilder( ModelMetadata.FromStringExpression( expression, htmlHelper.ViewData ) );
		}

		/// <summary>
		/// Gets the description for the model.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the description.</param>
		/// <returns>The description for the model.</returns>
		public static MvcHtmlString DescriptionFor<TModel, TValue>( this HtmlHelper<IEnumerable<TModel>> htmlHelper, Expression<Func<TModel, TValue>> expression )
		{
			return DescriptionExtensions.DescriptionBuilder( ModelMetadata.FromLambdaExpression( expression, new ViewDataDictionary<TModel>() ) );
		}

		/// <summary>
		/// Gets the description for the model.
		/// </summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="expression">An expression that identifies the object that contains the description.</param>
		/// <returns>The description for the model.</returns>
		public static MvcHtmlString DescriptionFor<TModel, TValue>( this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression )
		{
			return DescriptionExtensions.DescriptionBuilder( ModelMetadata.FromLambdaExpression( expression, htmlHelper.ViewData ) );
		}

		/// <summary>
		/// Gets the description for the model.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <returns>The description for the model.</returns>
		public static MvcHtmlString DescriptionForModel( this HtmlHelper htmlHelper )
		{
			return DescriptionExtensions.DescriptionBuilder( htmlHelper.ViewData.ModelMetadata );
		}

		#region Internal Methods

		private static MvcHtmlString DescriptionBuilder( ModelMetadata modelMetadata )
		{
			return MvcHtmlString.Create( modelMetadata.Description );
		}

		#endregion
	}
}
