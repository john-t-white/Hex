﻿using System;
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

	public class WizardStepInitializer
		: IWizardStepInitializer
	{
		public IEnumerable<WizardStep> InitializeWizardSteps( RequestContext requestContext, ActionDescriptor[] wizardActions )
		{
			return from ActionDescriptor currentActionDescriptor in wizardActions
				   let currentWizardStepAttribute = currentActionDescriptor.GetCustomAttributes( typeof( WizardStepAttribute ), false ).FirstOrDefault() as WizardStepAttribute
				   let currentName = ( currentWizardStepAttribute != null ) ? currentWizardStepAttribute.Name : null
				   let currentDescription = ( currentWizardStepAttribute != null ) ? currentWizardStepAttribute.Description : null
				   let currentOrder = ( currentWizardStepAttribute != null ) ? currentWizardStepAttribute.Order : 0
				   orderby currentOrder
				   select new WizardStep( currentActionDescriptor.ActionName, currentName, currentDescription );
		}
	}
}
