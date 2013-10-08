using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;
using System.Web.Mvc;
using System.Collections;
using System.Web;
using Rhino.Mocks;
using System.Web.Routing;
using System.Collections.Generic;

namespace Hex.TestProject.Wizard.TempDataWizardStateProviderTests
{
	[TestClass]
	public class TempDataWizardStateProvider_Load
	{
		[TestMethod]
		public void WithWizardStateFoundReturnsCorrectly()
		{
			string wizardStateToken = "WizardStateToken";

			WizardState wizardState = this.GenerateWizardState();
			ControllerContext controllerContext = this.GenerateControllerContext();
			WizardController wizardController = ( WizardController )controllerContext.Controller;

			string expectedTempDataKey = string.Format( "__wizardStateToken-{0}", wizardStateToken );

			Dictionary<string, object> tempData = new Dictionary<string,object>();
			tempData[ expectedTempDataKey ] = wizardState;

			wizardController.TempDataProvider.Expect( x => x.LoadTempData( controllerContext ) )
				.Return( tempData );

			wizardController.TempDataProvider.Expect( x => x.SaveTempData( controllerContext, wizardController.TempData ) )
				.IgnoreArguments();

			TempDataWizardStateProvider wizardStateProvider = new TempDataWizardStateProvider();
			WizardState result = wizardStateProvider.Load( controllerContext, wizardStateToken );

			wizardController.TempDataProvider.VerifyAllExpectations();

			Assert.AreSame( wizardState, result );
		}

		[TestMethod]
		public void WithWizardStateNotFoundReturnsCorrectly()
		{
			string wizardStateToken = "WizardStateToken";

			ControllerContext controllerContext = this.GenerateControllerContext();
			WizardController wizardController = ( WizardController )controllerContext.Controller;

			string expectedTempDataKey = string.Format( "__wizardStateToken-{0}", wizardStateToken );

			Dictionary<string, object> tempData = new Dictionary<string, object>();

			wizardController.TempDataProvider.Expect( x => x.LoadTempData( controllerContext ) )
				.Return( tempData );

			wizardController.TempDataProvider.Expect( x => x.SaveTempData( controllerContext, wizardController.TempData ) )
				.IgnoreArguments();

			TempDataWizardStateProvider wizardStateProvider = new TempDataWizardStateProvider();
			WizardState result = wizardStateProvider.Load( controllerContext, wizardStateToken );

			wizardController.TempDataProvider.VerifyAllExpectations();

			Assert.IsNull( result );
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
			FakeWizardController wizardController = new FakeWizardController();
			ControllerContext controllerContext = new ControllerContext( requestContext, wizardController );
			wizardController.ControllerContext = controllerContext;

			ITempDataProvider tempDataProvider = MockRepository.GenerateMock<ITempDataProvider>();
			wizardController.TempDataProvider = tempDataProvider;

			return controllerContext;
		}
	}
}
