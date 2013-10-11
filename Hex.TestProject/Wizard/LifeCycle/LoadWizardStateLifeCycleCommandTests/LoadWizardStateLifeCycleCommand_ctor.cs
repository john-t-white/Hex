using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard.LifeCycle;

namespace Hex.TestProject.Wizard.LifeCycle.LoadWizardStateLifeCycleCommandTests
{
	[TestClass]
	public class LoadWizardStateLifeCycleCommand_ctor
	{
		[TestMethod]
		public void CreatesCorrectly()
		{
			string wizardStateToken = "WizardStateToken";

			LoadWizardStateLifeCycleCommand lifeCycleCommand = new LoadWizardStateLifeCycleCommand( wizardStateToken );

			Assert.AreEqual( wizardStateToken, lifeCycleCommand.WizardStateToken );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentException ) )]
		public void WithNullWizardStateTokenThrowsArgumentException()
		{
			string wizardStateToken = null;

			new LoadWizardStateLifeCycleCommand( wizardStateToken );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentException ) )]
		public void WithEmptyWizardStateTokenThrowsArgumentException()
		{
			string wizardStateToken = string.Empty;

			new LoadWizardStateLifeCycleCommand( wizardStateToken );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentException ) )]
		public void WithWhitespaceWizardStateTokenThrowsArgumentException()
		{
			string wizardStateToken = " ";

			new LoadWizardStateLifeCycleCommand( wizardStateToken );
		}
	}
}
