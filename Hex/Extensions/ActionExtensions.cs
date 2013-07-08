using Hex.AttributeBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex.Extensions
{
	/// <summary>
	/// Extensions to <see cref="System.Action{T}"/> where T is an <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder{TSelf}"/>.
	/// </summary>
	public static class ActionExtensions
	{
		/// <summary>
		/// Returns a dictionary of attribute/values from the expression.  If the expression is null, an empty <see cref="System.Collections.Generic.IDictionary{K,V}"/> is returned.
		/// </summary>
		/// <typeparam name="TAttributeBuilder">The type of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder{TSelf}"/>.</typeparam>
		/// <param name="attributeExpression">The instance of <see cref="System.Action{T}"/> that is being extended.</param>
		/// <returns>A dictionary of attribute/values.</returns>
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
