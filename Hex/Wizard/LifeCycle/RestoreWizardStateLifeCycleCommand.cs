using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard.LifeCycle
{
	/// <summary>
	/// The wizard life cycle command that restores the wizard state.
	/// </summary>
	public class RestoreWizardStateLifeCycleCommand
		: IWizardLifeCycleCommand
	{
		/// <summary>
		/// Executes the command.
		/// </summary>
		/// <param name="wizardLifeCycleContext">The wizard life cycle context.</param>
		public void Execute( WizardLifeCycleContext wizardLifeCycleContext )
		{
			WizardController wizardController = wizardLifeCycleContext.WizardController;

			WizardStep[] wizardSteps = ( from currentWizardStateStep in wizardLifeCycleContext.WizardState.Steps
										 let currentWizardAction = wizardController.WizardActions.FirstOrDefault( x => x.ActionName == currentWizardStateStep.ActionName )
										 where currentWizardAction != null
										 select new WizardStep( currentWizardAction, currentWizardStateStep.Values ) ).ToArray();

			WizardStep currentWizardStep = wizardSteps.FirstOrDefault( x => wizardLifeCycleContext.WizardState.CurrentStepActionName == x.ActionName );

			wizardController.WizardSteps = new WizardStepLinkedList( wizardSteps, currentWizardStep );
		}
	}
}
