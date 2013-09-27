﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.Wizard
{
	public interface IWizardActionInvoker
		: IActionInvoker
	{
		ActionDescriptor[] GetWizardActions( ControllerContext controllerContext );
	}

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
