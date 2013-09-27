using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;

namespace Hex.TestProject.Wizard.WizardStepStateTests
{
	[TestClass]
	public class WizardStepState_ctor
	{
		[TestMethod]
		public void CreatesCorrectly()
		{
			string actionName = "ActionName";
			WizardStepStateValueCollection values = new WizardStepStateValueCollection();

			WizardStepState wizardStepState = new WizardStepState( actionName, values );

			Assert.AreEqual( actionName, wizardStepState.ActionName );
			Assert.AreSame( values, wizardStepState.Values );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentException ) )]
		public void NullActionNameThrowsArgumentException()
		{
			string actionName = null;
			WizardStepStateValueCollection values = new WizardStepStateValueCollection();

			new WizardStepState( actionName, values );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentException ) )]
		public void EmptyActionNameThrowsArgumentNullException()
		{
			string actionName = string.Empty;
			WizardStepStateValueCollection values = new WizardStepStateValueCollection();

			new WizardStepState( actionName, values );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentException ) )]
		public void WhitespaceActionNameThrowsArgumentNullException()
		{
			string actionName = " ";
			WizardStepStateValueCollection values = new WizardStepStateValueCollection();

			new WizardStepState( actionName, values );
		}
	}
}
