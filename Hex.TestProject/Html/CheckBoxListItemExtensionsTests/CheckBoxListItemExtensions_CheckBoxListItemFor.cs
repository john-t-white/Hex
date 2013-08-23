using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;
using System.Collections.Generic;
using System.Globalization;

namespace Hex.TestProject.Html.CheckBoxListItemExtensionsTests
{
	[TestClass]
	public class CheckBoxListItemExtensions_CheckBoxListItemFor
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			string value = "Value One";

			var viewModel = new CheckBoxListItemViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.CheckBoxListItemFor( x => x.SelectedCheckBoxValues, value );

			string expectedId = string.Format( "SelectedCheckBoxValues_{0}", value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input name=\"SelectedCheckBoxValues.CheckBoxList\" type=\"hidden\" value=\"\" /><input id=\"{0}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{1}\" />", expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentNullException ) )]
		public void WithValueNullThrowsArgumentNullException()
		{
			string value = null;

			var viewModel = new CheckBoxListItemViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			htmlHelper.CheckBoxListItemFor( x => x.SelectedCheckBoxValues, value );
		}

		[TestMethod]
		public void WithHtmlAttributesObjectReturnsCorrectly()
		{
			string value = "Value One";
			string attributeValue = "AttributeValue";

			var htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			var viewModel = new CheckBoxListItemViewModel();

			HtmlHelper<CheckBoxListItemViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.CheckBoxListItemFor( x => x.SelectedCheckBoxValues, value, htmlAttributes );

			string expectedId = string.Format( "SelectedCheckBoxValues_{0}", value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input name=\"SelectedCheckBoxValues.CheckBoxList\" type=\"hidden\" value=\"\" /><input AttributeName=\"{0}\" id=\"{1}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{2}\" />", attributeValue, expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithHtmlAttributesDictionaryReturnsCorrectly()
		{
			string value = "Value One";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			var viewModel = new CheckBoxListItemViewModel();

			HtmlHelper<CheckBoxListItemViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.CheckBoxListItemFor( x => x.SelectedCheckBoxValues, value, htmlAttributes );

			string expectedId = string.Format( "SelectedCheckBoxValues_{0}", value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input name=\"SelectedCheckBoxValues.CheckBoxList\" type=\"hidden\" value=\"\" /><input {0}=\"{1}\" id=\"{2}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{3}\" />", attributeName, attributeValue, expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithAttributeExpressionReturnsCorrectly()
		{
			string value = "Value One";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var viewModel = new CheckBoxListItemViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.CheckBoxListItemFor( x => x.SelectedCheckBoxValues, value, x => x.Attribute( attributeName, attributeValue ) );

			string expectedId = string.Format( "SelectedCheckBoxValues_{0}", value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input name=\"SelectedCheckBoxValues.CheckBoxList\" type=\"hidden\" value=\"\" /><input {0}=\"{1}\" id=\"{2}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{3}\" />", attributeName, attributeValue, expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithModelValueContainsCheckBoxValueReturnsCorrectly()
		{
			string value = "Value One";

			var viewModel = new CheckBoxListItemViewModel();
			viewModel.SelectedCheckBoxValues = new string[] { value, "Other Value" };

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.CheckBoxListItemFor( x => x.SelectedCheckBoxValues, value );

			string expectedId = string.Format( "SelectedCheckBoxValues_{0}", value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input name=\"SelectedCheckBoxValues.CheckBoxList\" type=\"hidden\" value=\"\" /><input checked=\"checked\" id=\"{0}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{1}\" />", expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithModelValueDoesNotContainsCheckBoxValueReturnsCorrectly()
		{
			string value = "Value One";

			var viewModel = new CheckBoxListItemViewModel();
			viewModel.SelectedCheckBoxValues = new string[] { "This Value", "Other Value" };

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.CheckBoxListItemFor( x => x.SelectedCheckBoxValues, value );

			string expectedId = string.Format( "SelectedCheckBoxValues_{0}", value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input name=\"SelectedCheckBoxValues.CheckBoxList\" type=\"hidden\" value=\"\" /><input id=\"{0}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{1}\" />", expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithModelStateErrorReturnsCorrectly()
		{
			string value = "Value One";

			var viewModel = new CheckBoxListItemViewModel();

			HtmlHelper<CheckBoxListItemViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );
			( ( HtmlHelper )htmlHelper ).ViewData.ModelState.AddModelError( "SelectedCheckBoxValues", "ErrorMessage" );

			var result = htmlHelper.CheckBoxListItemFor( x => x.SelectedCheckBoxValues, value );

			string expectedId = string.Format( "SelectedCheckBoxValues_{0}", value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input name=\"SelectedCheckBoxValues.CheckBoxList\" type=\"hidden\" value=\"\" /><input class=\"input-validation-error\" id=\"{0}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{1}\" />", expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithRequiredAnnotationAndUnobtrusiveValidationEnabledReturnsCorrectly()
		{
			string value = "Value One";

			var viewModel = new CheckBoxListItemViewModel();

			ModelState selectedCheckBoxValuesModelState = new ModelState()
			{
				Value = new ValueProviderResult( value, value, CultureInfo.InvariantCulture )
			};

			HtmlHelper<CheckBoxListItemViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel, true );

			var result = htmlHelper.CheckBoxListItemFor( x => x.RequiredSelectedCheckBoxValues, value );

			string expectedId = string.Format( "RequiredSelectedCheckBoxValues_{0}", value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input name=\"RequiredSelectedCheckBoxValues.CheckBoxList\" type=\"hidden\" value=\"\" /><input data-val=\"true\" data-val-required=\"The RequiredSelectedCheckBoxValues field is required.\" id=\"{0}\" name=\"RequiredSelectedCheckBoxValues\" type=\"checkbox\" value=\"{1}\" />", expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameAttributeSpecifiedReturnsCorrectly()
		{
			string value = "Value One";

			var viewModel = new CheckBoxListItemViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.CheckBoxListItemFor( x => x.SelectedCheckBoxValues, value, x => x.Name( "Updated Name" ) );

			string expectedId = string.Format( "SelectedCheckBoxValues_{0}", value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input name=\"SelectedCheckBoxValues.CheckBoxList\" type=\"hidden\" value=\"\" /><input id=\"{0}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{1}\" />", expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithValueAttributeSpecifiedReturnsCorrectly()
		{
			string value = "Value One";

			var viewModel = new CheckBoxListItemViewModel();

			HtmlHelper<CheckBoxListItemViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.CheckBoxListItemFor( x => x.SelectedCheckBoxValues, value, x => x.Attribute( "value", "Updated Value" ) );

			string expectedId = string.Format( "SelectedCheckBoxValues_{0}", value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input name=\"SelectedCheckBoxValues.CheckBoxList\" type=\"hidden\" value=\"\" /><input id=\"{0}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{1}\" />", expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithModelStateValueContainsValueAndModelValueDoesNotContainValueReturnsCorrectly()
		{
			string value = "Value";

			var viewModel = new CheckBoxListItemViewModel();
			viewModel.SelectedCheckBoxValues = new string[] { "ThisValue", "Other Value" };

			string[] modelStateValue = new string[] { value, "OtherValue" };

			ModelState modelState = new ModelState();
			modelState.Value = new ValueProviderResult( modelStateValue, string.Join( ",", modelStateValue ), CultureInfo.InvariantCulture );

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<CheckBoxListItemViewModel>( viewModel );
			( ( HtmlHelper )htmlHelper ).ViewData.ModelState.Add( "SelectedCheckBoxValues", modelState );

			var result = htmlHelper.CheckBoxListItemFor( x => x.SelectedCheckBoxValues, value );

			string expectedId = string.Format( "SelectedCheckBoxValues_{0}", value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input name=\"SelectedCheckBoxValues.CheckBoxList\" type=\"hidden\" value=\"\" /><input checked=\"checked\" id=\"{0}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{1}\" />", expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithModelStateValueDoesNotContainValueAndModelValueContainsValueReturnsCorrectly()
		{
			string value = "Value";

			var viewModel = new CheckBoxListItemViewModel();
			viewModel.SelectedCheckBoxValues = new string[] { value, "Other Value" };

			string[] modelStateValue = new string[] { "ThisValue", "OtherValue" };

			ModelState modelState = new ModelState();
			modelState.Value = new ValueProviderResult( modelStateValue, string.Join( ",", modelStateValue ), CultureInfo.InvariantCulture );

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<CheckBoxListItemViewModel>( viewModel );
			( ( HtmlHelper )htmlHelper ).ViewData.ModelState.Add( "SelectedCheckBoxValues", modelState );

			var result = htmlHelper.CheckBoxListItemFor( x => x.SelectedCheckBoxValues, value );

			string expectedId = string.Format( "SelectedCheckBoxValues_{0}", value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input name=\"SelectedCheckBoxValues.CheckBoxList\" type=\"hidden\" value=\"\" /><input id=\"{0}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{1}\" />", expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void MultipleCallsOnlyRendersOneHiddenInputReturnsCorrectly()
		{
			string valueOne = "Value One";
			string valueTwo = "Value Two";

			var viewModel = new CheckBoxListItemViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var firstResult = htmlHelper.CheckBoxListItemFor( x => x.SelectedCheckBoxValues, valueOne );
			var secondResult = htmlHelper.CheckBoxListItemFor( x => x.SelectedCheckBoxValues, valueTwo );

			string expectedFirstId = string.Format( "SelectedCheckBoxValues_{0}", valueOne.Replace( ' ', '_' ) );
			string expectedFirstResult = string.Format( "<input name=\"SelectedCheckBoxValues.CheckBoxList\" type=\"hidden\" value=\"\" /><input id=\"{0}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{1}\" />", expectedFirstId, valueOne );
			Assert.AreEqual( expectedFirstResult, firstResult.ToHtmlString() );

			string expectedSecondId = string.Format( "SelectedCheckBoxValues_{0}", valueTwo.Replace( ' ', '_' ) );
			string expectedSecondResult = string.Format( "<input id=\"{0}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{1}\" />", expectedSecondId, valueTwo );
			Assert.AreEqual( expectedSecondResult, secondResult.ToHtmlString() );
		}
	}
}
