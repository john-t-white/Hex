using Hex.Extensions;
using Hex.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.Html
{
	internal static class ButtonHelper
	{
		internal static MvcHtmlString ButtonBuilder( HtmlHelper htmlHelper, string name, string buttonText, object value, ButtonType buttonType, IDictionary<string, object> htmlAttributes )
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
			tagBuilder.SetInnerText( string.IsNullOrWhiteSpace( buttonText ) ? formattedValue : buttonText );

			return new MvcHtmlString( tagBuilder.ToString( TagRenderMode.Normal ) );
		}
	}
}
