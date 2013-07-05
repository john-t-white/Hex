using Hex.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hex.Extensions;

namespace Hex.AttributeBuilders
{
	public class FormAttributeBuilder
		: HtmlAttributeBuilder<FormAttributeBuilder>
	{
		private const string ENCODING_TYPE_MULTIPART_FORM_DATA = "multipart/form-data";
		private const string ENCODING_TYPE_TEXT_PLAIN = "text/plain";
		private const string ENCODING_TYPE_APPLICATION_URL_ENCODED = "application/x-www-form-urlencoded";

		public FormAttributeBuilder AddAcceptCharsets( params string[] characterSets )
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

		public FormAttributeBuilder AutoComplete()
		{
			return this.AutoComplete( AutoCompleteType.On );
		}

		public FormAttributeBuilder AutoComplete( bool autoComplete )
		{
			AutoCompleteType autoCompleteType = ( autoComplete ) ? AutoCompleteType.On : AutoCompleteType.Off;

			return this.AutoComplete( autoCompleteType );
		}

		public FormAttributeBuilder AutoComplete( AutoCompleteType autoComplete )
		{
			this.Attributes[ HtmlAttributes.AutoComplete ] = autoComplete.ToLowerString();

			return this;
		}

		public FormAttributeBuilder EncType( EncodingType encodingType )
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

		public FormAttributeBuilder Name( string name )
		{
			this.Attributes[ HtmlAttributes.Name ] = name;

			return this;
		}

		public FormAttributeBuilder NoValidate()
		{
			return this.NoValidate( true );
		}

		public FormAttributeBuilder NoValidate( bool noValidate )
		{
			this.Attributes.AddOrRemoveMinimizedAttribute( HtmlAttributes.NoValidate, noValidate );

			return this;
		}

		public FormAttributeBuilder Target( TargetType target )
		{
			return this.Target( string.Format( "_{0}", target.ToLowerString() ) );
		}

		public FormAttributeBuilder Target( string target )
		{
			this.Attributes[ HtmlAttributes.Target ] = target;

			return this;
		}
	}
}
