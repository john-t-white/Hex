using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex.AttributeBuilders
{
	public abstract class ValidationAttributeBuilder<TSelf>
		: HtmlAttributeBuilder<TSelf>
		where TSelf : ValidationAttributeBuilder<TSelf>, new()
	{
	}
}
