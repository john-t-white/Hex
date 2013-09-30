using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;

namespace Hex.TestProject.Wizard.WizardControllerTests
{
	[TestClass]
	public class WizardController_WizardStepInitializer
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			FakeWizardController wizardController = new FakeWizardController();

			IWizardStepInitializer wizardStepInitializer = wizardController.WizardStepInitializer;

			Assert.IsNotNull( wizardStepInitializer );
			Assert.IsInstanceOfType( wizardStepInitializer, typeof( WizardStepInitializer ) );
		}
	}
}
