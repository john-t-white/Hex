﻿using Hex.Wizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.TestProject.Wizard.WizardStepInitializerTests
{
	public class FakeWizardControllerWithOverridenMethodWithNotAWizardStepAttribute
		: WizardController<object>
	{
		public ActionResult StepOne()
		{
			throw new NotImplementedException();
		}

		public ActionResult StepTwo()
		{
			throw new NotImplementedException();
		}

		public ActionResult StepThree()
		{
			throw new NotImplementedException();
		}

		public override ActionResult HandleNoWizardSteps()
		{
			throw new NotImplementedException();
		}
	}
}