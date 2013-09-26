using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;

namespace Hex.TestProject.Wizard.WizardStepLinkedListTests
{
	[TestClass]
	public class WizardStepLinkedList_MoveToPreviousStep
	{
		[TestMethod]
		public void SetsCurrentStepAndReturnsCorrectly()
		{
			WizardStep[] wizardSteps = new WizardStep[]
			{
				new WizardStep( "ActionName1" ),
				new WizardStep( "ActionName2" ),
				new WizardStep( "ActionName3" )
			};

			WizardStepLinkedList wizardStepLinkedList = new WizardStepLinkedList( wizardSteps, wizardSteps[ 2 ] );
			WizardStep returnedWizardStep = wizardStepLinkedList.MoveToPreviousStep();

			Assert.AreSame( returnedWizardStep, wizardSteps[ 1 ] );
			Assert.AreSame( wizardSteps[ 1 ], wizardStepLinkedList.CurrentStep );
		}

		[TestMethod]
		[ExpectedException( typeof( InvalidOperationException ) )]
		public void WithNoNextStepThrowsInvalidOperationException()
		{
			WizardStep[] wizardSteps = new WizardStep[]
			{
				new WizardStep( "ActionName1" ),
				new WizardStep( "ActionName2" ),
				new WizardStep( "ActionName3" )
			};

			WizardStepLinkedList wizardStepLinkedList = new WizardStepLinkedList( wizardSteps );
			wizardStepLinkedList.MoveToPreviousStep();
		}
	}
}
