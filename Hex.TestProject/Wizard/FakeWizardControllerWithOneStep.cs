﻿using Hex.Wizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.TestProject.Wizard
{
	public class FakeWizardControllerWithOneStep
		: WizardController<object>
	{
		public ActionResult StepOne()
		{
			throw new NotImplementedException();
		}
	}
}