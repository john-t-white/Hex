using Hex.Wizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.TestProject.Wizard.WizardActionDescriptorTests
{
	public class FakeWizardControllerWithWizardStepAttribute
		: WizardController<object>
	{
		[WizardStep( Name = "Name", Description = "Description", Order = 1 )]
		public ActionResult StepOne()
		{
			throw new NotImplementedException();
		}
	}
}
