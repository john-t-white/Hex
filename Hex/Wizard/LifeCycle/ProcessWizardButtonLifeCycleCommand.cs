using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard.LifeCycle
{
	public class ProcessWizardButtonLifeCycleCommand
		: IWizardLifeCycleCommand
	{
		public ProcessWizardButtonLifeCycleCommand()
		{
			this.WizardButtonCommandFactory = new WizardButtonCommandFactory();
		}

		public void Execute( WizardLifeCycleContext wizardLifeCycleContext )
		{
			WizardController wizardController = wizardLifeCycleContext.WizardController;

			IWizardButtonCommand buttonCommand = this.WizardButtonCommandFactory.GetButtonCommand( wizardController );
			if( buttonCommand != null )
			{
				buttonCommand.ExecuteCommand( wizardController );
			}
		}

		public IWizardButtonCommandFactory WizardButtonCommandFactory { get; set; }
	}
}
