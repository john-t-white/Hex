using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard.LifeCycle
{
	public class WizardLifeCycleContext
	{
		public string ActionName { get; set; }

		public WizardState WizardState { get; set; }
	}
}
