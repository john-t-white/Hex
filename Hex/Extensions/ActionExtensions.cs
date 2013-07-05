using Hex.AttributeBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex.Extensions
{
	public static class ActionExtensions
	{
		public static IDictionary<string, object> GetAttributes<TAttributeBuilder>( this Action<TAttributeBuilder> attributeExpression )
			where TAttributeBuilder : HtmlAttributeBuilder<TAttributeBuilder>, new()
		{
			TAttributeBuilder attributeBuilder = new TAttributeBuilder();
			if( attributeExpression != null )
			{
				attributeExpression( attributeBuilder );
			}

			return attributeBuilder.Attributes;
		}
	}
}
