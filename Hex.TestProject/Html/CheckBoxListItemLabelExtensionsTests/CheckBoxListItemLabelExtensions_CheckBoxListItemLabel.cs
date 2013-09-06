using Hex.Html;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Hex.TestProject.Html.CheckBoxListItemLabelExtensionsTests
{
	[TestClass]
	public class CheckBoxListItemLabelExtensions_CheckBoxListItemLabel
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			string expression = "Expression";
			string value = "Value";

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.CheckBoxListItemLabel( expression, value );

			string expectedResult = string.Format( "<label for=\"{0}_{1}\">{1}</label>", expression, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithHtmlAttributesObjectReturnsCorrectly()
		{
			string expression = "Expression";
			string value = "Value";
			string attributeValue = "AttributeValue";

			var htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.CheckBoxListItemLabel( expression, value, htmlAttributes );

			string expectedResult = string.Format( "<label AttributeName=\"{0}\" for=\"{1}_{2}\">{2}</label>", attributeValue, expression, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithHtmlAttributesDictionaryReturnsCorrectly()
		{
			string expression = "Expression";
			string value = "Value";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.CheckBoxListItemLabel( expression, value, htmlAttributes );

			string expectedResult = string.Format( "<label {0}=\"{1}\" for=\"{2}_{3}\">{3}</label>", attributeName, attributeValue, expression, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithAttributeExpressionReturnsCorrectly()
		{
			string expression = "Expression";
			string value = "Value";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.CheckBoxListItemLabel( expression, value, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<label {0}=\"{1}\" for=\"{2}_{3}\">{3}</label>", attributeName, attributeValue, expression, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLabelTextReturnsCorrectly()
		{
			string expression = "Expression";
			string value = "Value";
			string labelText = "LabelText";

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.CheckBoxListItemLabel( expression, value, labelText );

			string expectedResult = string.Format( "<label for=\"{0}_{1}\">{2}</label>", expression, value, labelText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLabelTextAndHtmlAttributesObjectReturnsCorrectly()
		{
			string expression = "Expression";
			string value = "Value";
			string labelText = "LabelText";
			string attributeValue = "AttributeValue";

			var htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.CheckBoxListItemLabel( expression, value, labelText, htmlAttributes );

			string expectedResult = string.Format( "<label AttributeName=\"{0}\" for=\"{1}_{2}\">{3}</label>", attributeValue, expression, value, labelText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLabelTextAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			string expression = "Expression";
			string value = "Value";
			string labelText = "LabelText";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.CheckBoxListItemLabel( expression, value, labelText, htmlAttributes );

			string expectedResult = string.Format( "<label {0}=\"{1}\" for=\"{2}_{3}\">{4}</label>", attributeName, attributeValue, expression, value, labelText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLabelTextAndAttributeExpressionReturnsCorrectly()
		{
			string expression = "Expression";
			string value = "Value";
			string labelText = "LabelText";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.CheckBoxListItemLabel( expression, value, labelText, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<label {0}=\"{1}\" for=\"{2}_{3}\">{4}</label>", attributeName, attributeValue, expression, value, labelText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
