using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard.LifeCycle
{
	public class CreateWizardFormModelLifeCycleCommand
		: IWizardLifeCycleCommand
	{
		public void Execute( WizardLifeCycleContext wizardLifeCycleContext, WizardController wizardController )
		{
			wizardController.WizardFormModel = Activator.CreateInstance( wizardController.WizardFormModelType, true );
		}
	}
}
