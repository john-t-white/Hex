using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard.LifeCycle
{
	public class ProcessWizardButtonLifeCycleCommand
		: IWizardLifeCycleCommand
	{
		public void Execute( WizardLifeCycleContext wizardLifeCycleContext, WizardController wizardController )
		{
			IWizardButtonCommandFactory wizardButtonCommandFactory = new WizardButtonCommandFactory();

			IWizardButtonCommand buttonCommand = wizardButtonCommandFactory.GetButtonCommand( wizardController );
			if( buttonCommand != null )
			{
				buttonCommand.ExecuteCommand( wizardController );
			}
		}
	}
}
