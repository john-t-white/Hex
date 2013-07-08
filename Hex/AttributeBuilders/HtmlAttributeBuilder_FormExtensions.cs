using Hex.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hex.Extensions;

namespace Hex.AttributeBuilders
{
	public static class HtmlAttributeBuilder_FormExtensions
	{
		private const string ENCODING_TYPE_MULTIPART_FORM_DATA = "multipart/form-data";
		private const string ENCODING_TYPE_TEXT_PLAIN = "text/plain";
		private const string ENCODING_TYPE_APPLICATION_URL_ENCODED = "application/x-www-form-urlencoded";

		public static HtmlAttributeBuilder AddAcceptCharsets( this HtmlAttributeBuilder htmlAttributeBuilder, params string[] characterSets )
		{
			AttributeValueCollection attributeValues = htmlAttributeBuilder.Attributes.GetAttributeValue<AttributeValueCollection>( HtmlAttributes.AcceptCharset );
			if( attributeValues == null )
			{
				attributeValues = new AttributeValueCollection();
				htmlAttributeBuilder.Attributes[ HtmlAttributes.AcceptCharset ] = attributeValues;
			}

			attributeValues.AddRange( characterSets );

			return htmlAttributeBuilder;
		}

		public static HtmlAttributeBuilder EncType( this HtmlAttributeBuilder htmlAttributeBuilder, EncodingType encodingType )
		{
			string encodingTypeAttributeValue;
			switch( encodingType )
			{
				case EncodingType.Multipart:
					{
						encodingTypeAttributeValue = ENCODING_TYPE_MULTIPART_FORM_DATA;
						break;
					}
				case EncodingType.Plain:
					{
						encodingTypeAttributeValue = ENCODING_TYPE_TEXT_PLAIN;
						break;
					}
				default:
					{
						encodingTypeAttributeValue = ENCODING_TYPE_APPLICATION_URL_ENCODED;
						break;
					}
			}

			htmlAttributeBuilder.Attributes[ HtmlAttributes.EncType ] = encodingTypeAttributeValue;

			return htmlAttributeBuilder;
		}

		public static HtmlAttributeBuilder NoValidate( this HtmlAttributeBuilder htmlAttributeBuilder )
		{
			return htmlAttributeBuilder.NoValidate( true );
		}

		public static HtmlAttributeBuilder NoValidate( this HtmlAttributeBuilder htmlAttributeBuilder, bool noValidate )
		{
			htmlAttributeBuilder.Attributes.AddOrRemoveMinimizedAttribute( HtmlAttributes.NoValidate, noValidate );

			return htmlAttributeBuilder;
		}
	}
}
