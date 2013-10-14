using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;
using System.Web.Routing;
using System.Web.Mvc;
using Hex.Wizard.LifeCycle;

namespace Hex.TestProject.Wizard.LifeCycle.RestoreWizardStateLifeCycleCommandTests
{
	[TestClass]
	public class RestoreWizardStateLifeCycleCommand_Execute
	{
		[TestMethod]
		public void SetsWizardStepsCorrectly()
		{
			WizardController wizardController = this.GenerateWizardController();

			WizardStepState[] steps = new WizardStepState[]
			{
				new WizardStepState( "StepOne", new WizardStepValueCollection() ),
				new WizardStepState( "StepTwo", new WizardStepValueCollection() ),
				new WizardStepState( "StepThree", new WizardStepValueCollection() ),
			};

			WizardState wizardState = new WizardState( steps[ 1 ].ActionName, steps );

			WizardLifeCycleContext lifeCycleContext = new WizardLifeCycleContext( wizardController );
			lifeCycleContext.WizardState = wizardState;

			RestoreWizardStateLifeCycleCommand lifeCycleCommand = new RestoreWizardStateLifeCycleCommand();
			lifeCycleCommand.Execute( lifeCycleContext );

			Assert.AreEqual( 3, wizardController.WizardSteps.Count );

			WizardStep[] wizardStepArray = wizardController.WizardSteps.ToArray();

			WizardStep wizardStepOne = wizardStepArray[ 0 ];
			Assert.AreEqual( "StepOne", wizardStepOne.ActionName );
			Assert.AreSame( steps[ 0 ].Values, wizardStepOne.Values );

			WizardStep wizardStepTwo = wizardStepArray[ 1 ];
			Assert.AreEqual( "StepTwo", wizardStepTwo.ActionName );
			Assert.AreSame( steps[ 1 ].Values, wizardStepTwo.Values );

			WizardStep wizardStepThree = wizardStepArray[ 2 ];
			Assert.AreEqual( "StepThree", wizardStepThree.ActionName );
			Assert.AreSame( steps[ 2 ].Values, wizardStepThree.Values );

			WizardStep currentWizardStep = wizardController.WizardSteps.CurrentStep;
			Assert.AreSame( wizardStepTwo, currentWizardStep );

			Assert.IsNull( lifeCycleContext.ResultActionName );
		}



		private WizardController GenerateWizardController()
		{
			RequestContext requestContext = new RequestContext();
			FakeWizardControllerWithThreeSteps wizardController = new FakeWizardControllerWithThreeSteps();
			ControllerContext controllerContext = new ControllerContext( requestContext, wizardController );
			wizardController.ControllerContext = controllerContext;

			wizardController.WizardActions = wizardController.ActionInvoker.GetWizardActions( controllerContext );

			return wizardController;
		}
	}
}
