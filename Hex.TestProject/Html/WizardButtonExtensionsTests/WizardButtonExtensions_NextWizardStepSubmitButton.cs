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
	public class WizardButtonExtensions_NextWizardStepSubmitButton
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			WizardStepViewModel<FakeWizardFormModel> viewModel = new WizardStepViewModel<FakeWizardFormModel>();
			viewModel.WizardFormModel = new FakeWizardFormModel();

			WizardController<FakeWizardFormModel> wizardController = this.GenerateWizardController();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<WizardStepViewModel<FakeWizardFormModel>>( viewModel );
			htmlHelper.ViewContext.Controller = wizardController;

			var result = htmlHelper.NextWizardStepSubmitButton();

			string expectedResult = string.Format( "<button name=\"{0}\" type=\"submit\" value=\"Next\">Next</button>", Constants.WIZARD_NEXT_BUTTON_NAME );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
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

			var result = htmlHelper.NextWizardStepSubmitButton();

			string expectedResult = string.Format( "<button disabled=\"disabled\" name=\"{0}\" type=\"submit\" value=\"Next\">Next</button>", Constants.WIZARD_NEXT_BUTTON_NAME );
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

			var result = htmlHelper.NextWizardStepSubmitButton( htmlAttributes );

			string expectedResult = string.Format( "<button AttributeName=\"{0}\" name=\"{1}\" type=\"submit\" value=\"Next\">Next</button>", attributeValue, Constants.WIZARD_NEXT_BUTTON_NAME );
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

			var result = htmlHelper.NextWizardStepSubmitButton( htmlAttributes );

			string expectedResult = string.Format( "<button {0}=\"{1}\" name=\"{2}\" type=\"submit\" value=\"Next\">Next</button>", attributeName, attributeValue, Constants.WIZARD_NEXT_BUTTON_NAME );
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

			var result = htmlHelper.NextWizardStepSubmitButton( x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<button {0}=\"{1}\" name=\"{2}\" type=\"submit\" value=\"Next\">Next</button>", attributeName, attributeValue, Constants.WIZARD_NEXT_BUTTON_NAME );
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

			var result = htmlHelper.NextWizardStepSubmitButton( buttonText );

			string expectedResult = string.Format( "<button name=\"{0}\" type=\"submit\" value=\"Next\">{1}</button>", Constants.WIZARD_NEXT_BUTTON_NAME, buttonText );
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

			var result = htmlHelper.NextWizardStepSubmitButton( buttonText, htmlAttributes );

			string expectedResult = string.Format( "<button AttributeName=\"{0}\" name=\"{1}\" type=\"submit\" value=\"Next\">{2}</button>", attributeValue, Constants.WIZARD_NEXT_BUTTON_NAME, buttonText );
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

			var result = htmlHelper.NextWizardStepSubmitButton( buttonText, htmlAttributes );

			string expectedResult = string.Format( "<button {0}=\"{1}\" name=\"{2}\" type=\"submit\" value=\"Next\">{3}</button>", attributeName, attributeValue, Constants.WIZARD_NEXT_BUTTON_NAME, buttonText );
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

			var result = htmlHelper.NextWizardStepSubmitButton( buttonText, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<button {0}=\"{1}\" name=\"{2}\" type=\"submit\" value=\"Next\">{3}</button>", attributeName, attributeValue, Constants.WIZARD_NEXT_BUTTON_NAME, buttonText );
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
