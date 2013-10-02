using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Wizard;
using System.Reflection;
using System.Collections.Generic;
using System.Web.Routing;

namespace Hex.TestProject.Wizard.WizardStepInitializerTests
{
	[TestClass]
	public class WizardStepInitializer_InitializeWizardSteps
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			RequestContext requestContext = new RequestContext();

			WizardActionDescriptor[] wizardActions = this.GetWizardActions( typeof( FakeWizardController ) );

			WizardStepInitializer wizardStepInitializer = new WizardStepInitializer();
			WizardStep[] wizardSteps = wizardStepInitializer.InitializeWizardSteps( requestContext, wizardActions ).ToArray();

			Assert.AreEqual( 3, wizardSteps.Length );

			WizardStep wizardStepOne = wizardSteps[ 0 ];
			Assert.AreEqual( "StepOne", wizardStepOne.ActionName );
			Assert.AreEqual( "StepOne", wizardStepOne.Name );
			Assert.IsNull( wizardStepOne.Description );

			WizardStep wizardStepTwo = wizardSteps[ 1 ];
			Assert.AreEqual( "StepTwo", wizardStepTwo.ActionName );
			Assert.AreEqual( "StepTwo", wizardStepTwo.Name );
			Assert.IsNull( wizardStepTwo.Description );

			WizardStep wizardStepThree = wizardSteps[ 2 ];
			Assert.AreEqual( "StepThree", wizardStepThree.ActionName );
			Assert.AreEqual( "StepThree", wizardStepThree.Name );
			Assert.IsNull( wizardStepThree.Description );
		}

		[TestMethod]
		public void WithDisplayAttributeReturnsCorrectly()
		{
			RequestContext requestContext = new RequestContext();

			WizardActionDescriptor[] wizardActions = this.GetWizardActions( typeof( FakeWizardControllerWithDisplayAttributes ) );

			WizardStepInitializer wizardStepInitializer = new WizardStepInitializer();
			WizardStep[] wizardSteps = wizardStepInitializer.InitializeWizardSteps( requestContext, wizardActions ).ToArray();

			Assert.AreEqual( 3, wizardSteps.Length );

			WizardStep wizardStepOne = wizardSteps[ 0 ];
			Assert.AreEqual( "StepOne", wizardStepOne.ActionName );
			Assert.AreEqual( "StepOneName", wizardStepOne.Name );
			Assert.AreEqual( "StepOneDescription", wizardStepOne.Description );

			WizardStep wizardStepTwo = wizardSteps[ 1 ];
			Assert.AreEqual( "StepTwo", wizardStepTwo.ActionName );
			Assert.AreEqual( "StepTwoName", wizardStepTwo.Name );
			Assert.AreEqual( "StepTwoDescription", wizardStepTwo.Description );

			WizardStep wizardStepThree = wizardSteps[ 2 ];
			Assert.AreEqual( "StepThree", wizardStepThree.ActionName );
			Assert.AreEqual( "StepThreeName", wizardStepThree.Name );
			Assert.AreEqual( "StepThreeDescription", wizardStepThree.Description );
		}

		[TestMethod]
		public void WithDifferentOrderReturnsCorrectly()
		{
			RequestContext requestContext = new RequestContext();

			WizardActionDescriptor[] wizardActions = this.GetWizardActions( typeof( FakeWizardControllerWithDifferentOrder ) );

			WizardStepInitializer wizardStepInitializer = new WizardStepInitializer();
			WizardStep[] wizardSteps = wizardStepInitializer.InitializeWizardSteps( requestContext, wizardActions ).ToArray();

			Assert.AreEqual( 3, wizardSteps.Length );

			WizardStep wizardStepThree = wizardSteps[ 0 ];
			Assert.AreEqual( "StepThree", wizardStepThree.ActionName );

			WizardStep wizardStepTwo = wizardSteps[ 1 ];
			Assert.AreEqual( "StepTwo", wizardStepTwo.ActionName );

			WizardStep wizardStepOne = wizardSteps[ 2 ];
			Assert.AreEqual( "StepOne", wizardStepOne.ActionName );
		}



		private WizardActionDescriptor[] GetWizardActions( Type wizardControllerType )
		{
			ReflectedControllerDescriptor controllerDescriptor = new ReflectedControllerDescriptor( wizardControllerType );
			return ( from ActionDescriptor currentActionDescriptor in controllerDescriptor.GetCanonicalActions()
					 select new WizardActionDescriptor( currentActionDescriptor ) ).ToArray();
		}
	}
}
