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
		IEnumerable<WizardStep> InitializeWizardSteps( RequestContext requestContext, WizardActionDescriptor[] wizardActions );
	}

	public class WizardStepInitializer
		: IWizardStepInitializer
	{
		public IEnumerable<WizardStep> InitializeWizardSteps( RequestContext requestContext, WizardActionDescriptor[] wizardActions )
		{
			return from WizardActionDescriptor currentActionDescriptor in wizardActions
				   orderby currentActionDescriptor.Order
				   select new WizardStep( currentActionDescriptor.ActionName, currentActionDescriptor.Name, currentActionDescriptor.Description );
		}
	}
}
