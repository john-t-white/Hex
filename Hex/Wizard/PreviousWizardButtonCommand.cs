using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard
{
	public class PreviousWizardButtonCommand
		: IWizardButtonCommand
	{
		public void ExecuteCommand( WizardController wizardController )
		{
			WizardStep currentWizardStep = wizardController.WizardSteps.MoveToPreviousStep();
			wizardController.ModelState.Update( currentWizardStep.Values );
		}
	}
}
