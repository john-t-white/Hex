using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.Wizard.LifeCycle
{
	public class InitializeWizardActionsLifeCycleCommand
		: IWizardLifeCycleCommand
	{
		private const string HANDLE_NO_AUTHORIZED_WIZARD_ACTIONS_ACTION_NAME = "HandleNoAuthorizedWizardActions";

		public void Execute( WizardLifeCycleContext wizardLifeCycleContext, WizardController wizardController )
		{
			ControllerContext controllerContext = wizardController.ControllerContext;

			WizardActionDescriptor[] wizardActions = wizardController.ActionInvoker.GetWizardActions( controllerContext );
			wizardActions = wizardController.ActionInvoker.FilterUnauthorizedWizardActions( controllerContext, wizardActions );
			if( wizardActions == null || wizardActions.Length == 0 )
			{
				wizardLifeCycleContext.ActionName = HANDLE_NO_AUTHORIZED_WIZARD_ACTIONS_ACTION_NAME;
			}
			else
			{
				wizardController.WizardActions = wizardActions;
			}
		}
	}
}
