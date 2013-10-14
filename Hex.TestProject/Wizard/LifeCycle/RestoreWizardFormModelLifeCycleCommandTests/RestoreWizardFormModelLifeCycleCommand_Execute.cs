using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Routing;
using Hex.Wizard;
using Hex.Wizard.LifeCycle;
using System.Web.Mvc;

namespace Hex.TestProject.Wizard.LifeCycle.RestoreWizardFormModelLifeCycleCommandTests
{
	[TestClass]
	public class RestoreWizardFormModelLifeCycleCommand_Execute
	{
		[TestMethod]
		public void SetsWizardFormModelPropertiesCorrectly()
		{
			WizardController<FakeWizardFormModel> wizardController = this.GenerateWizardController();

			WizardLifeCycleContext lifeCycleContext = new WizardLifeCycleContext( wizardController );

			RestoreWizardFormModelLifeCycleCommand lifeCycleCommand = new RestoreWizardFormModelLifeCycleCommand();
			lifeCycleCommand.Execute( lifeCycleContext );

			Assert.AreEqual( "StepOneStringValue", wizardController.WizardFormModel.StepOne.StepOneStringValue );
			Assert.AreEqual( 2, wizardController.WizardFormModel.StepTwo.StepTwoIntegerValue );

			Assert.IsNull( lifeCycleContext.ResultActionName );
		}



		private WizardController<FakeWizardFormModel> GenerateWizardController()
		{
			RequestContext requestContext = new RequestContext();
			FakeWizardController wizardController = new FakeWizardController();
			ControllerContext controllerContext = new ControllerContext( requestContext, wizardController );
			wizardController.ControllerContext = controllerContext;

			WizardStepValueCollection stepOneValues = new WizardStepValueCollection();
			stepOneValues.Add( "StepOne.StepOneStringValue", "StepOneStringValue" );
			WizardStep wizardStepOne = new WizardStep( "ActionName", "Name", "Description", "Prompt", "GroupName", "ShortName", stepOneValues );

			WizardStepValueCollection stepTwoValues = new WizardStepValueCollection();
			stepTwoValues.Add( "StepTwo.StepTwoIntegerValue", "2" );
			WizardStep wizardStepTwo = new WizardStep( "ActionName", "Name", "Description", "Prompt", "GroupName", "ShortName", stepTwoValues );

			wizardController.WizardSteps = new WizardStepLinkedList( new WizardStep[] { wizardStepOne, wizardStepTwo } );

			wizardController.WizardFormModel = new FakeWizardFormModel();

			return wizardController;
		}
	}
}
