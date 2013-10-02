using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;

namespace Hex.TestProject.Wizard.WizardControllerTests
{
	[TestClass]
	public class WizardController_WizardButtonCommandFactory
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			FakeWizardController wizardController = new FakeWizardController();

			IWizardButtonCommandFactory wizardButtonCommandFactory = wizardController.WizardButtonCommandFactory;

			Assert.IsNotNull( wizardButtonCommandFactory );
			Assert.IsInstanceOfType( wizardButtonCommandFactory, typeof( WizardButtonCommandFactory ) );
		}
	}
}
