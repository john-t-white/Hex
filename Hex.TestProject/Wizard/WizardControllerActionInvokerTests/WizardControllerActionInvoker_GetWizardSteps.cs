using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Web.Routing;
using Hex.Wizard;

namespace Hex.TestProject.Wizard.WizardControllerActionInvokerTests
{
	[TestClass]
	public class WizardControllerActionInvoker_GetWizardActions
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			RequestContext requestContext = new RequestContext();
			FakeControllerWithNoWizardStepAttributes controller = new FakeControllerWithNoWizardStepAttributes();
			ControllerContext controllerContext = new ControllerContext( requestContext, controller );

			WizardControllerActionInvoker wizardControllerActionInvoker = new WizardControllerActionInvoker();

			ActionDescriptor[] wizardActions = wizardControllerActionInvoker.GetWizardActions( controllerContext );

			Assert.IsNotNull( wizardActions );
			Assert.AreEqual( 3, wizardActions.Length );

			ActionDescriptor wizardStepOne = wizardActions[ 0 ];
			Assert.AreEqual( "StepOne", wizardStepOne.ActionName );

			ActionDescriptor wizardStepTwo = wizardActions[ 1 ];
			Assert.AreEqual( "StepTwo", wizardStepTwo.ActionName );;

			ActionDescriptor wizardStepThree = wizardActions[ 2 ];
			Assert.AreEqual( "StepThree", wizardStepThree.ActionName );
		}

		[TestMethod]
		public void WithDifferentOrderReturnsCorrectly()
		{
			RequestContext requestContext = new RequestContext();
			FakeControllerWithDifferentOrder controller = new FakeControllerWithDifferentOrder();
			ControllerContext controllerContext = new ControllerContext( requestContext, controller );

			WizardControllerActionInvoker wizardControllerActionInvoker = new WizardControllerActionInvoker();

			ActionDescriptor[] wizardActions = wizardControllerActionInvoker.GetWizardActions( controllerContext );

			Assert.IsNotNull( wizardActions );
			Assert.AreEqual( 3, wizardActions.Length );

			ActionDescriptor wizardStepThree = wizardActions[ 0 ];
			Assert.AreEqual( "StepThree", wizardStepThree.ActionName );

			ActionDescriptor wizardStepTwo = wizardActions[ 1 ];
			Assert.AreEqual( "StepTwo", wizardStepTwo.ActionName );

			ActionDescriptor wizardStepOne = wizardActions[ 2 ];
			Assert.AreEqual( "StepOne", wizardStepOne.ActionName );
		}
	}
}
