using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard.LifeCycle
{
	public class WizardLifeCycleContext
	{
		public WizardLifeCycleContext( WizardController wizardController )
		{
			if( wizardController == null )
			{
				throw new ArgumentNullException( "wizardController" );
			}

			this.WizardController = wizardController;
		}

		public WizardController WizardController { get; private set; }

		public string ResultActionName { get; set; }

		public WizardState WizardState { get; set; }
	}
}
