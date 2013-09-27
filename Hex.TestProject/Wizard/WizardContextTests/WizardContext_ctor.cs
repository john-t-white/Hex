using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Routing;
using Hex.Wizard;

namespace Hex.TestProject.Wizard.WizardContextTests
{
	[TestClass]
	public class WizardContext_ctor
	{
		[TestMethod]
		public void CreatesCorrectly()
		{
			RequestContext requestContext = new RequestContext();
			FakeWizardController wizardController = new FakeWizardController();

			WizardContext wizardContext = new WizardContext( requestContext, wizardController );

			Assert.AreSame( requestContext, wizardContext.RequestContext );
			Assert.AreSame( wizardController, wizardContext.WizardController );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentNullException ) )]
		public void WithNullRequestContextThrowsArgumentNullException()
		{
			RequestContext requestContext = null;
			FakeWizardController wizardController = new FakeWizardController();

			new WizardContext( requestContext, wizardController );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentNullException ) )]
		public void WithNullWizardControllerThrowsArgumentNullException()
		{
			RequestContext requestContext = new RequestContext();
			FakeWizardController wizardController = null;

			new WizardContext( requestContext, wizardController );
		}
	}
}
