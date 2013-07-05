using Hex.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hex.Extensions;

namespace Hex.AttributeBuilders
{
	public class TextAreaAttributeBuilder
		: TextInputAttributeBuilder<TextAreaAttributeBuilder>
	{
		public TextAreaAttributeBuilder Cols( int columns )
		{
			this.Attributes[ HtmlAttributes.Cols ] = columns;

			return this;
		}

		public TextAreaAttributeBuilder Rows( int rows )
		{
			this.Attributes[ HtmlAttributes.Rows ] = rows;

			return this;
		}

		public TextAreaAttributeBuilder Wrap()
		{
			return this.Wrap( WrapType.Hard );
		}

		public TextAreaAttributeBuilder Wrap( WrapType wrap )
		{
			this.Attributes[ HtmlAttributes.Wrap ] = wrap.ToLowerString();

			return this;
		}
	}
}
