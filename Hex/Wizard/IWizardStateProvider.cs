﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hex.Wizard
{
	public interface IWizardStateProvider
	{
		WizardState Load( ControllerContext controllerContext, string wizardStateToken );

		string Save( ControllerContext controllerContext, WizardState wizardState );
	}
}
