using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.Wizard
{
	public class WizardControllerActionInvoker
		: ControllerActionInvoker, IWizardActionInvoker
	{
		public ActionDescriptor[] GetWizardActions( ControllerContext controllerContext )
		{
			ControllerDescriptor controllerDescriptor = this.GetControllerDescriptor( controllerContext );

			var wizardActions = from ActionDescriptor currentActionDescriptor in controllerDescriptor.GetCanonicalActions()
								let currentWizardStepAttribute = currentActionDescriptor.GetCustomAttributes( typeof( WizardStepAttribute ), false ).FirstOrDefault() as WizardStepAttribute
								let currentOrder = ( currentWizardStepAttribute != null ) ? currentWizardStepAttribute.Order : 0
								orderby currentOrder
								select currentActionDescriptor;

			return wizardActions.ToArray();
		}
	}
}
