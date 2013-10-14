using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard.LifeCycle;
using Hex.Wizard;

namespace Hex.TestProject.Wizard.LifeCycle.WizardLifeCycleContextTests
{
	[TestClass]
	public class WizardLifeCycleContext_ctor
	{
		[TestMethod]
		public void CreatesCorrectly()
		{
			FakeWizardControllerWithNoActions wizardController = new FakeWizardControllerWithNoActions();

			WizardLifeCycleContext wizardLifeCycleContext = new WizardLifeCycleContext( wizardController );

			Assert.AreSame( wizardController, wizardLifeCycleContext.WizardController );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentNullException ) )]
		public void WithNullWizardControllerThrowsArgumentNullException()
		{
			WizardController wizardController = null;

			new WizardLifeCycleContext( wizardController );
		}
	}
}
