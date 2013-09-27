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
			WizardStepValueCollection values = new WizardStepValueCollection();

			WizardStepState wizardStepState = new WizardStepState( actionName, values );

			Assert.AreEqual( actionName, wizardStepState.ActionName );
			Assert.AreSame( values, wizardStepState.Values );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentException ) )]
		public void NullActionNameThrowsArgumentException()
		{
			string actionName = null;
			WizardStepValueCollection values = new WizardStepValueCollection();

			new WizardStepState( actionName, values );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentException ) )]
		public void EmptyActionNameThrowsArgumentNullException()
		{
			string actionName = string.Empty;
			WizardStepValueCollection values = new WizardStepValueCollection();

			new WizardStepState( actionName, values );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentException ) )]
		public void WhitespaceActionNameThrowsArgumentNullException()
		{
			string actionName = " ";
			WizardStepValueCollection values = new WizardStepValueCollection();

			new WizardStepState( actionName, values );
		}
	}
}
