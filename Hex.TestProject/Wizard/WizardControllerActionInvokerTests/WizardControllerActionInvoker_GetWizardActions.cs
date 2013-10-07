using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Web.Routing;
using Hex.Wizard;
using System.Web;
using System.Net;

namespace Hex.TestProject.Wizard.WizardControllerActionInvokerTests
{
	[TestClass]
	public class WizardControllerActionInvoker_GetWizardActions
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			RequestContext requestContext = new RequestContext();
			FakeWizardController controller = new FakeWizardController();
			ControllerContext controllerContext = new ControllerContext( requestContext, controller );

			WizardControllerActionInvoker wizardControllerActionInvoker = new WizardControllerActionInvoker();

			WizardActionDescriptor[] wizardActions = wizardControllerActionInvoker.GetWizardActions( controllerContext );

			Assert.IsNotNull( wizardActions );
			Assert.AreEqual( 3, wizardActions.Length );

			WizardActionDescriptor wizardStepOne = wizardActions[ 0 ];
			Assert.AreEqual( "StepOne", wizardStepOne.ActionName );

			WizardActionDescriptor wizardStepTwo = wizardActions[ 1 ];
			Assert.AreEqual( "StepTwo", wizardStepTwo.ActionName );

			WizardActionDescriptor wizardStepThree = wizardActions[ 2 ];
			Assert.AreEqual( "StepThree", wizardStepThree.ActionName );
		}

		[TestMethod]
		public void WithNoActionsThrowsHttpException()
		{
			RequestContext requestContext = new RequestContext();
			FakeWizardControllerWithNoActions controller = new FakeWizardControllerWithNoActions();
			ControllerContext controllerContext = new ControllerContext( requestContext, controller );

			WizardControllerActionInvoker wizardControllerActionInvoker = new WizardControllerActionInvoker();

			try
			{
				wizardControllerActionInvoker.GetWizardActions( controllerContext );
				Assert.Fail( "HttpException expected." );
			}
			catch( HttpException ex )
			{
				string expectedMessage = string.Format( "There are no wizard actions found for wizard controller '{0}'.", typeof( FakeWizardControllerWithNoActions ).FullName );
				Assert.AreEqual( expectedMessage, ex.Message );
				Assert.AreEqual( ( int )HttpStatusCode.NotFound, ex.GetHttpCode() );
			}
		}
	}
}
