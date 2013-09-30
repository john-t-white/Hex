using Hex.Wizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.TestProject.Wizard.WizardStepInitializerTests
{
	public class FakeWizardControllerWithDifferentOrder
		: WizardController<object>
	{
		[WizardStep( Order = 1 )]
		public ActionResult StepOne()
		{
			throw new NotImplementedException();
		}

		public ActionResult StepTwo()
		{
			throw new NotImplementedException();
		}

		[WizardStep( Order = -1 )]
		public ActionResult StepThree()
		{
			throw new NotImplementedException();
		}
	}
}
