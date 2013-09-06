using Hex.Html;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Hex.TestProject.Html.CheckBoxListItemLabelExtensionsTests
{
	[TestClass]
	public class CheckBoxListItemLabelExtensions_CheckBoxListItemLabelFor
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			string value = "Value";

			var viewModel = new CheckBoxListItemLabelViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );
			var result = htmlHelper.CheckBoxListItemLabelFor( x => x.SelectedCheckBoxValues, value );

			string expectedResult = string.Format( "<label for=\"SelectedCheckBoxValues_{0}\">{0}</label>", value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithHtmlAttributesObjectReturnsCorrectly()
		{
			string value = "Value";
			string attributeValue = "AttributeValue";

			var htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			var viewModel = new CheckBoxListItemLabelViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );
			var result = htmlHelper.CheckBoxListItemLabelFor( x => x.SelectedCheckBoxValues, value, htmlAttributes );

			string expectedResult = string.Format( "<label AttributeName=\"{0}\" for=\"SelectedCheckBoxValues_{1}\">{1}</label>", attributeValue, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithHtmlAttributesDictionaryReturnsCorrectly()
		{
			string value = "Value";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			var viewModel = new CheckBoxListItemLabelViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );
			var result = htmlHelper.CheckBoxListItemLabelFor( x => x.SelectedCheckBoxValues, value, htmlAttributes );

			string expectedResult = string.Format( "<label {0}=\"{1}\" for=\"SelectedCheckBoxValues_{2}\">{2}</label>", attributeName, attributeValue, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithAttributeExpressionReturnsCorrectly()
		{
			string value = "Value";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var viewModel = new CheckBoxListItemLabelViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );
			var result = htmlHelper.CheckBoxListItemLabelFor( x => x.SelectedCheckBoxValues, value, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<label {0}=\"{1}\" for=\"SelectedCheckBoxValues_{2}\">{2}</label>", attributeName, attributeValue, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLabelTextReturnsCorrectly()
		{
			string value = "Value";
			string labelText = "LabelText";

			var viewModel = new CheckBoxListItemLabelViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );
			var result = htmlHelper.CheckBoxListItemLabelFor( x => x.SelectedCheckBoxValues, value, labelText );

			string expectedResult = string.Format( "<label for=\"SelectedCheckBoxValues_{0}\">{1}</label>", value, labelText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLabelTextAndHtmlAttributesObjectReturnsCorrectly()
		{
			string value = "Value";
			string labelText = "LabelText";
			string attributeValue = "AttributeValue";

			var htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			var viewModel = new CheckBoxListItemLabelViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );
			var result = htmlHelper.CheckBoxListItemLabelFor( x => x.SelectedCheckBoxValues, value, labelText, htmlAttributes );

			string expectedResult = string.Format( "<label AttributeName=\"{0}\" for=\"SelectedCheckBoxValues_{1}\">{2}</label>", attributeValue, value, labelText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLabelTextAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			string value = "Value";
			string labelText = "LabelText";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			var viewModel = new CheckBoxListItemLabelViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );
			var result = htmlHelper.CheckBoxListItemLabelFor( x => x.SelectedCheckBoxValues, value, labelText, htmlAttributes );

			string expectedResult = string.Format( "<label {0}=\"{1}\" for=\"SelectedCheckBoxValues_{2}\">{3}</label>", attributeName, attributeValue, value, labelText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLabelTextAndAttributeExpressionReturnsCorrectly()
		{
			string value = "Value";
			string labelText = "LabelText";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var viewModel = new CheckBoxListItemLabelViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );
			var result = htmlHelper.CheckBoxListItemLabelFor( x => x.SelectedCheckBoxValues, value, labelText, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<label {0}=\"{1}\" for=\"SelectedCheckBoxValues_{2}\">{3}</label>", attributeName, attributeValue, value, labelText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
