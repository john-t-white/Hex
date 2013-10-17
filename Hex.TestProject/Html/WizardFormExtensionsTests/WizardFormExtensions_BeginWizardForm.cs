using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.Wizard;
using Rhino.Mocks;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Hex.TestProject.Html.WizardFormExtensionsTests
{
	[TestClass]
	public class WizardFormExtensions_BeginWizardForm
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			string wizardStateToken = "WizardStateToken";
			
			WizardStepViewModel<FakeWizardFormModel> viewModel = new WizardStepViewModel<FakeWizardFormModel>();
			viewModel.WizardFormModel = new FakeWizardFormModel();

			WizardController<FakeWizardFormModel> wizardController = this.GenerateWizardController();
			wizardController.WizardStateProvider.Expect( x => x.Save( wizardController.ControllerContext, null ) )
				.IgnoreArguments()
				.Return( wizardStateToken );

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<WizardStepViewModel<FakeWizardFormModel>>( viewModel );
			htmlHelper.ViewContext.Controller = wizardController;

			htmlHelper.BeginWizardForm();

			string expectedResult = string.Format( "<form action=\"http://localhost\" method=\"post\"><input name=\"__wizardStateToken\" type=\"hidden\" value=\"{0}\" />", wizardStateToken );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithHtmlAttributesObjectReturnsCorrectly()
		{
			string wizardStateToken = "WizardStateToken";
			string attributeValue = "attributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			WizardStepViewModel<FakeWizardFormModel> viewModel = new WizardStepViewModel<FakeWizardFormModel>();
			viewModel.WizardFormModel = new FakeWizardFormModel();

			WizardController<FakeWizardFormModel> wizardController = this.GenerateWizardController();
			wizardController.WizardStateProvider.Expect( x => x.Save( wizardController.ControllerContext, null ) )
				.IgnoreArguments()
				.Return( wizardStateToken );

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<WizardStepViewModel<FakeWizardFormModel>>( viewModel );
			htmlHelper.ViewContext.Controller = wizardController;

			htmlHelper.BeginWizardForm( htmlAttributes );

			string expectedResult = string.Format( "<form AttributeName=\"{0}\" action=\"http://localhost\" method=\"post\"><input name=\"__wizardStateToken\" type=\"hidden\" value=\"{1}\" />", attributeValue, wizardStateToken );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithHtmlAttributesDictionaryReturnsCorrectly()
		{
			string wizardStateToken = "WizardStateToken";
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			WizardStepViewModel<FakeWizardFormModel> viewModel = new WizardStepViewModel<FakeWizardFormModel>();
			viewModel.WizardFormModel = new FakeWizardFormModel();

			WizardController<FakeWizardFormModel> wizardController = this.GenerateWizardController();
			wizardController.WizardStateProvider.Expect( x => x.Save( wizardController.ControllerContext, null ) )
				.IgnoreArguments()
				.Return( wizardStateToken );

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<WizardStepViewModel<FakeWizardFormModel>>( viewModel );
			htmlHelper.ViewContext.Controller = wizardController;

			htmlHelper.BeginWizardForm( htmlAttributes );

			string expectedResult = string.Format( "<form action=\"http://localhost\" {0}=\"{1}\" method=\"post\"><input name=\"__wizardStateToken\" type=\"hidden\" value=\"{2}\" />", attributeName, attributeValue, wizardStateToken );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithAttributeExpressionReturnsCorrectly()
		{
			string wizardStateToken = "WizardStateToken";
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			WizardStepViewModel<FakeWizardFormModel> viewModel = new WizardStepViewModel<FakeWizardFormModel>();
			viewModel.WizardFormModel = new FakeWizardFormModel();

			WizardController<FakeWizardFormModel> wizardController = this.GenerateWizardController();
			wizardController.WizardStateProvider.Expect( x => x.Save( wizardController.ControllerContext, null ) )
				.IgnoreArguments()
				.Return( wizardStateToken );

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<WizardStepViewModel<FakeWizardFormModel>>( viewModel );
			htmlHelper.ViewContext.Controller = wizardController;

			htmlHelper.BeginWizardForm( x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<form action=\"http://localhost\" {0}=\"{1}\" method=\"post\"><input name=\"__wizardStateToken\" type=\"hidden\" value=\"{2}\" />", attributeName, attributeValue, wizardStateToken );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WhenUsedWithoutWizardControllerThrowsInvalidOperationException()
		{
			WizardStepViewModel<FakeWizardFormModel> viewModel = new WizardStepViewModel<FakeWizardFormModel>();
			viewModel.WizardFormModel = new FakeWizardFormModel();

			Controller controller = MockRepository.GenerateMock<Controller>();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<WizardStepViewModel<FakeWizardFormModel>>( viewModel );
			htmlHelper.ViewContext.Controller = controller;

			try
			{
				htmlHelper.BeginWizardForm();
				Assert.Fail( "InvalidOperationException was expected." );
			}
			catch( InvalidOperationException ex )
			{
				string expectedMessage = "HtmlHelper wizard extension methods can only be used with a WizardController.";
				Assert.AreEqual( expectedMessage, ex.Message );
			}
		}



		private WizardController<FakeWizardFormModel> GenerateWizardController()
		{
			WizardController<FakeWizardFormModel> wizardController = MockRepository.GenerateMock<WizardController<FakeWizardFormModel>>();

			WizardStep[] wizardSteps = new WizardStep[]
			{
				new WizardStep( "StepOne" ),
				new WizardStep( "StepTwo" ),
				new WizardStep( "StepThree" )
			};

			wizardController.WizardSteps = new WizardStepLinkedList( wizardSteps );

			IWizardStateProvider wizardStateProvider = MockRepository.GenerateMock<IWizardStateProvider>();
			wizardController.WizardStateProvider = wizardStateProvider;

			return wizardController;
		}
	}
}
