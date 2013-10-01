using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.Wizard
{
	public interface IWizardActionInvoker
		: IActionInvoker
	{
		WizardActionDescriptor[] GetWizardActions( ControllerContext controllerContext );
	}

	public class WizardControllerActionInvoker
		: ControllerActionInvoker, IWizardActionInvoker
	{
		private static readonly Type OPEN_WIZARD_STEP_VIEW_MODEL = typeof( WizardStepViewModel<> );
		private static readonly Type OPEN_WIZARD_STEP_VIEW_MODEL_INTERFACE = typeof( IWizardStepViewModel<> );

		public WizardActionDescriptor[] GetWizardActions( ControllerContext controllerContext )
		{
			ControllerDescriptor controllerDescriptor = this.GetControllerDescriptor( controllerContext );

			return ( from ActionDescriptor currentActionDescriptor in controllerDescriptor.GetCanonicalActions()
					 select new WizardActionDescriptor( currentActionDescriptor ) ).ToArray();
		}

		protected override ActionResult CreateActionResult( ControllerContext controllerContext, ActionDescriptor actionDescriptor, object actionReturnValue )
		{
			ActionResult actionResult = base.CreateActionResult( controllerContext, actionDescriptor, actionReturnValue );

			WizardController wizardController = controllerContext.Controller as WizardController;
			ViewResultBase viewResultBase = actionResult as ViewResultBase;
			if( wizardController != null && viewResultBase != null )
			{
				IWizardStepViewModel wizardStepViewModel;
				if( viewResultBase.Model == null )
				{
					Type viewModelType = OPEN_WIZARD_STEP_VIEW_MODEL.MakeGenericType( wizardController.WizardFormModelType );
					viewResultBase.ViewData.Model = wizardStepViewModel = ( IWizardStepViewModel )Activator.CreateInstance( viewModelType );
				}
				else
				{
					Type viewModelInterfaceType = OPEN_WIZARD_STEP_VIEW_MODEL_INTERFACE.MakeGenericType( wizardController.WizardFormModelType );
					if( !( viewModelInterfaceType.IsAssignableFrom( viewResultBase.Model.GetType() ) ) )
					{
						string exceptionMessage = string.Format( "The wizard step view model must implement '{0}'.", viewModelInterfaceType.FullName );
						throw new InvalidOperationException( exceptionMessage );
					}

					wizardStepViewModel = ( IWizardStepViewModel )viewResultBase.Model;
				}

				wizardStepViewModel.SetWizardFormModel( wizardController.WizardFormModel );
			}

			return actionResult;
		}
	}
}
