using Hex.Wizard;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.TestProject.Wizard.WizardStepInitializerTests
{
	public class FakeWizardControllerWithDisplayAttributes
		: WizardController<object>
	{
		[Display( Name = "StepOneName", Description = "StepOneDescription" )]
		public ActionResult StepOne()
		{
			throw new NotImplementedException();
		}

		[Display( Name = "StepTwoName", Description = "StepTwoDescription" )]
		public ActionResult StepTwo()
		{
			throw new NotImplementedException();
		}

		[Display( Name = "StepThreeName", Description = "StepThreeDescription" )]
		public ActionResult StepThree()
		{
			throw new NotImplementedException();
		}
	}
}
