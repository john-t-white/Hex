using Hex.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex.AttributeBuilders
{
	public abstract class SelectAttributeBuilder<TSelf>
		: InputAttributeBuilder<TSelf>
		where TSelf : SelectAttributeBuilder<TSelf>
	{
		public TSelf Size( int size )
		{
			this.Attributes[ HtmlAttributes.Size ] = size;

			return ( TSelf )this;
		}
	}
}
