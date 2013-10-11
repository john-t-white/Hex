using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;
using System.Web.Mvc;
using System.Web.Routing;
using Rhino.Mocks;
using System.Web;
using System.Collections;

namespace Hex.TestProject.Wizard.TempDataWizardStateProviderTests
{
	[TestClass]
	public class TempDataWizardStateProvider_Save
	{
		[TestMethod]
		public void CreatesNewWizardStateTokenAndSavesWizardStateToTempDataCorrectly()
		{
			WizardState wizardState = this.GenerateWizardState();
			ControllerContext controllerContext = this.GenerateControllerContext();
			WizardController wizardController = ( WizardController )controllerContext.Controller;

			controllerContext.HttpContext.Items.Expect( x => x[ "__wizardStateToken" ] )
				.Return( null );

			TempDataWizardStateProvider wizardStateProvider = new TempDataWizardStateProvider();
			string wizardStateToken = wizardStateProvider.Save( controllerContext, wizardState );

			controllerContext.HttpContext.Items.VerifyAllExpectations();

			Assert.IsFalse( string.IsNullOrWhiteSpace( wizardStateToken ) );

			string expectedTempDataKey = string.Format( "__wizardStateToken-{0}", wizardStateToken );
			Assert.IsTrue( wizardController.TempData.ContainsKey( expectedTempDataKey ) );
			Assert.AreSame( wizardState, wizardController.TempData[ expectedTempDataKey ] );
		}

		[TestMethod]
		public void WithExistingWizardStateTokenSavesWizardStateToTempDataCorrectly()
		{
			string existingWizardStateToken = "ExistingWizardStateToken";

			WizardState wizardState = this.GenerateWizardState();
			ControllerContext controllerContext = this.GenerateControllerContext();
			WizardController wizardController = ( WizardController )controllerContext.Controller;

			controllerContext.HttpContext.Items.Expect( x => x[ "__wizardStateToken" ] )
				.Return( existingWizardStateToken );

			TempDataWizardStateProvider wizardStateProvider = new TempDataWizardStateProvider();
			string wizardStateToken = wizardStateProvider.Save( controllerContext, wizardState );

			controllerContext.HttpContext.Items.VerifyAllExpectations();

			Assert.AreEqual( existingWizardStateToken, wizardStateToken );

			string expectedTempDataKey = string.Format( "__wizardStateToken-{0}", existingWizardStateToken );
			Assert.IsTrue( wizardController.TempData.ContainsKey( expectedTempDataKey ) );
			Assert.AreSame( wizardState, wizardController.TempData[ expectedTempDataKey ] );
		}



		private WizardState GenerateWizardState()
		{
			WizardStepState[] wizardSteps = new WizardStepState[]
			{
				new WizardStepState( "ActionName", null )
			};

			WizardState wizardState = new WizardState( wizardSteps[ 0 ].ActionName, wizardSteps );

			return wizardState;
		}

		private ControllerContext GenerateControllerContext()
		{
			IDictionary httpContextItems = MockRepository.GenerateMock<IDictionary>();
			HttpContextBase httpContext = MockRepository.GenerateMock<HttpContextBase>();
			httpContext.Stub( x => x.Items )
				.Return( httpContextItems );

			RequestContext requestContext = new RequestContext( httpContext, new RouteData() );
			FakeWizardControllerWithNoActions wizardController = new FakeWizardControllerWithNoActions();
			ControllerContext controllerContext = new ControllerContext( requestContext, wizardController );
			wizardController.ControllerContext = controllerContext;

			ITempDataProvider tempDataProvider = MockRepository.GenerateMock<ITempDataProvider>();
			wizardController.TempDataProvider = tempDataProvider;

			return controllerContext;
		}
	}
}
