using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;
using System.Collections.Generic;
using System.Globalization;

namespace Hex.TestProject.Html.CheckBoxExtensions_WithValueTests
{
	[TestClass]
	public class CheckBoxExtensions_WithValue_CheckBoxFor
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			string value = "Value One";

			CheckBoxViewModel viewModel = new CheckBoxViewModel();

			HtmlHelper<CheckBoxViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.CheckBoxFor( x => x.SelectedCheckBoxValues, value );

			string expectedId = string.Format( "SelectedCheckBoxValues_{0}", value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input id=\"{0}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{1}\" />", expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
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

			CheckBoxViewModel viewModel = new CheckBoxViewModel();

			HtmlHelper<CheckBoxViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.CheckBoxFor( x => x.SelectedCheckBoxValues, value, htmlAttributes );

			string expectedId = string.Format( "SelectedCheckBoxValues_{0}", value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input AttributeName=\"{0}\" id=\"{1}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{2}\" />", attributeValue, expectedId, value );
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

			CheckBoxViewModel viewModel = new CheckBoxViewModel();

			HtmlHelper<CheckBoxViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.CheckBoxFor( x => x.SelectedCheckBoxValues, value, htmlAttributes );

			string expectedId = string.Format( "SelectedCheckBoxValues_{0}", value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"{2}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{3}\" />", attributeName, attributeValue, expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithAttributeExpressionReturnsCorrectly()
		{
			string value = "Value One";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			CheckBoxViewModel viewModel = new CheckBoxViewModel();

			HtmlHelper<CheckBoxViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.CheckBoxFor( x => x.SelectedCheckBoxValues, value, x => x.Attribute( attributeName, attributeValue ) );

			string expectedId = string.Format( "SelectedCheckBoxValues_{0}", value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"{2}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{3}\" />", attributeName, attributeValue, expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithModelValueContainsCheckBoxValueReturnsCorrectly()
		{
			string value = "Value One";

			CheckBoxViewModel viewModel = new CheckBoxViewModel();
			viewModel.SelectedCheckBoxValues = new string[] { value, "Other Value" };

			HtmlHelper<CheckBoxViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.CheckBoxFor( x => x.SelectedCheckBoxValues, value );

			string expectedId = string.Format( "SelectedCheckBoxValues_{0}", value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input checked=\"checked\" id=\"{0}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{1}\" />", expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithModelValueDoesNotContainsCheckBoxValueReturnsCorrectly()
		{
			string value = "Value One";

			CheckBoxViewModel viewModel = new CheckBoxViewModel();
			viewModel.SelectedCheckBoxValues = new string[] { "This Value", "Other Value" };

			HtmlHelper<CheckBoxViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.CheckBoxFor( x => x.SelectedCheckBoxValues, value );

			string expectedId = string.Format( "SelectedCheckBoxValues_{0}", value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input id=\"{0}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{1}\" />", expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithModelStateErrorReturnsCorrectly()
		{
			string value = "Value One";

			CheckBoxViewModel viewModel = new CheckBoxViewModel();

			ModelState selectedCheckBoxValuesModelState = new ModelState()
			{
				Value = new ValueProviderResult( value, value, CultureInfo.InvariantCulture )
			};

			HtmlHelper<CheckBoxViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );
			htmlHelper.ViewData.ModelState.AddModelError( "SelectedCheckBoxValues", "ErrorMessage" );

			var result = htmlHelper.CheckBoxFor( x => x.SelectedCheckBoxValues, value );

			string expectedId = string.Format( "SelectedCheckBoxValues_{0}", value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input class=\"input-validation-error\" id=\"{0}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{1}\" />", expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
