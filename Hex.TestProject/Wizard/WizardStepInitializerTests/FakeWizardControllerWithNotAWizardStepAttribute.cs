using Hex.Wizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.TestProject.Wizard.WizardStepInitializerTests
{
	public class FakeWizardControllerWithNotAWizardStepAttribute
		: WizardController<object>
	{
		public ActionResult StepOne()
		{
			throw new NotImplementedException();
		}

		[NotAWizardStep]
		public ActionResult StepTwo()
		{
			throw new NotImplementedException();
		}

		public ActionResult StepThree()
		{
			throw new NotImplementedException();
		}
	}
}
