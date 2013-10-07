using Hex.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Hex.Wizard
{
	public interface IWizardActionInvoker
		: IActionInvoker
	{
		WizardActionDescriptor[] GetWizardActions( ControllerContext controllerContext );
		WizardActionDescriptor[] FilterUnauthorizedWizardActions( ControllerContext controllerContext, WizardActionDescriptor[] wizardActionDescriptors );
	}

	public class WizardControllerActionInvoker
		: ControllerActionInvoker, IWizardActionInvoker
	{
		private static readonly Type OPEN_WIZARD_STEP_VIEW_MODEL = typeof( WizardStepViewModel<> );
		private static readonly Type OPEN_WIZARD_STEP_VIEW_MODEL_INTERFACE = typeof( IWizardStepViewModel<> );

		public WizardActionDescriptor[] GetWizardActions( ControllerContext controllerContext )
		{
			ControllerDescriptor controllerDescriptor = this.GetControllerDescriptor( controllerContext );

			WizardActionDescriptor[] wizardActions = ( from ActionDescriptor currentActionDescriptor in controllerDescriptor.GetCanonicalActions()
													   let notAWizardStepAttribute = currentActionDescriptor.GetCustomAttributes( typeof( NotAWizardStepAttribute ), true ).FirstOrDefault() as NotAWizardStepAttribute
													   where notAWizardStepAttribute == null
													   select new WizardActionDescriptor( currentActionDescriptor ) ).ToArray();

			if( wizardActions == null || wizardActions.Length == 0 )
			{
				string exceptionMessage = string.Format( ExceptionMessages.NO_WIZARD_ACTIONS_FOUND, controllerContext.Controller.GetType().FullName );
				throw new HttpException( ( int )HttpStatusCode.NotFound, exceptionMessage );
			}

			return wizardActions;
		}

		public WizardActionDescriptor[] FilterUnauthorizedWizardActions( ControllerContext controllerContext, WizardActionDescriptor[] wizardActionDescriptors )
		{
			List<WizardActionDescriptor> authorizedWizardActionDescriptors = new List<WizardActionDescriptor>();
			foreach( WizardActionDescriptor currentWizardActionDescriptor in wizardActionDescriptors )
			{
				bool isAuthorizedWizardActionDescriptor = true;
				AuthorizationContext currentAuthorizationContext = new AuthorizationContext( controllerContext, currentWizardActionDescriptor );
				FilterInfo currentWizardActionDescriptorFilterInfo = this.GetFilters( controllerContext, currentWizardActionDescriptor );
				foreach( IAuthorizationFilter currentAuthorizationFilter in currentWizardActionDescriptorFilterInfo.AuthorizationFilters )
				{
					try
					{
						currentAuthorizationFilter.OnAuthorization( currentAuthorizationContext );
						if( currentAuthorizationContext.Result != null )
						{
							isAuthorizedWizardActionDescriptor = false;
							break;
						}
					}
					catch
					{
						isAuthorizedWizardActionDescriptor = false;
						break;
					}
				}

				if( isAuthorizedWizardActionDescriptor )
				{
					authorizedWizardActionDescriptors.Add( currentWizardActionDescriptor );
				}
			}

			return authorizedWizardActionDescriptors.ToArray();
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
						string exceptionMessage = string.Format( ExceptionMessages.WIZARD_STEP_VIEW_MODEL_DOES_NOT_IMPLEMENT_IWIZARDSTEPVIEWMODEL, viewModelInterfaceType.FullName );
						throw new InvalidOperationException( exceptionMessage );
					}

					wizardStepViewModel = ( IWizardStepViewModel )viewResultBase.Model;
				}

				wizardStepViewModel.SetWizardFormModel( wizardController.WizardFormModel );
				wizardStepViewModel.WizardSteps = wizardController.WizardSteps;
			}

			return actionResult;
		}
	}
}
