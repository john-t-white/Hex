using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;
using System.Web.Routing;
using System.Web.Mvc;

namespace Hex.TestProject.Wizard.WizardContextTests
{
	[TestClass]
	public class WizardContext_InitializeWizardSteps
	{
		[TestMethod]
		public void WithNoWizardStepAttributesSetsWizardStepsCorrectly()
		{
			RequestContext requestContext = new RequestContext();
			FakeWizardController wizardController = new FakeWizardController();
			ControllerContext controllerContext = new ControllerContext( requestContext, wizardController );
			wizardController.ControllerContext = controllerContext;
			
			WizardContext wizardContext = new WizardContext( requestContext, wizardController );
			wizardContext.InitializeWizardSteps();

			WizardStep[] wizardSteps = wizardContext.WizardSteps.ToArray();
			Assert.AreEqual( 3, wizardSteps.Length );

			WizardStep wizardStepOne = wizardSteps[ 0 ];
			Assert.AreEqual( "StepOne", wizardStepOne.ActionName );
			Assert.AreEqual( "StepOne", wizardStepOne.Name );
			Assert.IsNull( wizardStepOne.Description );

			WizardStep wizardStepTwo = wizardSteps[ 1 ];
			Assert.AreEqual( "StepTwo", wizardStepTwo.ActionName );
			Assert.AreEqual( "StepTwo", wizardStepTwo.Name );
			Assert.IsNull( wizardStepTwo.Description );

			WizardStep wizardStepThree = wizardSteps[ 2 ];
			Assert.AreEqual( "StepThree", wizardStepThree.ActionName );
			Assert.AreEqual( "StepThree", wizardStepThree.Name );
			Assert.IsNull( wizardStepThree.Description );
		}

		[TestMethod]
		public void WitWizardStepAttributesSetsWizardStepsCorrectly()
		{
			RequestContext requestContext = new RequestContext();
			FakeWizardControllerWithWizardStepAttributes wizardController = new FakeWizardControllerWithWizardStepAttributes();
			ControllerContext controllerContext = new ControllerContext( requestContext, wizardController );
			wizardController.ControllerContext = controllerContext;

			WizardContext wizardContext = new WizardContext( requestContext, wizardController );
			wizardContext.InitializeWizardSteps();

			WizardStep[] wizardSteps = wizardContext.WizardSteps.ToArray();
			Assert.AreEqual( 3, wizardSteps.Length );

			WizardStep wizardStepOne = wizardSteps[ 0 ];
			Assert.AreEqual( "StepOne", wizardStepOne.ActionName );
			Assert.AreEqual( "StepOneName", wizardStepOne.Name );
			Assert.AreEqual( "StepOneDescription", wizardStepOne.Description );

			WizardStep wizardStepTwo = wizardSteps[ 1 ];
			Assert.AreEqual( "StepTwo", wizardStepTwo.ActionName );
			Assert.AreEqual( "StepTwoName", wizardStepTwo.Name );
			Assert.AreEqual( "StepTwoDescription", wizardStepTwo.Description );

			WizardStep wizardStepThree = wizardSteps[ 2 ];
			Assert.AreEqual( "StepThree", wizardStepThree.ActionName );
			Assert.AreEqual( "StepThreeName", wizardStepThree.Name );
			Assert.AreEqual( "StepThreeDescription", wizardStepThree.Description );
		}
	}
}
