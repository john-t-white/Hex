using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;
using System.Web.Mvc;
using Rhino.Mocks;
using System.Web.Routing;
using System.Reflection;
using Hex.Wizard.LifeCycle;

namespace Hex.TestProject.Wizard.LifeCycle.InitializeWizardStepsLifeCycleCommandTests
{
	[TestClass]
	public class InitializeWizardStepsLifeCycleCommand_Execute
	{
		[TestMethod]
		public void SetsWizardStepsCorrectly()
		{
			WizardController wizardController = this.GenerateWizardController( true );

			WizardLifeCycleContext wizardLifeCycleContext = new WizardLifeCycleContext( wizardController );

			InitializeWizardStepsLifeCycleCommand lifeCycleCommand = new InitializeWizardStepsLifeCycleCommand();
			lifeCycleCommand.Execute( wizardLifeCycleContext );

			wizardController.WizardStepInitializer.VerifyAllExpectations();

			Assert.IsNotNull( wizardController.WizardSteps );
			Assert.AreEqual( 3, wizardController.WizardSteps.Count );

			Assert.IsNull( wizardLifeCycleContext.ResultActionName );
		}

		[TestMethod]
		public void WithNoWizardStepsSetsResultActionNameCorrectly()
		{
			WizardController wizardController = this.GenerateWizardController( false );

			WizardLifeCycleContext wizardLifeCycleContext = new WizardLifeCycleContext( wizardController );

			InitializeWizardStepsLifeCycleCommand lifeCycleCommand = new InitializeWizardStepsLifeCycleCommand();
			lifeCycleCommand.Execute( wizardLifeCycleContext );

			wizardController.WizardStepInitializer.VerifyAllExpectations();

			Assert.AreEqual( "HandleNoWizardSteps", wizardLifeCycleContext.ResultActionName );
		}

		private WizardController GenerateWizardController( bool returnWizardSteps )
		{
			RequestContext requestContext = new RequestContext();
			FakeWizardControllerWithThreeSteps wizardController = new FakeWizardControllerWithThreeSteps();
			ControllerContext controllerContext = new ControllerContext( requestContext, wizardController );
			wizardController.ControllerContext = controllerContext;

			wizardController.WizardActions = wizardController.ActionInvoker.GetWizardActions( controllerContext );

			WizardStep[] wizardSteps = ( from WizardActionDescriptor currentWizardAction in wizardController.WizardActions
										 select new WizardStep( currentWizardAction ) ).ToArray();

			IWizardStepInitializer wizardStepInitializer = MockRepository.GenerateMock<IWizardStepInitializer>();

			if( returnWizardSteps )
			{
				wizardStepInitializer.Expect( x => x.InitializeWizardSteps( controllerContext.RequestContext, wizardController.WizardActions ) )
					.Return( wizardSteps );
			}
			else
			{
				wizardStepInitializer.Expect( x => x.InitializeWizardSteps( controllerContext.RequestContext, wizardController.WizardActions ) )
					.Return( new WizardStep[] {} );
			}

			wizardController.WizardStepInitializer = wizardStepInitializer;

			return wizardController;
		}
	}
}
