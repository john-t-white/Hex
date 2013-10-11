using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;

namespace Hex.TestProject.Wizard.WizardControllerTests
{
	[TestClass]
	public class WizardController_ActionInvoker
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			FakeWizardControllerWithNoActions wizardController = new FakeWizardControllerWithNoActions();

			IWizardActionInvoker actionInvoker = wizardController.ActionInvoker;

			Assert.IsNotNull( actionInvoker );
			Assert.IsInstanceOfType( actionInvoker, typeof( WizardControllerActionInvoker ) );
		}
	}
}
