using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard.LifeCycle
{
	public class CurrentStepLifeCycleCommand
		: IWizardLifeCycleCommand
	{
		public void Execute( WizardLifeCycleContext wizardLifeCycleContext )
		{
			wizardLifeCycleContext.ResultActionName = wizardLifeCycleContext.WizardController.WizardSteps.CurrentStep.ActionName;
		}
	}
}
