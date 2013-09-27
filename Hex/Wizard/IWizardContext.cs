using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hex.Wizard
{
	public interface IWizardContext
	{
		RequestContext RequestContext { get; }

		WizardController WizardController { get; }

		ControllerContext ControllerContext { get; }

		IWizardActionInvoker ActionInvoker { get; }

		IValueProvider ValueProvider { get; }

		IWizardStepCollection WizardSteps { get; }
	}
}
