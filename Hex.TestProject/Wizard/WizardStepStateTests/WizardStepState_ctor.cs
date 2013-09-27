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

			WizardStepState wizardStepState = new WizardStepState( actionName );

			Assert.AreEqual( actionName, wizardStepState.ActionName );
		}
	}
}
