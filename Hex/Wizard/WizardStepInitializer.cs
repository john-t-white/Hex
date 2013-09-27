using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hex.Wizard
{
	public class WizardStepInitializer
		: IWizardStepInitializer
	{
		public IEnumerable<WizardStep> InitializeWizardSteps( RequestContext requestContext, ActionDescriptor[] wizardActions )
		{
			return from ActionDescriptor currentActionDescriptor in wizardActions
				   let currentWizardStepAttribute = currentActionDescriptor.GetCustomAttributes( typeof( WizardStepAttribute ), false ).FirstOrDefault() as WizardStepAttribute
				   let currentName = ( currentWizardStepAttribute != null ) ? currentWizardStepAttribute.Name : null
				   let currentDescription = ( currentWizardStepAttribute != null ) ? currentWizardStepAttribute.Description : null
				   select new WizardStep( currentActionDescriptor.ActionName, currentName, currentDescription );
		}
	}
}
