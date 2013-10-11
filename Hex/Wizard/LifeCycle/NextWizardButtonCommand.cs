using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard.LifeCycle
{
	public class NextWizardButtonCommand
		: IWizardButtonCommand
	{
		public void ExecuteCommand( WizardController wizardController )
		{
			if( wizardController.ModelState.IsValid )
			{
				WizardStep currentWizardStep = wizardController.WizardSteps.MoveToNextStep();
				wizardController.ModelState.Update( currentWizardStep.Values );
			}
		}
	}
}
