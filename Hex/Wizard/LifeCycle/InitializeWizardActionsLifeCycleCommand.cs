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

		public void Execute( WizardLifeCycleContext wizardLifeCycleContext )
		{
			WizardController wizardController = wizardLifeCycleContext.WizardController;
			ControllerContext controllerContext = wizardController.ControllerContext;
			IWizardActionInvoker wizardActionInvoker = wizardController.ActionInvoker;

			WizardActionDescriptor[] wizardActions = wizardActionInvoker.GetWizardActions( controllerContext );
			wizardActions = wizardActionInvoker.FilterUnauthorizedWizardActions( controllerContext, wizardActions );
			if( wizardActions == null || wizardActions.Length == 0 )
			{
				wizardLifeCycleContext.ResultActionName = HANDLE_NO_AUTHORIZED_WIZARD_ACTIONS_ACTION_NAME;
			}
			else
			{
				wizardController.WizardActions = wizardActions;
			}
		}
	}
}
