using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;

namespace Hex.TestProject.Wizard.WizardStateTests
{
	[TestClass]
	public class WizardState_ctor
	{
		[TestMethod]
		public void CreatesCorrectly()
		{
			string currentStepActionName = "CurrentStepActionName";
			WizardStepState[] steps = new WizardStepState[] { new WizardStepState( currentStepActionName, null ) };

			WizardState wizardState = new WizardState( currentStepActionName, steps );

			Assert.AreEqual( currentStepActionName, wizardState.CurrentStepActionName );
			Assert.AreSame( steps, wizardState.Steps );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentException ) )]
		public void WithNullCurrentStepActionNameThrowsArgumentException()
		{
			string currentStepActionName = null;
			WizardStepState[] steps = new WizardStepState[] { };

			new WizardState( currentStepActionName, steps );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentException ) )]
		public void WithEmptyCurrentStepActionNameThrowsArgumentException()
		{
			string currentStepActionName = string.Empty;
			WizardStepState[] steps = new WizardStepState[] { };

			new WizardState( currentStepActionName, steps );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentException ) )]
		public void WithWhitespaceCurrentStepActionNameThrowsArgumentException()
		{
			string currentStepActionName = " ";
			WizardStepState[] steps = new WizardStepState[] { };

			new WizardState( currentStepActionName, steps );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentException ) )]
		public void WithCurrentStepActionNameDoesNotExistInStepsThrowsArgumentException()
		{
			string currentStepActionName = "CurrentStepActionName";
			WizardStepState[] steps = new WizardStepState[] { new WizardStepState( "DifferentActionName", null ) };

			WizardState wizardState = new WizardState( currentStepActionName, steps );

			Assert.AreEqual( currentStepActionName, wizardState.CurrentStepActionName );
			Assert.AreSame( steps, wizardState.Steps );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentNullException ) )]
		public void WithNullStepsThrowsArgumentNullException()
		{
			string currentStepActionName = "CurrentStepActionName";
			WizardStepState[] steps = null;

			new WizardState( currentStepActionName, steps );
		}
	}
}
