﻿using Hex.Html;
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;
using Rhino.Mocks;
using System.Collections.Generic;

namespace Hex.TestProject.Html.WizardButtonExtensionsTests
{
	[TestClass]
	public class WizardButtonExtensions_PreviousWizardStepSubmitInputButton
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			WizardStepViewModel<FakeWizardFormModel> viewModel = new WizardStepViewModel<FakeWizardFormModel>();
			viewModel.WizardFormModel = new FakeWizardFormModel();

			WizardController<FakeWizardFormModel> wizardController = this.GenerateWizardController();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<WizardStepViewModel<FakeWizardFormModel>>( viewModel );
			htmlHelper.ViewContext.Controller = wizardController;

			var result = htmlHelper.PreviousWizardStepSubmitInputButton();

			string expectedResult = string.Format( "<input name=\"{0}\" type=\"submit\" value=\"Previous\" />", Constants.WIZARD_PREVIOUS_BUTTON_NAME );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNoPreviousStepReturnsCorrectly()
		{
			WizardStepViewModel<FakeWizardFormModel> viewModel = new WizardStepViewModel<FakeWizardFormModel>();
			viewModel.WizardFormModel = new FakeWizardFormModel();

			WizardController<FakeWizardFormModel> wizardController = this.GenerateWizardController();
			wizardController.WizardSteps.CurrentStep = wizardController.WizardSteps.First();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<WizardStepViewModel<FakeWizardFormModel>>( viewModel );
			htmlHelper.ViewContext.Controller = wizardController;

			var result = htmlHelper.PreviousWizardStepSubmitInputButton();

			string expectedResult = string.Format( "<input disabled=\"disabled\" name=\"{0}\" type=\"submit\" value=\"Previous\" />", Constants.WIZARD_PREVIOUS_BUTTON_NAME );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
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

			var result = htmlHelper.PreviousWizardStepSubmitInputButton( htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" name=\"{1}\" type=\"submit\" value=\"Previous\" />", attributeValue, Constants.WIZARD_PREVIOUS_BUTTON_NAME );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
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

			var result = htmlHelper.PreviousWizardStepSubmitInputButton( htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" name=\"{2}\" type=\"submit\" value=\"Previous\" />", attributeName, attributeValue, Constants.WIZARD_PREVIOUS_BUTTON_NAME );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
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

			var result = htmlHelper.PreviousWizardStepSubmitInputButton( x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" name=\"{2}\" type=\"submit\" value=\"Previous\" />", attributeName, attributeValue, Constants.WIZARD_PREVIOUS_BUTTON_NAME );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithValueReturnsCorrectly()
		{
			string value = "Value";

			WizardStepViewModel<FakeWizardFormModel> viewModel = new WizardStepViewModel<FakeWizardFormModel>();
			viewModel.WizardFormModel = new FakeWizardFormModel();

			WizardController<FakeWizardFormModel> wizardController = this.GenerateWizardController();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<WizardStepViewModel<FakeWizardFormModel>>( viewModel );
			htmlHelper.ViewContext.Controller = wizardController;

			var result = htmlHelper.PreviousWizardStepSubmitInputButton( value );

			string expectedResult = string.Format( "<input name=\"{0}\" type=\"submit\" value=\"{1}\" />", Constants.WIZARD_PREVIOUS_BUTTON_NAME, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithValueAndHtmlAttributesObjectReturnsCorrectly()
		{
			string value = "Value";
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

			var result = htmlHelper.PreviousWizardStepSubmitInputButton( value, htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" name=\"{1}\" type=\"submit\" value=\"{2}\" />", attributeValue, Constants.WIZARD_PREVIOUS_BUTTON_NAME, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithValueAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			string value = "Value";
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			WizardStepViewModel<FakeWizardFormModel> viewModel = new WizardStepViewModel<FakeWizardFormModel>();
			viewModel.WizardFormModel = new FakeWizardFormModel();

			WizardController<FakeWizardFormModel> wizardController = this.GenerateWizardController();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<WizardStepViewModel<FakeWizardFormModel>>( viewModel );
			htmlHelper.ViewContext.Controller = wizardController;

			var result = htmlHelper.PreviousWizardStepSubmitInputButton( value, htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" name=\"{2}\" type=\"submit\" value=\"{3}\" />", attributeName, attributeValue, Constants.WIZARD_PREVIOUS_BUTTON_NAME, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithValueAndAttributeExpressionReturnsCorrectly()
		{
			string value = "Value";
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			WizardStepViewModel<FakeWizardFormModel> viewModel = new WizardStepViewModel<FakeWizardFormModel>();
			viewModel.WizardFormModel = new FakeWizardFormModel();

			WizardController<FakeWizardFormModel> wizardController = this.GenerateWizardController();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<WizardStepViewModel<FakeWizardFormModel>>( viewModel );
			htmlHelper.ViewContext.Controller = wizardController;

			var result = htmlHelper.PreviousWizardStepSubmitInputButton( value, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" name=\"{2}\" type=\"submit\" value=\"{3}\" />", attributeName, attributeValue, Constants.WIZARD_PREVIOUS_BUTTON_NAME, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
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
