using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;

namespace Hex.TestProject.Wizard.WizardStepTests
{
	[TestClass]
	public class WizardStep_ctor
	{
		[TestMethod]
		public void CreatesCorrectly()
		{
			string actionName = "ActionName";
			string name = "Name";
			string description = "Description";

			WizardStep wizardStep = new WizardStep( actionName, name, description );

			Assert.AreEqual( actionName, wizardStep.ActionName );
			Assert.AreEqual( name, wizardStep.Name );
			Assert.AreEqual( description, wizardStep.Description );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentException ) )]
		public void WithNullActionNameThrowsArgumentException()
		{
			string actionName = null;

			new WizardStep( actionName, "Name", "Description" );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentException ) )]
		public void WithEmptyActionNameThrowsArgumentException()
		{
			string actionName = string.Empty;

			new WizardStep( actionName, "Name", "Description" );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentException ) )]
		public void WithWhitespaceActionNameThrowsArgumentException()
		{
			string actionName = " ";

			new WizardStep( actionName, "Name", "Description" );
		}
	}
}
