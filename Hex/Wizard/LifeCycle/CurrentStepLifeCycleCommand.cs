using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard.LifeCycle
{
	/// <summary>
	/// The wizard life cycle command that sets the result action name to the current step's action name.
	/// </summary>
	public class CurrentStepLifeCycleCommand
		: IWizardLifeCycleCommand
	{
		/// <summary>
		/// Executes the command.
		/// </summary>
		/// <param name="wizardLifeCycleContext">The wizard life cycle context.</param>
		public void Execute( WizardLifeCycleContext wizardLifeCycleContext )
		{
			wizardLifeCycleContext.ResultActionName = wizardLifeCycleContext.WizardController.WizardSteps.CurrentStep.ActionName;
		}
	}
}
