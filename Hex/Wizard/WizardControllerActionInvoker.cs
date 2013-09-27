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

			return controllerDescriptor.GetCanonicalActions();
		}
	}
}
