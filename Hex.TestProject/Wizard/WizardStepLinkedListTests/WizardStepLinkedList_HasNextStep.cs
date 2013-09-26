using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;

namespace Hex.TestProject.Wizard.WizardStepLinkedListTests
{
	[TestClass]
	public class WizardStepLinkedList_HasNextStep
	{
		[TestMethod]
		public void WithNextStepReturnsCorrectly()
		{
			WizardStep[] wizardSteps = new WizardStep[]
			{
				new WizardStep( "ActionName1" ),
				new WizardStep( "ActionName2" ),
				new WizardStep( "ActionName3" )
			};

			WizardStepLinkedList wizardStepLinkedList = new WizardStepLinkedList( wizardSteps );
			Assert.IsTrue( wizardStepLinkedList.HasNextStep() );
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
			Assert.IsFalse( wizardStepLinkedList.HasNextStep() );
		}
	}
}
