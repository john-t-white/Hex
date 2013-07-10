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
	public partial class HtmlAttributeBuilder
	{
		private const string ENCODING_TYPE_MULTIPART_FORM_DATA = "multipart/form-data";
		private const string ENCODING_TYPE_TEXT_PLAIN = "text/plain";
		private const string ENCODING_TYPE_APPLICATION_URL_ENCODED = "application/x-www-form-urlencoded";

		/// <summary>
		/// Represents the HTML attribute "accept-charset". Multiple calls add additional values.
		/// </summary>
		/// <param name="characterSets">The list of values.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder AddAcceptCharsets( params string[] characterSets )
		{
			AttributeValueCollection attributeValues = this.Attributes.GetAttributeValue<AttributeValueCollection>( HtmlAttributes.AcceptCharset );
			if( attributeValues == null )
			{
				attributeValues = new AttributeValueCollection();
				this.Attributes[ HtmlAttributes.AcceptCharset ] = attributeValues;
			}

			attributeValues.AddRange( characterSets );

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "enctype".
		/// </summary>
		/// <param name="encodingType">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder EncType( EncodingType encodingType )
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

			this.Attributes[ HtmlAttributes.EncType ] = encodingTypeAttributeValue;

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "novalidate" with the value of "novalidate".
		/// </summary>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder NoValidate()
		{
			return this.NoValidate( true );
		}

		/// <summary>
		/// Represents the HTML attribute "novalidate". True will add the attribute, false will remove the attribute if it has been specified.
		/// </summary>
		/// <param name="noValidate">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder NoValidate( bool noValidate )
		{
			this.Attributes.AddOrRemoveMinimizedAttribute( HtmlAttributes.NoValidate, noValidate );

			return this;
		}
	}
}
