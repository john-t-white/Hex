using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard.LifeCycle
{
	/// <summary>
	/// Represents the command when the next button is clicked in the wizard.
	/// </summary>
	public class NextWizardButtonCommand
		: IWizardButtonCommand
	{
		/// <summary>
		/// Executes the command.
		/// </summary>
		/// <param name="wizardController">The wizard controller.</param>
		public void Execute( WizardController wizardController )
		{
			if( wizardController.ModelState.IsValid )
			{
				WizardStep currentWizardStep = wizardController.WizardSteps.MoveToNextStep();
				wizardController.ModelState.Update( currentWizardStep.Values );
			}
		}
	}
}
