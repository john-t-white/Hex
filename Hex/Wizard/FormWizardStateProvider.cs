using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace Hex.Wizard
{
	public class FormWizardStateProvider
		: IWizardStateProvider
	{
		public WizardState Load( ControllerContext controllerContext, string wizardStateToken )
		{
			byte[] decodedWizardStateBytes = MachineKey.Decode( wizardStateToken, MachineKeyProtection.All );
			string decodedWizardState = Encoding.Unicode.GetString( decodedWizardStateBytes );

			return JsonConvert.DeserializeObject<WizardState>( decodedWizardState );
		}

		public string Save( ControllerContext controllerContext, WizardState wizardState )
		{
			string serializedWizardState = JsonConvert.SerializeObject( wizardState );
			byte[] serializedWizardStateBytes = Encoding.Unicode.GetBytes( serializedWizardState );

			return MachineKey.Encode( serializedWizardStateBytes, MachineKeyProtection.All );
		}
	}
}
