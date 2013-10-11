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
			WizardLifeCycleContext wizardLifeCycleContext = new WizardLifeCycleContext( wizardController );

			CreateWizardFormModelLifeCycleCommand lifeCycleCommand = new CreateWizardFormModelLifeCycleCommand();
			lifeCycleCommand.Execute( wizardLifeCycleContext );

			Assert.IsNotNull( wizardController.WizardFormModel );
			Assert.IsInstanceOfType( wizardController.WizardFormModel, wizardController.WizardFormModelType );

			Assert.IsNull( wizardLifeCycleContext.ResultActionName );
		}
	}
}
