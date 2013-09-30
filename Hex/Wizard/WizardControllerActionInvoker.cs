using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.Wizard
{
	public interface IWizardActionInvoker
		: IActionInvoker
	{
		WizardActionDescriptor[] GetWizardActions( ControllerContext controllerContext );
	}

	public class WizardControllerActionInvoker
		: ControllerActionInvoker, IWizardActionInvoker
	{
		public WizardActionDescriptor[] GetWizardActions( ControllerContext controllerContext )
		{
			ControllerDescriptor controllerDescriptor = this.GetControllerDescriptor( controllerContext );

			return ( from ActionDescriptor currentActionDescriptor in controllerDescriptor.GetCanonicalActions()
					 select new WizardActionDescriptor( currentActionDescriptor ) ).ToArray();
		}
	}
}
