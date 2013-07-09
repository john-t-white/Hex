using Hex.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hex.Extensions;

namespace Hex.AttributeBuilders
{
	/// <summary>
	/// Extension methods for <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/> to provide form-based HTML attributes and their values.
	/// </summary>
	public static class HtmlAttributeBuilder_FormExtensions
	{
		private const string ENCODING_TYPE_MULTIPART_FORM_DATA = "multipart/form-data";
		private const string ENCODING_TYPE_TEXT_PLAIN = "text/plain";
		private const string ENCODING_TYPE_APPLICATION_URL_ENCODED = "application/x-www-form-urlencoded";

		/// <summary>
		/// Represents the HTML attribute "accept-charset". Multiple calls add additional values.
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="characterSets">The list of values.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
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

		/// <summary>
		/// Represents the HTML attribute "enctype".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="encodingType">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
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

		/// <summary>
		/// Represents the HTML attribute "novalidate" with the value of "novalidate".
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder NoValidate( this HtmlAttributeBuilder htmlAttributeBuilder )
		{
			return htmlAttributeBuilder.NoValidate( true );
		}

		/// <summary>
		/// Represents the HTML attribute "novalidate". True will add the attribute, false will remove the attribute if it has been specified.
		/// </summary>
		/// <param name="htmlAttributeBuilder">The <see cref=" Hex.AttributeBuilders.HtmlAttributeBuilder"/> instance that this method extends.</param>
		/// <param name="noValidate">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public static HtmlAttributeBuilder NoValidate( this HtmlAttributeBuilder htmlAttributeBuilder, bool noValidate )
		{
			htmlAttributeBuilder.Attributes.AddOrRemoveMinimizedAttribute( HtmlAttributes.NoValidate, noValidate );

			return htmlAttributeBuilder;
		}
	}
}
