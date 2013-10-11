using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard.LifeCycle;

namespace Hex.TestProject.Wizard.LifeCycle.WizardLifeCycleTests
{
	[TestClass]
	public class WizardLifeCycle_ctor
	{
		[TestMethod]
		public void CreatesCorrectly()
		{
			FakeWizardController wizardController = new FakeWizardController();

			WizardLifeCycle wizardLifeCycle = new WizardLifeCycle( wizardController );
			Assert.AreSame( wizardController, wizardLifeCycle.WizardController );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentNullException ) )]
		public void WithNullWizardControllerThrowsArgumentNullException()
		{
			FakeWizardController wizardController = null;

			new WizardLifeCycle( wizardController );
		}
	}
}
