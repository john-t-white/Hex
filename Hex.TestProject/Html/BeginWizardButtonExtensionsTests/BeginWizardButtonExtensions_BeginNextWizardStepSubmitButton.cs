using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;
using Hex.Html;
using Rhino.Mocks;
using System.Collections.Generic;

namespace Hex.TestProject.Html.BeginWizardButtonExtensionsTests
{
	[TestClass]
	public class BeginWizardButtonExtensions_BeginNextWizardStepSubmitButton
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			WizardStepViewModel<FakeWizardFormModel> viewModel = new WizardStepViewModel<FakeWizardFormModel>();
			viewModel.WizardFormModel = new FakeWizardFormModel();

			WizardController<FakeWizardFormModel> wizardController = this.GenerateWizardController();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<WizardStepViewModel<FakeWizardFormModel>>( viewModel );
			htmlHelper.ViewContext.Controller = wizardController;

			var result = htmlHelper.BeginNextWizardStepSubmitButton();

			string expectedResult = string.Format( "<button name=\"{0}\" type=\"submit\" value=\"Next\">", Constants.WIZARD_NEXT_BUTTON_NAME );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithNoNextStepReturnsCorrectly()
		{
			WizardStepViewModel<FakeWizardFormModel> viewModel = new WizardStepViewModel<FakeWizardFormModel>();
			viewModel.WizardFormModel = new FakeWizardFormModel();

			WizardController<FakeWizardFormModel> wizardController = this.GenerateWizardController();
			wizardController.WizardSteps.CurrentStep = wizardController.WizardSteps.Last();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<WizardStepViewModel<FakeWizardFormModel>>( viewModel );
			htmlHelper.ViewContext.Controller = wizardController;

			var result = htmlHelper.BeginNextWizardStepSubmitButton();

			string expectedResult = string.Format( "<button disabled=\"disabled\" name=\"{0}\" type=\"submit\" value=\"Next\">", Constants.WIZARD_NEXT_BUTTON_NAME );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithHtmlAttributesObjectReturnsCorrectly()
		{
			string attributeValue = "attributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			WizardStepViewModel<FakeWizardFormModel> viewModel = new WizardStepViewModel<FakeWizardFormModel>();
			viewModel.WizardFormModel = new FakeWizardFormModel();

			WizardController<FakeWizardFormModel> wizardController = this.GenerateWizardController();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<WizardStepViewModel<FakeWizardFormModel>>( viewModel );
			htmlHelper.ViewContext.Controller = wizardController;

			var result = htmlHelper.BeginNextWizardStepSubmitButton( htmlAttributes );

			string expectedResult = string.Format( "<button AttributeName=\"{0}\" name=\"{1}\" type=\"submit\" value=\"Next\">", attributeValue, Constants.WIZARD_NEXT_BUTTON_NAME );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithHtmlAttributesDictionaryReturnsCorrectly()
		{
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			WizardStepViewModel<FakeWizardFormModel> viewModel = new WizardStepViewModel<FakeWizardFormModel>();
			viewModel.WizardFormModel = new FakeWizardFormModel();

			WizardController<FakeWizardFormModel> wizardController = this.GenerateWizardController();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<WizardStepViewModel<FakeWizardFormModel>>( viewModel );
			htmlHelper.ViewContext.Controller = wizardController;

			var result = htmlHelper.BeginNextWizardStepSubmitButton( htmlAttributes );

			string expectedResult = string.Format( "<button {0}=\"{1}\" name=\"{2}\" type=\"submit\" value=\"Next\">", attributeName, attributeValue, Constants.WIZARD_NEXT_BUTTON_NAME );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithAttributeExpressionReturnsCorrectly()
		{
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			WizardStepViewModel<FakeWizardFormModel> viewModel = new WizardStepViewModel<FakeWizardFormModel>();
			viewModel.WizardFormModel = new FakeWizardFormModel();

			WizardController<FakeWizardFormModel> wizardController = this.GenerateWizardController();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<WizardStepViewModel<FakeWizardFormModel>>( viewModel );
			htmlHelper.ViewContext.Controller = wizardController;

			var result = htmlHelper.BeginNextWizardStepSubmitButton( x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<button {0}=\"{1}\" name=\"{2}\" type=\"submit\" value=\"Next\">", attributeName, attributeValue, Constants.WIZARD_NEXT_BUTTON_NAME );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
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

			wizardController.WizardSteps = new WizardStepLinkedList( wizardSteps, wizardSteps[ 1 ] );

			IWizardStateProvider wizardStateProvider = MockRepository.GenerateMock<IWizardStateProvider>();
			wizardController.WizardStateProvider = wizardStateProvider;

			return wizardController;
		}
	}
}
