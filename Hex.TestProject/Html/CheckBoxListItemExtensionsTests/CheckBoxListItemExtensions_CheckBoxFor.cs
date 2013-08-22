using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;
using System.Collections.Generic;
using System.Globalization;

namespace Hex.TestProject.Html.CheckBoxListItemExtensionsTests
{
	[TestClass]
	public class CheckBoxListItemExtensions_CheckBoxFor
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			string value = "Value One";

			var viewModel = new CheckBoxListItemViewModel();

			HtmlHelper<CheckBoxListItemViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.CheckBoxListItemFor( x => x.SelectedCheckBoxValues, value );

			string expectedId = string.Format( "SelectedCheckBoxValues_{0}", value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input id=\"{0}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{1}\" />", expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentNullException ) )]
		public void WithValueNullThrowsArgumentNullException()
		{
			string value = null;

			var viewModel = new CheckBoxListItemViewModel();

			HtmlHelper<CheckBoxListItemViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

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
			string expectedResult = string.Format( "<input AttributeName=\"{0}\" id=\"{1}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{2}\" />", attributeValue, expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentNullException ) )]
		public void WithHtmlAttributesObjectAndNullValueThrowsArgumentNullException()
		{
			string value = null;
			string attributeValue = "AttributeValue";

			var htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			var viewModel = new CheckBoxListItemViewModel();

			HtmlHelper<CheckBoxListItemViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			htmlHelper.CheckBoxListItemFor( x => x.SelectedCheckBoxValues, value, htmlAttributes );
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
			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"{2}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{3}\" />", attributeName, attributeValue, expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentNullException ) )]
		public void WithHtmlAttributesDictionaryAndNullValueThrowsArgumentNullException()
		{
			string value = null;
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			var viewModel = new CheckBoxListItemViewModel();

			HtmlHelper<CheckBoxListItemViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			htmlHelper.CheckBoxListItemFor( x => x.SelectedCheckBoxValues, value, htmlAttributes );
		}

		[TestMethod]
		public void WithAttributeExpressionReturnsCorrectly()
		{
			string value = "Value One";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var viewModel = new CheckBoxListItemViewModel();

			HtmlHelper<CheckBoxListItemViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.CheckBoxListItemFor( x => x.SelectedCheckBoxValues, value, x => x.Attribute( attributeName, attributeValue ) );

			string expectedId = string.Format( "SelectedCheckBoxValues_{0}", value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"{2}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{3}\" />", attributeName, attributeValue, expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentNullException ) )]
		public void WithAttributeExpressionAndNullValueThrowsArgumentNullException()
		{
			string value = null;
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var viewModel = new CheckBoxListItemViewModel();

			HtmlHelper<CheckBoxListItemViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			htmlHelper.CheckBoxListItemFor( x => x.SelectedCheckBoxValues, value, x => x.Attribute( attributeName, attributeValue ) );
		}

		[TestMethod]
		public void WithModelValueContainsCheckBoxValueReturnsCorrectly()
		{
			string value = "Value One";

			var viewModel = new CheckBoxListItemViewModel();
			viewModel.SelectedCheckBoxValues = new string[] { value, "Other Value" };

			HtmlHelper<CheckBoxListItemViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.CheckBoxListItemFor( x => x.SelectedCheckBoxValues, value );

			string expectedId = string.Format( "SelectedCheckBoxValues_{0}", value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input checked=\"checked\" id=\"{0}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{1}\" />", expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithModelValueDoesNotContainsCheckBoxValueReturnsCorrectly()
		{
			string value = "Value One";

			var viewModel = new CheckBoxListItemViewModel();
			viewModel.SelectedCheckBoxValues = new string[] { "This Value", "Other Value" };

			HtmlHelper<CheckBoxListItemViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.CheckBoxListItemFor( x => x.SelectedCheckBoxValues, value );

			string expectedId = string.Format( "SelectedCheckBoxValues_{0}", value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input id=\"{0}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{1}\" />", expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithModelStateErrorReturnsCorrectly()
		{
			string value = "Value One";

			var viewModel = new CheckBoxListItemViewModel();

			ModelState selectedCheckBoxValuesModelState = new ModelState()
			{
				Value = new ValueProviderResult( value, value, CultureInfo.InvariantCulture )
			};

			HtmlHelper<CheckBoxListItemViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );
			( ( HtmlHelper )htmlHelper ).ViewData.ModelState.AddModelError( "SelectedCheckBoxValues", "ErrorMessage" );

			var result = htmlHelper.CheckBoxListItemFor( x => x.SelectedCheckBoxValues, value );

			string expectedId = string.Format( "SelectedCheckBoxValues_{0}", value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input class=\"input-validation-error\" id=\"{0}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{1}\" />", expectedId, value );
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
			string expectedResult = string.Format( "<input data-val=\"true\" data-val-required=\"The RequiredSelectedCheckBoxValues field is required.\" id=\"{0}\" name=\"RequiredSelectedCheckBoxValues\" type=\"checkbox\" value=\"{1}\" />", expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameAttributeSpecifiedReturnsCorrectly()
		{
			string value = "Value One";

			var viewModel = new CheckBoxListItemViewModel();

			HtmlHelper<CheckBoxListItemViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.CheckBoxListItemFor( x => x.SelectedCheckBoxValues, value, x => x.Name( "Updated Name" ) );

			string expectedId = string.Format( "SelectedCheckBoxValues_{0}", value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input id=\"{0}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{1}\" />", expectedId, value );
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
			string expectedResult = string.Format( "<input id=\"{0}\" name=\"SelectedCheckBoxValues\" type=\"checkbox\" value=\"{1}\" />", expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
