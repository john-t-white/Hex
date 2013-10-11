using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard.LifeCycle;

namespace Hex.TestProject.Wizard.LifeCycle.CreateWizardFormModelLifeCycleCommandTests
{
	[TestClass]
	public class CreateWizardFormModelLifeCycleCommand_Execute
	{
		[TestMethod]
		public void CreatesAndSetsWizardFormModelCorrectly()
		{
			FakeWizardControllerWithNoActions wizardController = new FakeWizardControllerWithNoActions();
			WizardLifeCycleContext lifeCycleContext = new WizardLifeCycleContext( wizardController );

			CreateWizardFormModelLifeCycleCommand lifeCycleCommand = new CreateWizardFormModelLifeCycleCommand();
			lifeCycleCommand.Execute( lifeCycleContext );

			Assert.IsNotNull( wizardController.WizardFormModel );
			Assert.IsInstanceOfType( wizardController.WizardFormModel, wizardController.WizardFormModelType );
		}
	}
}
