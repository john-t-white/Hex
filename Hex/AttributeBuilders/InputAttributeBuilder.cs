using Hex.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hex.Extensions;

namespace Hex.AttributeBuilders
{
	public abstract class InputAttributeBuilder<TSelf>
		: HtmlAttributeBuilder<TSelf>
		where TSelf : InputAttributeBuilder<TSelf>
	{
		public TSelf AddForm( params string[] formIds )
		{
			AttributeValueCollection attributeValues = this.Attributes.GetAttributeValue<AttributeValueCollection>( HtmlAttributes.Form );
			if( attributeValues == null )
			{
				attributeValues = new AttributeValueCollection();
				this.Attributes[ HtmlAttributes.Form ] = attributeValues;
			}

			attributeValues.AddRange( formIds );

			return ( TSelf )this;
		}

		public TSelf AutoComplete()
		{
			return this.AutoComplete( AutoCompleteType.On );
		}

		public TSelf AutoComplete( bool autoComplete )
		{
			AutoCompleteType autoCompleteType = ( autoComplete ) ? AutoCompleteType.On : AutoCompleteType.Off;

			return this.AutoComplete( autoCompleteType );
		}

		public TSelf AutoComplete( AutoCompleteType autoComplete )
		{
			this.Attributes[ HtmlAttributes.AutoComplete ] = autoComplete.ToLowerString();

			return ( TSelf )this;
		}

		public TSelf AutoFocus()
		{
			return this.AutoFocus( true );
		}

		public TSelf AutoFocus( bool autoFocus )
		{
			this.Attributes.AddOrRemoveMinimizedAttribute( HtmlAttributes.AutoFocus, autoFocus );

			return ( TSelf )this;
		}

		public TSelf Disabled()
		{
			return this.Disabled( true );
		}

		public TSelf Disabled( bool disabled )
		{
			this.Attributes.AddOrRemoveMinimizedAttribute( HtmlAttributes.Disabled, disabled );

			return ( TSelf )this;
		}

		public TSelf FormNoValidate()
		{
			return this.FormNoValidate( true );
		}

		public TSelf FormNoValidate( bool formNoValidate )
		{
			this.Attributes.AddOrRemoveMinimizedAttribute( HtmlAttributes.FormNoValidate, formNoValidate );

			return ( TSelf )this;
		}

		public TSelf List( string dataListId )
		{
			this.Attributes[ HtmlAttributes.List ] = dataListId;

			return ( TSelf )this;
		}

		public TSelf ReadOnly()
		{
			return this.ReadOnly( true );
		}

		public TSelf ReadOnly( bool readOnly )
		{
			this.Attributes.AddOrRemoveMinimizedAttribute( HtmlAttributes.ReadOnly, readOnly );

			return ( TSelf )this;
		}

		public TSelf Required()
		{
			return this.Required( true );
		}

		public TSelf Required( bool required )
		{
			this.Attributes.AddOrRemoveMinimizedAttribute( HtmlAttributes.Required, required );

			return ( TSelf )this;
		}
	}
}
