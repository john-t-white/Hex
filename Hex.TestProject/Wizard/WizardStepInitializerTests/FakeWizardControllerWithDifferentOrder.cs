using Hex.Wizard;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.TestProject.Wizard.WizardStepInitializerTests
{
	public class FakeWizardControllerWithDifferentOrder
		: WizardController<object>
	{
		[Display( Order = 1 )]
		public ActionResult StepOne()
		{
			throw new NotImplementedException();
		}

		public ActionResult StepTwo()
		{
			throw new NotImplementedException();
		}

		[Display( Order = -1 )]
		public ActionResult StepThree()
		{
			throw new NotImplementedException();
		}
	}
}
