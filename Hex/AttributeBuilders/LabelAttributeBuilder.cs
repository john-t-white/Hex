using Hex.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex.AttributeBuilders
{
	public class LabelAttributeBuilder
		: HtmlAttributeBuilder<LabelAttributeBuilder>
	{
		public LabelAttributeBuilder AddForm( params string[] formIds )
		{
			AttributeValueCollection attributeValues = this.Attributes.GetAttributeValue<AttributeValueCollection>( HtmlAttributes.Form );
			if( attributeValues == null )
			{
				attributeValues = new AttributeValueCollection();
				this.Attributes[ HtmlAttributes.Form ] = attributeValues;
			}

			attributeValues.AddRange( formIds );

			return this;
		}
	}
}
