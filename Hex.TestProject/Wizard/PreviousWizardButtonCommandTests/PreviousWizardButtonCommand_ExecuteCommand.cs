using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;
using System.Web.Mvc;
using System.Globalization;

namespace Hex.TestProject.Wizard.PreviousWizardButtonCommandTests
{
	[TestClass]
	public class PreviousWizardButtonCommand_ExecuteCommand
	{
		[TestMethod]
		public void ExecutesCorrectly()
		{
			WizardStepLinkedList wizardStepLinkedList = this.GenerateWizardSteps();

			WizardStep currentStep = wizardStepLinkedList.CurrentStep;
			WizardStep previousStep = wizardStepLinkedList.PreviousStep;

			FakeWizardController wizardController = new FakeWizardController();
			wizardController.ModelState.SetModelValue( "ExistingModelState", new ValueProviderResult( "ExistingValue", "ExistingValue", CultureInfo.CurrentUICulture ) );
			wizardController.WizardSteps = wizardStepLinkedList;

			PreviousWizardButtonCommand buttonCommand = new PreviousWizardButtonCommand();
			buttonCommand.ExecuteCommand( wizardController );

			Assert.AreEqual( previousStep.Values.Count, wizardController.ModelState.Count );
			Assert.AreSame( previousStep, wizardStepLinkedList.CurrentStep );
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
				new WizardStep( "StepOne", null, null, stepOneValues ),
				new WizardStep( "StepTwo", null, null, stepTwoValues ),
				new WizardStep( "StepThree", null, null, stepThreeValues )
			};

			return new WizardStepLinkedList( wizardSteps, wizardSteps[ 1 ] );
		}
	}
}
