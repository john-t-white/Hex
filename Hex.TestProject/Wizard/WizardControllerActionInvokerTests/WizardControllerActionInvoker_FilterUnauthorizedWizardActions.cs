using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web;
using Rhino.Mocks;
using Hex.Wizard;
using System.Security.Principal;
using System.Collections.Generic;

namespace Hex.TestProject.Wizard.WizardControllerActionInvokerTests
{
	[TestClass]
	public class WizardControllerActionInvoker_FilterUnauthorizedWizardActions
	{
		[TestMethod]
		public void WithAuthorizeOnOneStepAndNotAuthenticatedReturnsCorrectly()
		{
			ControllerContext controllerContext = this.GenerateControllerContext<FakeWizardControllerWithAuthorizeAttributeOnAction>( false );

			WizardControllerActionInvoker wizardControllerActionInvoker = new WizardControllerActionInvoker();
			WizardActionDescriptor[] wizardActionDescriptors = wizardControllerActionInvoker.GetWizardActions( controllerContext );
			WizardActionDescriptor[] filteredWizardActionDescriptors = wizardControllerActionInvoker.FilterUnauthorizedWizardActions( controllerContext, wizardActionDescriptors );

			Assert.AreEqual( 2, filteredWizardActionDescriptors.Length );

			WizardActionDescriptor wizardStepOne = filteredWizardActionDescriptors[ 0 ];
			Assert.AreEqual( "StepOne", wizardStepOne.ActionName );

			WizardActionDescriptor wizardStepThree = filteredWizardActionDescriptors[ 1 ];
			Assert.AreEqual( "StepThree", wizardStepThree.ActionName );
		}

		[TestMethod]
		public void WithAuthorizeOnOneStepAndAuthenticatedReturnsCorrectly()
		{
			ControllerContext controllerContext = this.GenerateControllerContext<FakeWizardControllerWithAuthorizeAttributeOnAction>( true );

			WizardControllerActionInvoker wizardControllerActionInvoker = new WizardControllerActionInvoker();
			WizardActionDescriptor[] wizardActionDescriptors = wizardControllerActionInvoker.GetWizardActions( controllerContext );
			WizardActionDescriptor[] filteredWizardActionDescriptors = wizardControllerActionInvoker.FilterUnauthorizedWizardActions( controllerContext, wizardActionDescriptors );

			Assert.AreEqual( 3, filteredWizardActionDescriptors.Length );

			WizardActionDescriptor wizardStepOne = filteredWizardActionDescriptors[ 0 ];
			Assert.AreEqual( "StepOne", wizardStepOne.ActionName );

			WizardActionDescriptor wizardStepTwo = filteredWizardActionDescriptors[ 1 ];
			Assert.AreEqual( "StepTwo", wizardStepTwo.ActionName );

			WizardActionDescriptor wizardStepThree = filteredWizardActionDescriptors[ 2 ];
			Assert.AreEqual( "StepThree", wizardStepThree.ActionName );
		}

		[TestMethod]
		public void WithAuthorizeOnControllerAndNotAuthenticatedReturnsCorrectly()
		{
			ControllerContext controllerContext = this.GenerateControllerContext<FakeWizardControllerWithAuthorizeAttributeOnController>( false );

			WizardControllerActionInvoker wizardControllerActionInvoker = new WizardControllerActionInvoker();
			WizardActionDescriptor[] wizardActionDescriptors = wizardControllerActionInvoker.GetWizardActions( controllerContext );
			WizardActionDescriptor[] filteredWizardActionDescriptors = wizardControllerActionInvoker.FilterUnauthorizedWizardActions( controllerContext, wizardActionDescriptors );

			Assert.AreEqual( 0, filteredWizardActionDescriptors.Length );
		}

		[TestMethod]
		public void WithAuthorizeOnControllerAndAuthenticatedReturnsCorrectly()
		{
			ControllerContext controllerContext = this.GenerateControllerContext<FakeWizardControllerWithAuthorizeAttributeOnController>( true );

			WizardControllerActionInvoker wizardControllerActionInvoker = new WizardControllerActionInvoker();
			WizardActionDescriptor[] wizardActionDescriptors = wizardControllerActionInvoker.GetWizardActions( controllerContext );
			WizardActionDescriptor[] filteredWizardActionDescriptors = wizardControllerActionInvoker.FilterUnauthorizedWizardActions( controllerContext, wizardActionDescriptors );

			Assert.AreEqual( 3, filteredWizardActionDescriptors.Length );

			WizardActionDescriptor wizardStepOne = filteredWizardActionDescriptors[ 0 ];
			Assert.AreEqual( "StepOne", wizardStepOne.ActionName );

			WizardActionDescriptor wizardStepTwo = filteredWizardActionDescriptors[ 1 ];
			Assert.AreEqual( "StepTwo", wizardStepTwo.ActionName );

			WizardActionDescriptor wizardStepThree = filteredWizardActionDescriptors[ 2 ];
			Assert.AreEqual( "StepThree", wizardStepThree.ActionName );
		}



		private ControllerContext GenerateControllerContext<TWizardController>( bool isUserAuthenticated )
			where TWizardController : WizardController, new()
		{
			IIdentity identity = MockRepository.GenerateMock<IIdentity>();
			identity.Stub( x => x.IsAuthenticated )
				.Return( isUserAuthenticated );

			IPrincipal principal = MockRepository.GenerateMock<IPrincipal>();
			principal.Stub( x => x.Identity )
				.Return( identity );

			HttpCachePolicyBase httpCachePolicy = MockRepository.GenerateMock<HttpCachePolicyBase>();

			HttpResponseBase httpResponse = MockRepository.GenerateMock<HttpResponseBase>();
			httpResponse.Stub( x => x.Cache )
				.Return( httpCachePolicy );

			HttpContextBase httpContext = MockRepository.GenerateMock<HttpContextBase>();
			httpContext.Stub( x => x.User )
				.Return( principal );
			httpContext.Stub( x => x.Items )
				.Return( new Dictionary<string, object>() );
			httpContext.Stub( x => x.Response )
				.Return( httpResponse );

			RequestContext requestContext = new RequestContext( httpContext, new RouteData() );

			WizardController wizardController = new TWizardController();
			ControllerContext controllerContext = new ControllerContext( requestContext, wizardController );
			wizardController.ControllerContext = controllerContext;

			return controllerContext;
		}
	}
}
