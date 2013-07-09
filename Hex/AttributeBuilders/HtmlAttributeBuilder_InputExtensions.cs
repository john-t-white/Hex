using Hex.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hex.Extensions;
using System.Text.RegularExpressions;

namespace Hex.AttributeBuilders
{
	/// <summary>
	/// Extension methods for <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/> to provide input-based HTML attributes and their values.
	/// </summary>
	public static class HtmlAttributeBuilder_InputExtensions
	{
		/// <summary>
		/// Represents the HTML attribute "form". Multiple calls add additional values.
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="formIds">The list of values.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder AddForm( this HtmlAttributeBuilder htmlAttributeBuilder, params string[] formIds )
		{
			AttributeValueCollection attributeValues = htmlAttributeBuilder.Attributes.GetAttributeValue<AttributeValueCollection>( HtmlAttributes.Form );
			if( attributeValues == null )
			{
				attributeValues = new AttributeValueCollection();
				htmlAttributeBuilder.Attributes[ HtmlAttributes.Form ] = attributeValues;
			}

			attributeValues.AddRange( formIds );

			return htmlAttributeBuilder;
		}

		/// <summary>
		/// Represents the HTML attribute "autocomplete" with the value of "on".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder AutoComplete( this HtmlAttributeBuilder htmlAttributeBuilder )
		{
			return htmlAttributeBuilder.AutoComplete( AutoCompleteType.On );
		}

		/// <summary>
		/// Represents the HTML attribute "autocomplete".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="autoComplete">true for "on", false for "off"</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder AutoComplete( this HtmlAttributeBuilder htmlAttributeBuilder, bool autoComplete )
		{
			AutoCompleteType autoCompleteType = ( autoComplete ) ? AutoCompleteType.On : AutoCompleteType.Off;

			return htmlAttributeBuilder.AutoComplete( autoCompleteType );
		}

		/// <summary>
		/// Represents the HTML attribute "autocomplete".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="autoComplete">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder AutoComplete( this HtmlAttributeBuilder htmlAttributeBuilder, AutoCompleteType autoComplete )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.AutoComplete ] = autoComplete.ToLowerString();

			return htmlAttributeBuilder;
		}

		/// <summary>
		/// Represents the HTML attribute "autofocus" with the value of "autofocus".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder AutoFocus( this HtmlAttributeBuilder htmlAttributeBuilder )
		{
			return htmlAttributeBuilder.AutoFocus( true );
		}

		/// <summary>
		/// Represents the HTML attribute "autofocus". True will add the attribute, false will remove the attribute if it has been specified.
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="autoFocus">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder AutoFocus( this HtmlAttributeBuilder htmlAttributeBuilder, bool autoFocus )
		{
			htmlAttributeBuilder.Attributes.AddOrRemoveMinimizedAttribute( HtmlAttributes.AutoFocus, autoFocus );

			return htmlAttributeBuilder;
		}

		/// <summary>
		/// Represents the HTML attribute "cols".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="columns">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder Cols( this HtmlAttributeBuilder htmlAttributeBuilder, int columns )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Cols ] = columns;

