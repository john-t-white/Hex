using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hex.Wizard
{
	public interface IWizardStepInitializer
	{
		IEnumerable<WizardStep> InitializeWizardSteps( RequestContext requestContext, ActionDescriptor[] wizardActions );
	}
}
