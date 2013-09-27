﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;

namespace Hex.TestProject.Wizard.WizardStepTests
{
	[TestClass]
	public class WizardStep_ctor
	{
		[TestMethod]
		public void WithActionNameCreatesCorrectly()
		{
			string actionName = "ActionName";

			WizardStep wizardStep = new WizardStep( actionName );

			Assert.AreEqual( actionName, wizardStep.ActionName );
			Assert.AreEqual( actionName, wizardStep.Name );
			Assert.IsNull( wizardStep.Description );
		}

		[TestMethod]
		public void WithActionNameNameAndDescriptionCreatesCorrectly()
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
		public void WithActionNameNullNameAndNullDescriptionCreatesCorrectly()
		{
			string actionName = "ActionName";
			string name = null;
			string description = null;

			WizardStep wizardStep = new WizardStep( actionName, name, description );

			Assert.AreEqual( actionName, wizardStep.ActionName );
			Assert.AreEqual( actionName, wizardStep.Name );
			Assert.IsNull( wizardStep.Description );
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
