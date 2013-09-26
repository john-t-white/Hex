using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;
using System.Collections.Generic;

namespace Hex.TestProject.Wizard.WizardStepLinkedListTests
{
	[TestClass]
	public class WizardStepLinkedList_ctor
	{
		[TestMethod]
		public void WithWizardStepsCreatesCorrectly()
		{
			WizardStep[] wizardSteps = new WizardStep[]
			{
				new WizardStep( "ActionName1" ),
				new WizardStep( "ActionName2" )
			};

			WizardStepLinkedList wizardStepLinkedList = new WizardStepLinkedList( wizardSteps );

			CollectionAssert.AreEquivalent( wizardSteps, wizardStepLinkedList.ToArray() );
			Assert.AreSame( wizardSteps[ 0 ], wizardStepLinkedList.CurrentStep );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentNullException ) )]
		public void WithNullWizardStepsThrowsArgumentNullException()
		{
			WizardStep[] wizardSteps = null;

			new WizardStepLinkedList( wizardSteps );
		}

		[TestMethod]
		public void WithWizardStepsAndCurrentStepCreatesCorrectly()
		{
			WizardStep[] wizardSteps = new WizardStep[]
			{
				new WizardStep( "ActionName1" ),
				new WizardStep( "ActionName2" )
			};

			WizardStep currentWizardStep = wizardSteps[ 1 ];

			WizardStepLinkedList wizardStepLinkedList = new WizardStepLinkedList( wizardSteps, currentWizardStep );

			CollectionAssert.AreEquivalent( wizardSteps, wizardStepLinkedList.ToArray() );
			Assert.AreSame( currentWizardStep, wizardStepLinkedList.CurrentStep );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentNullException ) )]
		public void WithNullWizardStepsAndCurrentStepThrowsArgumentNullException()
		{
			WizardStep[] wizardSteps = null;
			WizardStep currentWizardStep = new WizardStep( "ActionName1" );

			new WizardStepLinkedList( wizardSteps, currentWizardStep );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentNullException ) )]
		public void WithWizardStepsAndNullCurrentStepThrowsArgumentNullException()
		{
			WizardStep[] wizardSteps = new WizardStep[]
			{
				new WizardStep( "ActionName1" ),
				new WizardStep( "ActionName2" )
			};

			WizardStep currentWizardStep = null;

			new WizardStepLinkedList( wizardSteps, currentWizardStep );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentException ) )]
		public void WithWizardStepsAndCurrentStepNotInStepsThrowsArgumentException()
		{
			WizardStep[] wizardSteps = new WizardStep[]
			{
				new WizardStep( "ActionName1" ),
				new WizardStep( "ActionName2" )
			};

			WizardStep currentWizardStep = new WizardStep( "ActionName1" ); ;

			new WizardStepLinkedList( wizardSteps, currentWizardStep );
		}
	}
}
