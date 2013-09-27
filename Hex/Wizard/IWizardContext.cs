using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace Hex.Wizard
{
	public interface IWizardContext
	{
		RequestContext RequestContext { get; }

		WizardController WizardController { get; }

		IWizardActionInvoker ActionInvoker { get; }

		IWizardStepCollection WizardSteps { get; }
	}
}
