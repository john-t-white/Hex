using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard.LifeCycle
{
	/// <summary>
	/// Represents the command when the previous button is clicked in the wizard.
	/// </summary>
	public class PreviousWizardButtonCommand
		: IWizardButtonCommand
	{
		/// <summary>
		/// Executes the command.
		/// </summary>
		/// <param name="wizardController">The wizard controller.</param>
		public void Execute( WizardController wizardController )
		{
			WizardStep currentWizardStep = wizardController.WizardSteps.MoveToPreviousStep();
			wizardController.ModelState.Update( currentWizardStep.Values );
		}
	}
}
