using Hex.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard.LifeCycle
{
	public class InitializeWizardStepsLifeCycleCommand
		: IWizardLifeCycleCommand
	{
		private const string HANDLE_NO_WIZARD_STEPS_ACTION_NAME = "HandleNoWizardSteps";

		public void Execute( WizardLifeCycleContext wizardLifeCycleContext, WizardController wizardController )
		{
			WizardStep[] wizardSteps = wizardController.WizardStepInitializer.InitializeWizardSteps( wizardController.ControllerContext.RequestContext, wizardController.WizardActions );
			if( wizardSteps == null || wizardSteps.Length == 0 )
			{
				wizardLifeCycleContext.ActionName = HANDLE_NO_WIZARD_STEPS_ACTION_NAME;
			}
			else
			{
				wizardController.WizardSteps = new WizardStepLinkedList( wizardSteps.ToArray() );
			}
		}
	}
}
