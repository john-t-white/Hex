using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard.LifeCycle
{
	public class RestoreWizardStateLifeCycleCommand
		: IWizardLifeCycleCommand
	{
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