			return htmlAttributeBuilder;
		}

		/// <summary>
		/// Represents the HTML attribute "disabled" with the value of "disabled".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder Disabled( this HtmlAttributeBuilder htmlAttributeBuilder )
		{
			return htmlAttributeBuilder.Disabled( true );
		}

		/// <summary>
		/// Represents the HTML attribute "disabled". True will add the attribute, false will remove the attribute if it has been specified.
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="disabled">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder Disabled( this HtmlAttributeBuilder htmlAttributeBuilder, bool disabled )
		{
			htmlAttributeBuilder.Attributes.AddOrRemoveMinimizedAttribute( HtmlAttributes.Disabled, disabled );

			return htmlAttributeBuilder;
		}

		/// <summary>
		/// Represents the HTML attribute "formnovalidate" with the value of "formnovalidate".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder FormNoValidate( this HtmlAttributeBuilder htmlAttributeBuilder )
		{
			return htmlAttributeBuilder.FormNoValidate( true );
		}

		/// <summary>
		/// Represents the HTML attribute "formnovalidate". True will add the attribute, false will remove the attribute if it has been specified.
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="formNoValidate">the value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder FormNoValidate( this HtmlAttributeBuilder htmlAttributeBuilder, bool formNoValidate )
		{
			htmlAttributeBuilder.Attributes.AddOrRemoveMinimizedAttribute( HtmlAttributes.FormNoValidate, formNoValidate );

			return htmlAttributeBuilder;
		}

		/// <summary>
		/// Represents the HTML attribute "list".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="dataListId">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder List( this HtmlAttributeBuilder htmlAttributeBuilder, string dataListId )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.List ] = dataListId;

			return htmlAttributeBuilder;
		}

		/// <summary>
		/// Represents the HTML attribute "max".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="max">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder Max( this HtmlAttributeBuilder htmlAttributeBuilder, int max )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Max ] = max;

			return htmlAttributeBuilder;
		}

		/// <summary>
		/// Represents the HTML attribute "max".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="max">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder Max( this HtmlAttributeBuilder htmlAttributeBuilder, DateTime max )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Max ] = max;

			return htmlAttributeBuilder;
		}

		/// <summary>
		/// Represents the HTML attribute "maxlength".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="maxLength">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder MaxLength( this HtmlAttributeBuilder htmlAttributeBuilder, int maxLength )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.MaxLength ] = maxLength;

			return htmlAttributeBuilder;
		}

		/// <summary>
		/// Represents the HTML attribute "min".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="min">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder Min( this HtmlAttributeBuilder htmlAttributeBuilder, int min )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Min ] = min;

			return htmlAttributeBuilder;
		}

		/// <summary>
		/// Represents the HTML attribute "min".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="min">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder Min( this HtmlAttributeBuilder htmlAttributeBuilder, DateTime min )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Min ] = min;

			return htmlAttributeBuilder;
		}

		/// <summary>
		/// Represents the HTML attribute "name".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="name">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder Name( this HtmlAttributeBuilder htmlAttributeBuilder, string name )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Name ] = name;

			return htmlAttributeBuilder;
		}

		/// <summary>
		/// Represents the HTML attribute "pattern".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="pattern">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder Pattern( this HtmlAttributeBuilder htmlAttributeBuilder, Regex pattern )
		{
			if( pattern == null )
			{
				return htmlAttributeBuilder;
			}

			return htmlAttributeBuilder.Pattern( pattern.ToString() );
		}

		/// <summary>
		/// Represents the HTML attribut "pattern".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="pattern">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder Pattern( this HtmlAttributeBuilder htmlAttributeBuilder, string pattern )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Pattern ] = pattern;

			return htmlAttributeBuilder;
		}

		/// <summary>
		/// Represents the HTML attribute "placeholder".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="placeHolder">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder PlaceHolder( this HtmlAttributeBuilder htmlAttributeBuilder, string placeHolder )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.PlaceHolder ] = placeHolder;

			return htmlAttributeBuilder;
		}

		/// <summary>
		/// Represents the HTML attribute "readonly" with the value of "readonly".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder ReadOnly( this HtmlAttributeBuilder htmlAttributeBuilder )
		{
			return htmlAttributeBuilder.ReadOnly( true );
		}

		/// <summary>
		/// Represents the HTML attribute "readonly". True will add the attribute, false will remove the attribute if it has been specified.
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="readOnly">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder ReadOnly( this HtmlAttributeBuilder htmlAttributeBuilder, bool readOnly )
		{
			htmlAttributeBuilder.Attributes.AddOrRemoveMinimizedAttribute( HtmlAttributes.ReadOnly, readOnly );

			return htmlAttributeBuilder;
		}

		/// <summary>
		/// Represents the HTML attribute "required" with the value of "required".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder Required( this HtmlAttributeBuilder htmlAttributeBuilder )
		{
			return htmlAttributeBuilder.Required( true );
		}

		/// <summary>
		/// Represents the HTML attribute "required". True will add the attribute, false will remove the attribute if it has been specified.
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="required">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder Required( this HtmlAttributeBuilder htmlAttributeBuilder, bool required )
		{
			htmlAttributeBuilder.Attributes.AddOrRemoveMinimizedAttribute( HtmlAttributes.Required, required );

			return htmlAttributeBuilder;
		}

		/// <summary>
		/// Represents the HTML attribute "rows".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="rows">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder Rows( this HtmlAttributeBuilder htmlAttributeBuilder, int rows )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Rows ] = rows;

			return htmlAttributeBuilder;
		}

		/// <summary>
		/// Represents the HTML attribute "size".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="size">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder Size( this HtmlAttributeBuilder htmlAttributeBuilder, int size )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Size ] = size;

			return htmlAttributeBuilder;
		}

		/// <summary>
		/// Represents the HTML attribute "step".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="step">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder Step( this HtmlAttributeBuilder htmlAttributeBuilder, int step )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Step ] = step;

			return htmlAttributeBuilder;
		}

		/// <summary>
		/// Represents the HTML attribute "type".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="value">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder Type( this HtmlAttributeBuilder htmlAttributeBuilder, string value )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Type ] = value;

			return htmlAttributeBuilder;
		}

		/// <summary>
		/// Represents the HTML attribute "wrap" with the value of "hard".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder Wrap( this HtmlAttributeBuilder htmlAttributeBuilder )
		{
			return htmlAttributeBuilder.Wrap( WrapType.Hard );
		}

		/// <summary>
		/// Represents the HTML attribute "wrap".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="wrap">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder Wrap( this HtmlAttributeBuilder htmlAttributeBuilder, WrapType wrap )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Wrap ] = wrap.ToLowerString();

			return htmlAttributeBuilder;
		}
	}
}
