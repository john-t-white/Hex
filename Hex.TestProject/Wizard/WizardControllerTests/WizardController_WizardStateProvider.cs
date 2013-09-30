using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;

namespace Hex.TestProject.Wizard.WizardControllerTests
{
	[TestClass]
	public class WizardController_WizardStateProvider
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			FakeWizardController wizardController = new FakeWizardController();

			IWizardStateProvider wizardStateProvider = wizardController.WizardStateProvider;

			Assert.IsNotNull( wizardStateProvider );
			Assert.IsInstanceOfType( wizardStateProvider, typeof( FormWizardStateProvider ) );
		}
	}
}
