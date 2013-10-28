using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;
using System.Web.Mvc;
using System.Globalization;
using Hex.Wizard.LifeCycle;

namespace Hex.TestProject.Wizard.LifeCycle.NextWizardButtonCommandTests
{
	[TestClass]
	public class NextWizardButtonCommand_Execute
	{
		[TestMethod]
		public void ExecutesCorrectly()
		{
			WizardStepLinkedList wizardStepLinkedList = this.GenerateWizardSteps();

			WizardStep currentStep = wizardStepLinkedList.CurrentStep;
			WizardStep nextStep = wizardStepLinkedList.NextStep;

			FakeWizardControllerWithNoActions wizardController = new FakeWizardControllerWithNoActions();
			wizardController.ModelState.SetModelValue( "ExistingModelState", new ValueProviderResult( "ExistingValue", "ExistingValue", CultureInfo.CurrentUICulture ) );
			wizardController.WizardSteps = wizardStepLinkedList;

			NextWizardButtonCommand buttonCommand = new NextWizardButtonCommand();
			buttonCommand.Execute( wizardController );

			Assert.AreEqual( nextStep.Values.Count, wizardController.ModelState.Count );
			Assert.AreSame( nextStep, wizardStepLinkedList.CurrentStep );
		}

		[TestMethod]
		public void WithModelStateErrorExecutesCorrectly()
		{
			WizardStepLinkedList wizardStepLinkedList = this.GenerateWizardSteps();

			WizardStep currentStep = wizardStepLinkedList.CurrentStep;

			FakeWizardControllerWithNoActions wizardController = new FakeWizardControllerWithNoActions();
			wizardController.ModelState.AddModelError( "ModelStateError", "ErrorMessage" );
			wizardController.WizardSteps = wizardStepLinkedList;

			NextWizardButtonCommand buttonCommand = new NextWizardButtonCommand();
			buttonCommand.Execute( wizardController );

			Assert.AreEqual( 1, wizardController.ModelState.Count );
			Assert.AreSame( currentStep, wizardStepLinkedList.CurrentStep );
		}



		private WizardStepLinkedList GenerateWizardSteps()
		{
			WizardStepValueCollection stepOneValues = new WizardStepValueCollection();
			stepOneValues.Add( "StepOneName1", "StepOneValue1" );
			stepOneValues.Add( "StepOneName1", "StepOneValue2" );

			WizardStepValueCollection stepTwoValues = new WizardStepValueCollection();
			stepTwoValues.Add( "StepTwoName1", "StepTwoValue1" );
			stepTwoValues.Add( "StepTwoName1", "StepTwoValue2" );

			WizardStepValueCollection stepThreeValues = new WizardStepValueCollection();
			stepThreeValues.Add( "StepThreeName1", "StepThreeValue1" );
			stepThreeValues.Add( "StepThreeName1", "StepThreeValue2" );

			WizardStep[] wizardSteps = new WizardStep[]
			{
				new WizardStep( "StepOne", null, null, null, null, null, stepOneValues ),
				new WizardStep( "StepTwo", null, null, null, null, null, stepTwoValues ),
				new WizardStep( "StepThree", null, null, null, null, null, stepThreeValues )
			};

			return new WizardStepLinkedList( wizardSteps, wizardSteps[ 1 ] );
		}
	}
}
