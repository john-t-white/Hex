using Hex.Wizard;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.TestProject.Wizard.WizardActionDescriptorTests
{
	public class FakeWizardControllerWithWizardStepAttribute
		: WizardController<object>
	{
		[Display( Name = "Name", Description = "Description", Order = 1 )]
		public ActionResult StepOne()
		{
			throw new NotImplementedException();
		}
	}
}
