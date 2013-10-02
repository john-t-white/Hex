using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;
using System.Web.Mvc;

namespace Hex.TestProject.Wizard.WizardStepTests
{
	[TestClass]
	public class WizardStep_ctor
	{
		[TestMethod]
		public void WithWizardActionReturnsCorrectly()
		{
			WizardActionDescriptor wizardAction = this.GetWizardAction();

			WizardStep wizardStep = new WizardStep( wizardAction );

			Assert.AreEqual( "StepOne", wizardStep.ActionName );
			Assert.AreEqual( "Name", wizardStep.Name );
			Assert.AreEqual( "Description", wizardStep.Description );
			Assert.AreEqual( "Prompt", wizardStep.Prompt );
			Assert.AreEqual( "GroupName", wizardStep.GroupName );
			Assert.AreEqual( "ShortName", wizardStep.ShortName );
			Assert.IsNull( wizardStep.Values );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentNullException ) )]
		public void WithNullWizardActionThrowsArgumentNullException()
		{
			WizardActionDescriptor wizardAction = null;

			new WizardStep( wizardAction );
		}

		[TestMethod]
		public void WithWizardActionAndValuesReturnsCorrectly()
		{
			WizardActionDescriptor wizardAction = this.GetWizardAction();
			WizardStepValueCollection values = new WizardStepValueCollection();

			WizardStep wizardStep = new WizardStep( wizardAction, values );

			Assert.AreEqual( "StepOne", wizardStep.ActionName );
			Assert.AreEqual( "Name", wizardStep.Name );
			Assert.AreEqual( "Description", wizardStep.Description );
			Assert.AreEqual( "Prompt", wizardStep.Prompt );
			Assert.AreEqual( "GroupName", wizardStep.GroupName );
			Assert.AreEqual( "ShortName", wizardStep.ShortName );
			Assert.AreSame( values, wizardStep.Values );
		}

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



		private WizardActionDescriptor GetWizardAction()
		{
			ReflectedControllerDescriptor controllerDescriptor = new ReflectedControllerDescriptor( typeof( FakeWizardController ) );
			return new WizardActionDescriptor( controllerDescriptor.GetCanonicalActions().Single() );
		}
	}
}
