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
			FakeWizardControllerWithNoActions wizardController = new FakeWizardControllerWithNoActions();

			IWizardStateProvider wizardStateProvider = wizardController.WizardStateProvider;

			Assert.IsNotNull( wizardStateProvider );
			Assert.IsInstanceOfType( wizardStateProvider, typeof( FormWizardStateProvider ) );
		}
	}
}
