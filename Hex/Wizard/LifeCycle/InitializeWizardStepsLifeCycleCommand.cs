using Hex.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard.LifeCycle
{
	/// <summary>
	/// The wizard life cycle command that initializes the wizard steps.
	/// </summary>
	public class InitializeWizardStepsLifeCycleCommand
		: IWizardLifeCycleCommand
	{
		private const string HANDLE_NO_WIZARD_STEPS_ACTION_NAME = "HandleNoWizardSteps";

		/// <summary>
		/// Executes the command.
		/// </summary>
		/// <param name="wizardLifeCycleContext">The wizard life cycle context.</param>
		public void Execute( WizardLifeCycleContext wizardLifeCycleContext )
		{
			WizardController wizardController = wizardLifeCycleContext.WizardController;

			WizardStep[] wizardSteps = wizardController.WizardStepInitializer.InitializeWizardSteps( wizardController.ControllerContext.RequestContext, wizardController.WizardActions );
			if( wizardSteps == null || wizardSteps.Length == 0 )
			{
				wizardLifeCycleContext.ResultActionName = HANDLE_NO_WIZARD_STEPS_ACTION_NAME;
			}
			else
			{
				wizardController.WizardSteps = new WizardStepLinkedList( wizardSteps.ToArray() );
			}
		}
	}
}
