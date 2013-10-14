using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;
using Hex.Wizard.LifeCycle;
using System.Web.Routing;
using System.Web.Mvc;
using Rhino.Mocks;

namespace Hex.TestProject.Wizard.LifeCycle.ProcessWizardButtonLifeCycleCommandTests
{
	[TestClass]
	public class ProcessWizardButtonLifeCycleCommand_Execute
	{
		[TestMethod]
		public void ExecutesButtonCommandCorrectly()
		{
			WizardController wizardController = this.GenerateWizardController();

			IWizardButtonCommand buttonCommand = MockRepository.GenerateMock<IWizardButtonCommand>();
			buttonCommand.Expect( x => x.ExecuteCommand( wizardController ) );

			IWizardButtonCommandFactory wizardButtonCommandFactory = MockRepository.GenerateMock<IWizardButtonCommandFactory>();
			wizardButtonCommandFactory.Expect( x => x.GetButtonCommand( wizardController ) )
				.Return( buttonCommand );

			WizardLifeCycleContext lifeCycleContext = new WizardLifeCycleContext( wizardController );

			ProcessWizardButtonLifeCycleCommand lifeCycleCommand = new ProcessWizardButtonLifeCycleCommand();
			lifeCycleCommand.WizardButtonCommandFactory = wizardButtonCommandFactory;

			lifeCycleCommand.Execute( lifeCycleContext );

			wizardButtonCommandFactory.VerifyAllExpectations();
			buttonCommand.VerifyAllExpectations();

			Assert.IsNull( lifeCycleContext.ResultActionName );
		}

		private WizardController GenerateWizardController()
		{
			RequestContext requestContext = new RequestContext();
			FakeWizardControllerWithThreeSteps wizardController = new FakeWizardControllerWithThreeSteps();
			ControllerContext controllerContext = new ControllerContext( requestContext, wizardController );
			wizardController.ControllerContext = controllerContext;

			return wizardController;
		}
	}
}
