using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard.LifeCycle;
using System.Web.Routing;
using System.Web.Mvc;
using Hex.Wizard;
using Rhino.Mocks;

namespace Hex.TestProject.Wizard.LifeCycle.LoadWizardStateLifeCycleCommandTests
{
	[TestClass]
	public class LoadWizardStateLifeCycleCommand_Execute
	{
		[TestMethod]
		public void LoadsWizardStateCorrectly()
		{
			string wizardStateToken = "WizardStateToken";

			WizardState wizardState = new WizardState( "ActionName", new WizardStepState[] { new WizardStepState( "ActionName", null ) } );

			WizardController wizardController = this.GenerateWizardController( wizardStateToken, wizardState );

			WizardLifeCycleContext lifeCycleContext = new WizardLifeCycleContext( wizardController );

			LoadWizardStateLifeCycleCommand lifeCycleCommand = new LoadWizardStateLifeCycleCommand( wizardStateToken );
			lifeCycleCommand.Execute( lifeCycleContext );

			wizardController.WizardStateProvider.VerifyAllExpectations();

			Assert.IsNull( lifeCycleContext.ResultActionName );
			Assert.AreSame( wizardState, lifeCycleContext.WizardState );
		}

		[TestMethod]
		public void WithWizardStateNotFoundSetsResultActionNameCorrectly()
		{
			string wizardStateToken = "WizardStateToken";

			WizardState wizardState = null;

			WizardController wizardController = this.GenerateWizardController( wizardStateToken, wizardState );

			WizardLifeCycleContext lifeCycleContext = new WizardLifeCycleContext( wizardController );

			LoadWizardStateLifeCycleCommand lifeCycleCommand = new LoadWizardStateLifeCycleCommand( wizardStateToken );
			lifeCycleCommand.Execute( lifeCycleContext );

			wizardController.WizardStateProvider.VerifyAllExpectations();

			Assert.AreEqual( "HandleWizardStateNotFound", lifeCycleContext.ResultActionName );
			Assert.IsNull( lifeCycleContext.WizardState );
		}



		private WizardController GenerateWizardController( string wizardStateToken, WizardState expectedWizardState )
		{
			RequestContext requestContext = new RequestContext();
			FakeWizardControllerWithThreeSteps wizardController = new FakeWizardControllerWithThreeSteps();
			ControllerContext controllerContext = new ControllerContext( requestContext, wizardController );
			wizardController.ControllerContext = controllerContext;

			IWizardStateProvider wizardStateProvider = MockRepository.GenerateMock<IWizardStateProvider>();
			wizardStateProvider.Expect( x => x.Load( controllerContext, wizardStateToken ) )
				.Return( expectedWizardState );

			wizardController.WizardStateProvider = wizardStateProvider;

			return wizardController;
		}
	}
}
