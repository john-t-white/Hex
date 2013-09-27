using Hex.Wizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.TestProject.Wizard.WizardStepInitializerTests
{
	public class FakeWizardControllerWithWizardStepAttributes
		: WizardController
	{
		[WizardStep( Name = "StepOneName", Description = "StepOneDescription" )]
		public ActionResult StepOne()
		{
			throw new NotImplementedException();
		}

		[WizardStep( Name = "StepTwoName", Description = "StepTwoDescription" )]
		public ActionResult StepTwo()
		{
			throw new NotImplementedException();
		}

		[WizardStep( Name = "StepThreeName", Description = "StepThreeDescription" )]
		public ActionResult StepThree()
		{
			throw new NotImplementedException();
		}
	}
}
