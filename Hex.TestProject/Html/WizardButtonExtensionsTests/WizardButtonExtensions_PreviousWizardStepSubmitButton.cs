using Hex.Html;
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;
using Rhino.Mocks;
using System.Collections.Generic;

namespace Hex.TestProject.Html.WizardButtonExtensionsTests
{
	[TestClass]
	public class WizardButtonExtensions_PreviousWizardStepSubmitButton
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			WizardStepViewModel<FakeWizardFormModel> viewModel = new WizardStepViewModel<FakeWizardFormModel>();
			viewModel.WizardFormModel = new FakeWizardFormModel();

			WizardController<FakeWizardFormModel> wizardController = this.GenerateWizardController();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<WizardStepViewModel<FakeWizardFormModel>>( viewModel );
			htmlHelper.ViewContext.Controller = wizardController;

			var result = htmlHelper.PreviousWizardStepSubmitButton();

			string expectedResult = string.Format( "<button name=\"{0}\" type=\"submit\" value=\"Previous\">Previous</button>", Constants.WIZARD_PREVIOUS_BUTTON_NAME );
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

			var result = htmlHelper.PreviousWizardStepSubmitButton();

			string expectedResult = string.Format( "<button disabled=\"disabled\" name=\"{0}\" type=\"submit\" value=\"Previous\">Previous</button>", Constants.WIZARD_PREVIOUS_BUTTON_NAME );
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

			var result = htmlHelper.PreviousWizardStepSubmitButton( htmlAttributes );

			string expectedResult = string.Format( "<button AttributeName=\"{0}\" name=\"{1}\" type=\"submit\" value=\"Previous\">Previous</button>", attributeValue, Constants.WIZARD_PREVIOUS_BUTTON_NAME );
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

			var result = htmlHelper.PreviousWizardStepSubmitButton( htmlAttributes );

			string expectedResult = string.Format( "<button {0}=\"{1}\" name=\"{2}\" type=\"submit\" value=\"Previous\">Previous</button>", attributeName, attributeValue, Constants.WIZARD_PREVIOUS_BUTTON_NAME );
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

			var result = htmlHelper.PreviousWizardStepSubmitButton( x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<button {0}=\"{1}\" name=\"{2}\" type=\"submit\" value=\"Previous\">Previous</button>", attributeName, attributeValue, Constants.WIZARD_PREVIOUS_BUTTON_NAME );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithButtonTextReturnsCorrectly()
		{
			string buttonText = "ButtonText";

			WizardStepViewModel<FakeWizardFormModel> viewModel = new WizardStepViewModel<FakeWizardFormModel>();
			viewModel.WizardFormModel = new FakeWizardFormModel();

			WizardController<FakeWizardFormModel> wizardController = this.GenerateWizardController();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<WizardStepViewModel<FakeWizardFormModel>>( viewModel );
			htmlHelper.ViewContext.Controller = wizardController;

			var result = htmlHelper.PreviousWizardStepSubmitButton( buttonText );

			string expectedResult = string.Format( "<button name=\"{0}\" type=\"submit\" value=\"Previous\">{1}</button>", Constants.WIZARD_PREVIOUS_BUTTON_NAME, buttonText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithButtonTextAndHtmlAttributesObjectReturnsCorrectly()
		{
			string buttonText = "ButtonText";
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

			var result = htmlHelper.PreviousWizardStepSubmitButton( buttonText, htmlAttributes );

			string expectedResult = string.Format( "<button AttributeName=\"{0}\" name=\"{1}\" type=\"submit\" value=\"Previous\">{2}</button>", attributeValue, Constants.WIZARD_PREVIOUS_BUTTON_NAME, buttonText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithButtonTextAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			string buttonText = "ButtonText";
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			WizardStepViewModel<FakeWizardFormModel> viewModel = new WizardStepViewModel<FakeWizardFormModel>();
			viewModel.WizardFormModel = new FakeWizardFormModel();

			WizardController<FakeWizardFormModel> wizardController = this.GenerateWizardController();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<WizardStepViewModel<FakeWizardFormModel>>( viewModel );
			htmlHelper.ViewContext.Controller = wizardController;

			var result = htmlHelper.PreviousWizardStepSubmitButton( buttonText, htmlAttributes );

			string expectedResult = string.Format( "<button {0}=\"{1}\" name=\"{2}\" type=\"submit\" value=\"Previous\">{3}</button>", attributeName, attributeValue, Constants.WIZARD_PREVIOUS_BUTTON_NAME, buttonText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithButtonTextAndAttributeExpressionReturnsCorrectly()
		{
			string buttonText = "ButtonText";
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			WizardStepViewModel<FakeWizardFormModel> viewModel = new WizardStepViewModel<FakeWizardFormModel>();
			viewModel.WizardFormModel = new FakeWizardFormModel();

			WizardController<FakeWizardFormModel> wizardController = this.GenerateWizardController();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<WizardStepViewModel<FakeWizardFormModel>>( viewModel );
			htmlHelper.ViewContext.Controller = wizardController;

			var result = htmlHelper.PreviousWizardStepSubmitButton( buttonText, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<button {0}=\"{1}\" name=\"{2}\" type=\"submit\" value=\"Previous\">{3}</button>", attributeName, attributeValue, Constants.WIZARD_PREVIOUS_BUTTON_NAME, buttonText );
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
