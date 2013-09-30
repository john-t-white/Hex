using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace Hex.Wizard
{
	public interface IWizardStateProvider
	{
		WizardState Load( RequestContext requestContext, string wizardStateToken );

		string Save( RequestContext requestContext, WizardState wizardState );
	}
}
