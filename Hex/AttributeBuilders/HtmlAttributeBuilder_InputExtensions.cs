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
	public static class HtmlAttributeBuilder_InputExtensions
	{
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

		public static HtmlAttributeBuilder AutoComplete( this HtmlAttributeBuilder htmlAttributeBuilder )
		{
			return htmlAttributeBuilder.AutoComplete( AutoCompleteType.On );
		}

		public static HtmlAttributeBuilder AutoComplete( this HtmlAttributeBuilder htmlAttributeBuilder, bool autoComplete )
		{
			AutoCompleteType autoCompleteType = ( autoComplete ) ? AutoCompleteType.On : AutoCompleteType.Off;

			return htmlAttributeBuilder.AutoComplete( autoCompleteType );
		}

		public static HtmlAttributeBuilder AutoComplete( this HtmlAttributeBuilder htmlAttributeBuilder, AutoCompleteType autoComplete )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.AutoComplete ] = autoComplete.ToLowerString();

			return htmlAttributeBuilder;
		}

		public static HtmlAttributeBuilder AutoFocus( this HtmlAttributeBuilder htmlAttributeBuilder )
		{
			return htmlAttributeBuilder.AutoFocus( true );
		}

		public static HtmlAttributeBuilder AutoFocus( this HtmlAttributeBuilder htmlAttributeBuilder, bool autoFocus )
		{
			htmlAttributeBuilder.Attributes.AddOrRemoveMinimizedAttribute( HtmlAttributes.AutoFocus, autoFocus );

			return htmlAttributeBuilder;
		}

		public static HtmlAttributeBuilder Cols( this HtmlAttributeBuilder htmlAttributeBuilder, int columns )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Cols ] = columns;

			return htmlAttributeBuilder;
		}

		public static HtmlAttributeBuilder Disabled( this HtmlAttributeBuilder htmlAttributeBuilder )
		{
			return htmlAttributeBuilder.Disabled( true );
		}

		public static HtmlAttributeBuilder Disabled( this HtmlAttributeBuilder htmlAttributeBuilder, bool disabled )
		{
			htmlAttributeBuilder.Attributes.AddOrRemoveMinimizedAttribute( HtmlAttributes.Disabled, disabled );

			return htmlAttributeBuilder;
		}

		public static HtmlAttributeBuilder FormNoValidate( this HtmlAttributeBuilder htmlAttributeBuilder )
		{
			return htmlAttributeBuilder.FormNoValidate( true );
		}

		public static HtmlAttributeBuilder FormNoValidate( this HtmlAttributeBuilder htmlAttributeBuilder, bool formNoValidate )
		{
			htmlAttributeBuilder.Attributes.AddOrRemoveMinimizedAttribute( HtmlAttributes.FormNoValidate, formNoValidate );

			return htmlAttributeBuilder;
		}

		public static HtmlAttributeBuilder List( this HtmlAttributeBuilder htmlAttributeBuilder, string dataListId )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.List ] = dataListId;

			return htmlAttributeBuilder;
		}

		public static HtmlAttributeBuilder Max( this HtmlAttributeBuilder htmlAttributeBuilder, int max )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Max ] = max;

			return htmlAttributeBuilder;
		}

		public static HtmlAttributeBuilder Max( this HtmlAttributeBuilder htmlAttributeBuilder, DateTime max )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Max ] = max;

			return htmlAttributeBuilder;
		}

		public static HtmlAttributeBuilder MaxLength( this HtmlAttributeBuilder htmlAttributeBuilder, int maxLength )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.MaxLength ] = maxLength;

			return htmlAttributeBuilder;
		}

		public static HtmlAttributeBuilder Min( this HtmlAttributeBuilder htmlAttributeBuilder, int min )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Min ] = min;

			return htmlAttributeBuilder;
		}

		public static HtmlAttributeBuilder Min( this HtmlAttributeBuilder htmlAttributeBuilder, DateTime min )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Min ] = min;

			return htmlAttributeBuilder;
		}

		public static HtmlAttributeBuilder Name( this HtmlAttributeBuilder htmlAttributeBuilder, string name )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Name ] = name;

			return htmlAttributeBuilder;
		}

		public static HtmlAttributeBuilder Pattern( this HtmlAttributeBuilder htmlAttributeBuilder, Regex pattern )
		{
			if( pattern == null )
			{
				return htmlAttributeBuilder;
			}

			return htmlAttributeBuilder.Pattern( pattern.ToString() );
		}

		public static HtmlAttributeBuilder Pattern( this HtmlAttributeBuilder htmlAttributeBuilder, string pattern )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Pattern ] = pattern;

			return htmlAttributeBuilder;
		}

		public static HtmlAttributeBuilder PlaceHolder( this HtmlAttributeBuilder htmlAttributeBuilder, string placeHolder )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.PlaceHolder ] = placeHolder;

			return htmlAttributeBuilder;
		}

		public static HtmlAttributeBuilder ReadOnly( this HtmlAttributeBuilder htmlAttributeBuilder )
		{
			return htmlAttributeBuilder.ReadOnly( true );
		}

		public static HtmlAttributeBuilder ReadOnly( this HtmlAttributeBuilder htmlAttributeBuilder, bool readOnly )
		{
			htmlAttributeBuilder.Attributes.AddOrRemoveMinimizedAttribute( HtmlAttributes.ReadOnly, readOnly );

			return htmlAttributeBuilder;
		}

		public static HtmlAttributeBuilder Required( this HtmlAttributeBuilder htmlAttributeBuilder )
		{
			return htmlAttributeBuilder.Required( true );
		}

		public static HtmlAttributeBuilder Required( this HtmlAttributeBuilder htmlAttributeBuilder, bool required )
		{
			htmlAttributeBuilder.Attributes.AddOrRemoveMinimizedAttribute( HtmlAttributes.Required, required );

			return htmlAttributeBuilder;
		}

		public static HtmlAttributeBuilder Rows( this HtmlAttributeBuilder htmlAttributeBuilder, int rows )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Rows ] = rows;

			return htmlAttributeBuilder;
		}

		public static HtmlAttributeBuilder Size( this HtmlAttributeBuilder htmlAttributeBuilder, int size )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Size ] = size;

			return htmlAttributeBuilder;
		}

		public static HtmlAttributeBuilder Step( this HtmlAttributeBuilder htmlAttributeBuilder, int step )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Step ] = step;

			return htmlAttributeBuilder;
		}

		public static HtmlAttributeBuilder Type( this HtmlAttributeBuilder htmlAttributeBuilder, string value )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Type ] = value;

			return htmlAttributeBuilder;
		}

		public static HtmlAttributeBuilder Wrap( this HtmlAttributeBuilder htmlAttributeBuilder )
		{
			return htmlAttributeBuilder.Wrap( WrapType.Hard );
		}

		public static HtmlAttributeBuilder Wrap( this HtmlAttributeBuilder htmlAttributeBuilder, WrapType wrap )
		{
			htmlAttributeBuilder.Attributes[ HtmlAttributes.Wrap ] = wrap.ToLowerString();

			return htmlAttributeBuilder;
		}
	}
}
