using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard
{
	[AttributeUsage( AttributeTargets.Method, Inherited = true )]
	public class NotAWizardActionAttribute
		: Attribute
	{
	}
}
