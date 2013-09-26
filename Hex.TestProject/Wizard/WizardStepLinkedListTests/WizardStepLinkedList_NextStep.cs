using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;

namespace Hex.TestProject.Wizard.WizardStepLinkedListTests
{
	[TestClass]
	public class WizardStepLinkedList_NextStep
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			WizardStep[] wizardSteps = new WizardStep[]
			{
				new WizardStep( "ActionName1" ),
				new WizardStep( "ActionName2" ),
				new WizardStep( "ActionName3" )
			};

			WizardStepLinkedList wizardStepLinkedList = new WizardStepLinkedList( wizardSteps );
			WizardStep nextStep = wizardStepLinkedList.NextStep;

			Assert.AreSame( nextStep, wizardSteps[ 1 ] );
		}

		[TestMethod]
		public void WithNoNextStepReturnsCorrectly()
		{
			WizardStep[] wizardSteps = new WizardStep[]
			{
				new WizardStep( "ActionName1" ),
				new WizardStep( "ActionName2" ),
				new WizardStep( "ActionName3" )
			};

			WizardStepLinkedList wizardStepLinkedList = new WizardStepLinkedList( wizardSteps, wizardSteps[ 2 ] );
			WizardStep nextStep = wizardStepLinkedList.NextStep;

			Assert.IsNull( nextStep );
		}
	}
}
