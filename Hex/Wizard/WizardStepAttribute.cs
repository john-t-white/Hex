using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard
{
	[AttributeUsage( AttributeTargets.Method )]
	public class WizardStepAttribute
		: Attribute
	{
		public WizardStepAttribute()
			: base()
		{ }

		public string Name { get; set; }

		public string Description { get; set; }

		public int Order { get; set; }
	}
}
