using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hex.Wizard
{
	public class TempDataWizardStateProvider
		: IWizardStateProvider
	{
		private const string HTTP_CONTEXT_ITEMS_WIZARD_STATE_TOKEN_KEY = "__wizardStateToken";
		private const string TEMP_DATA_WIZARD_STATE_TOKEN_PATTERN = "__wizardStateToken-{0}";

		public WizardState Load( ControllerContext controllerContext, string wizardStateToken )
		{
			Controller controller = ( Controller )controllerContext.Controller;
			controller.TempData.Load( controllerContext, controller.TempDataProvider );

			string tempDataWizardStateTokenKey = string.Format( TEMP_DATA_WIZARD_STATE_TOKEN_PATTERN, wizardStateToken );

			WizardState wizardState = controller.TempData[ tempDataWizardStateTokenKey ] as WizardState;

			//Need to resave the temp data after getting the wizard state so it can be loaded correctly by the controller.
			controller.TempData.Save( controllerContext, controller.TempDataProvider );

			controllerContext.HttpContext.Items[ HTTP_CONTEXT_ITEMS_WIZARD_STATE_TOKEN_KEY ] = wizardStateToken;

			return wizardState;
		}

		public string Save( ControllerContext controllerContext, WizardState wizardState )
		{
			string wizardStateToken = controllerContext.HttpContext.Items[ HTTP_CONTEXT_ITEMS_WIZARD_STATE_TOKEN_KEY ] as string;
			if( string.IsNullOrWhiteSpace( wizardStateToken ) )
			{
				wizardStateToken = this.CreateNewWizardStateToken();
			}

			string tempDataWizardStateTokenKey = string.Format( TEMP_DATA_WIZARD_STATE_TOKEN_PATTERN, wizardStateToken );

			Controller controller = ( Controller )controllerContext.Controller;
			controller.TempData.Add( tempDataWizardStateTokenKey, wizardState );

			return wizardStateToken;
		}

		private string CreateNewWizardStateToken()
		{
			return Convert.ToBase64String( Guid.NewGuid().ToByteArray() );
		}
	}
}
