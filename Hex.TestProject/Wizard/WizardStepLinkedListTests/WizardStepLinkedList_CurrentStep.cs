using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;

namespace Hex.TestProject.Wizard.WizardStepLinkedListTests
{
	[TestClass]
	public class WizardStepLinkedList_CurrentStep
	{
		[TestMethod]
		public void SetsCorrectly()
		{
			WizardStep[] wizardSteps = new WizardStep[]
			{
				new WizardStep( "ActionName1" ),
				new WizardStep( "ActionName2" ),
				new WizardStep( "ActionName3" )
			};

			WizardStepLinkedList wizardStepLinkedList = new WizardStepLinkedList( wizardSteps );
			wizardStepLinkedList.CurrentStep = wizardSteps[ 1 ];

			Assert.AreSame( wizardSteps[ 1 ], wizardStepLinkedList.CurrentStep );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentNullException ) )]
		public void WithNullThrowsArgumentNullException()
		{
			WizardStep[] wizardSteps = new WizardStep[]
			{
				new WizardStep( "ActionName1" ),
				new WizardStep( "ActionName2" ),
				new WizardStep( "ActionName3" )
			};

			WizardStepLinkedList wizardStepLinkedList = new WizardStepLinkedList( wizardSteps );
			wizardStepLinkedList.CurrentStep = null;
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentException ) )]
		public void WithWizardStepNotInListThrowsArgumentException()
		{
			WizardStep[] wizardSteps = new WizardStep[]
			{
				new WizardStep( "ActionName1" ),
				new WizardStep( "ActionName2" ),
				new WizardStep( "ActionName3" )
			};

			WizardStepLinkedList wizardStepLinkedList = new WizardStepLinkedList( wizardSteps );
			wizardStepLinkedList.CurrentStep = new WizardStep( "ActionName" );
		}
	}
}
