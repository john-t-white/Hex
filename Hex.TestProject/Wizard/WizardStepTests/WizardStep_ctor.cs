using System;
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
			Assert.IsNull( wizardStep.Prompt );
			Assert.IsNull( wizardStep.GroupName );
			Assert.IsNull( wizardStep.ShortName );
			Assert.IsNull( wizardStep.Values );
		}

		[TestMethod]
		public void WithActionNameNameAndDescriptionCreatesCorrectly()
		{
			string actionName = "ActionName";
			string name = "Name";
			string description = "Description";
			string prompt = "Prompt";
			string groupName = "GroupName";
			string shortName = "ShortName";

			WizardStep wizardStep = new WizardStep( actionName, name, description, prompt, groupName, shortName );

			Assert.AreEqual( actionName, wizardStep.ActionName );
			Assert.AreEqual( name, wizardStep.Name );
			Assert.AreEqual( description, wizardStep.Description );
			Assert.AreEqual( prompt, wizardStep.Prompt );
			Assert.AreEqual( groupName, wizardStep.GroupName );
			Assert.AreEqual( shortName, wizardStep.ShortName );
			Assert.IsNull( wizardStep.Values );
		}

		[TestMethod]
		public void WithActionNameNameDescriptionAndValuesCreatesCorrectly()
		{
			string actionName = "ActionName";
			string name = "Name";
			string description = "Description";
			string prompt = "Prompt";
			string groupName = "GroupName";
			string shortName = "ShortName";
			WizardStepValueCollection values = new WizardStepValueCollection();

			WizardStep wizardStep = new WizardStep( actionName, name, description, prompt, groupName, shortName, values );

			Assert.AreEqual( actionName, wizardStep.ActionName );
			Assert.AreEqual( name, wizardStep.Name );
			Assert.AreEqual( description, wizardStep.Description );
			Assert.AreEqual( prompt, wizardStep.Prompt );
			Assert.AreEqual( groupName, wizardStep.GroupName );
			Assert.AreEqual( shortName, wizardStep.ShortName );
			Assert.AreSame( values, wizardStep.Values );
		}

		[TestMethod]
		public void WithActionNameNullNameNullDescriptionNullPromptNullGroupNameAndNullShortNameCreatesCorrectly()
		{
			string actionName = "ActionName";
			string name = null;
			string description = null;
			string prompt = null;
			string groupName = null;
			string shortName = null;

			WizardStep wizardStep = new WizardStep( actionName, name, description, prompt, groupName, shortName );

			Assert.AreEqual( actionName, wizardStep.ActionName );
			Assert.AreEqual( actionName, wizardStep.Name );
			Assert.IsNull( wizardStep.Description );
			Assert.IsNull( wizardStep.Prompt );
			Assert.IsNull( wizardStep.GroupName );
			Assert.IsNull( wizardStep.ShortName );
			Assert.IsNull( wizardStep.Values );
		}

		[TestMethod]
		public void WithActionNameNullNameNullDescriptionNullPromptNullGroupNameNullShortNameAndNullValuesCreatesCorrectly()
		{
			string actionName = "ActionName";
			string name = null;
			string description = null;
			string prompt = null;
			string groupName = null;
			string shortName = null;
			WizardStepValueCollection values = null;

			WizardStep wizardStep = new WizardStep( actionName, name, description, prompt, groupName, shortName, values );

			Assert.AreEqual( actionName, wizardStep.ActionName );
			Assert.AreEqual( actionName, wizardStep.Name );
			Assert.IsNull( wizardStep.Description );
			Assert.IsNull( wizardStep.Prompt );
			Assert.IsNull( wizardStep.GroupName );
			Assert.IsNull( wizardStep.ShortName );
			Assert.IsNull( wizardStep.Values );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentException ) )]
		public void WithNullActionNameThrowsArgumentException()
		{
			string actionName = null;

			new WizardStep( actionName, "Name", "Description", "Prompt", "GroupName", "ShortName" );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentException ) )]
		public void WithEmptyActionNameThrowsArgumentException()
		{
			string actionName = string.Empty;

			new WizardStep( actionName, "Name", "Description", "Prompt", "GroupName", "ShortName" );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentException ) )]
		public void WithWhitespaceActionNameThrowsArgumentException()
		{
			string actionName = " ";

			new WizardStep( actionName, "Name", "Description", "Prompt", "GroupName", "ShortName" );
		}
	}
}
