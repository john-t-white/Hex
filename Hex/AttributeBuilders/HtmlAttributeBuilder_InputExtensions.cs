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
	public partial class HtmlAttributeBuilder
	{
		private const string DATE_TIME_FORMAT = "yyyy-MM-dd";

		/// <summary>
		/// Represents the HTML attribute "form". Multiple calls add additional values.
		/// </summary>
		/// <param name="formIds">The list of values.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder AddForm( params string[] formIds )
		{
			AttributeValueCollection attributeValues = null;
			if( !this.Attributes.TryGetValue<AttributeValueCollection>( HtmlAttributes.Form, out attributeValues ) )
			{
				attributeValues = new AttributeValueCollection();
				this.Attributes[ HtmlAttributes.Form ] = attributeValues;
			}

			attributeValues.AddRange( formIds );
			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "autocomplete" with the value of "on".
		/// </summary>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder AutoComplete()
		{
			return this.AutoComplete( AutoCompleteType.On );
		}

		/// <summary>
		/// Represents the HTML attribute "autocomplete".
		/// </summary>
		/// <param name="autoComplete">true for "on", false for "off"</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder AutoComplete( bool autoComplete )
		{
			AutoCompleteType autoCompleteType = ( autoComplete ) ? AutoCompleteType.On : AutoCompleteType.Off;

			return this.AutoComplete( autoCompleteType );
		}

		/// <summary>
		/// Represents the HTML attribute "autocomplete".
		/// </summary>
		/// <param name="autoComplete">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder AutoComplete( AutoCompleteType autoComplete )
		{
			this.Attributes[ HtmlAttributes.AutoComplete ] = autoComplete.ToLowerString();

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "autofocus" with the value of "autofocus".
		/// </summary>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder AutoFocus()
		{
			return this.AutoFocus( true );
		}

		/// <summary>
		/// Represents the HTML attribute "autofocus". True will add the attribute, false will remove the attribute if it has been specified.
		/// </summary>
		/// <param name="autoFocus">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder AutoFocus( bool autoFocus )
		{
			this.Attributes.AddOrRemoveMinimizedAttribute( HtmlAttributes.AutoFocus, autoFocus );

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "cols".
		/// </summary>
		/// <param name="columns">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Cols( int columns )
		{
			this.Attributes[ HtmlAttributes.Cols ] = columns;

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "disabled" with the value of "disabled".
		/// </summary>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Disabled()
		{
			return this.Disabled( true );
		}

		/// <summary>
		/// Represents the HTML attribute "disabled". True will add the attribute, false will remove the attribute if it has been specified.
		/// </summary>
		/// <param name="disabled">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Disabled( bool disabled )
		{
			this.Attributes.AddOrRemoveMinimizedAttribute( HtmlAttributes.Disabled, disabled );

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "formnovalidate" with the value of "formnovalidate".
		/// </summary>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder FormNoValidate()
		{
			return this.FormNoValidate( true );
		}

		/// <summary>
		/// Represents the HTML attribute "formnovalidate". True will add the attribute, false will remove the attribute if it has been specified.
		/// </summary>
		/// <param name="formNoValidate">the value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder FormNoValidate( bool formNoValidate )
		{
			this.Attributes.AddOrRemoveMinimizedAttribute( HtmlAttributes.FormNoValidate, formNoValidate );

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "list".
		/// </summary>
		/// <param name="dataListId">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder List( string dataListId )
		{
			this.Attributes[ HtmlAttributes.List ] = dataListId;

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "max".
		/// </summary>
		/// <param name="max">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Max( int max )
		{
			this.Attributes[ HtmlAttributes.Max ] = max;

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "max".
		/// </summary>
		/// <param name="max">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Max( DateTime max )
		{
			this.Attributes[ HtmlAttributes.Max ] = max.ToString( DATE_TIME_FORMAT );

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "maxlength".
		/// </summary>
		/// <param name="maxLength">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder MaxLength( int maxLength )
		{
			this.Attributes[ HtmlAttributes.MaxLength ] = maxLength;

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "min".
		/// </summary>
		/// <param name="min">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Min( int min )
		{
			this.Attributes[ HtmlAttributes.Min ] = min;

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "min".
		/// </summary>
		/// <param name="min">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Min( DateTime min )
		{
			this.Attributes[ HtmlAttributes.Min ] = min.ToString( DATE_TIME_FORMAT );

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "name".
		/// </summary>
		/// <param name="name">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Name( string name )
		{
			this.Attributes[ HtmlAttributes.Name ] = name;

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "pattern".
		/// </summary>
		/// <param name="pattern">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Pattern( Regex pattern )
		{
			if( pattern == null )
			{
				return this;
			}

			return this.Pattern( pattern.ToString() );
		}

		/// <summary>
		/// Represents the HTML attribut "pattern".
		/// </summary>
		/// <param name="pattern">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Pattern( string pattern )
		{
			this.Attributes[ HtmlAttributes.Pattern ] = pattern;

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "placeholder".
		/// </summary>
		/// <param name="placeHolder">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder PlaceHolder( string placeHolder )
		{
			this.Attributes[ HtmlAttributes.PlaceHolder ] = placeHolder;

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "readonly" with the value of "readonly".
		/// </summary>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder ReadOnly()
		{
			return this.ReadOnly( true );
		}

		/// <summary>
		/// Represents the HTML attribute "readonly". True will add the attribute, false will remove the attribute if it has been specified.
		/// </summary>
		/// <param name="readOnly">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder ReadOnly( bool readOnly )
		{
			this.Attributes.AddOrRemoveMinimizedAttribute( HtmlAttributes.ReadOnly, readOnly );

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "required" with the value of "required".
		/// </summary>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Required()
		{
			return this.Required( true );
		}

		/// <summary>
		/// Represents the HTML attribute "required". True will add the attribute, false will remove the attribute if it has been specified.
		/// </summary>
		/// <param name="required">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Required( bool required )
		{
			this.Attributes.AddOrRemoveMinimizedAttribute( HtmlAttributes.Required, required );

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "rows".
		/// </summary>
		/// <param name="rows">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Rows( int rows )
		{
			this.Attributes[ HtmlAttributes.Rows ] = rows;

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "size".
		/// </summary>
		/// <param name="size">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Size( int size )
		{
			this.Attributes[ HtmlAttributes.Size ] = size;

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "step".
		/// </summary>
		/// <param name="step">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Step( object step )
		{
			object value = ( step is TimeFormat ) ? ( ( TimeFormat )step ).GetStepValue() : step;

			this.Attributes[ HtmlAttributes.Step ] = value;

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "type".
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Type( string value )
		{
			this.Attributes[ HtmlAttributes.Type ] = value;

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "wrap" with the value of "hard".
		/// </summary>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Wrap()
		{
			return this.Wrap( WrapType.Hard );
		}

		/// <summary>
		/// Represents the HTML attribute "wrap".
		/// </summary>
		/// <param name="wrap">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Wrap( WrapType wrap )
		{
			this.Attributes[ HtmlAttributes.Wrap ] = wrap.ToLowerString();

			return this;
		}
	}
}
