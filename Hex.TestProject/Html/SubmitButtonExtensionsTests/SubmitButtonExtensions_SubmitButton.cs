using Hex.Html;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Hex.TestProject.Html.SubmitButtonExtensionsTests
{
	[TestClass]
	public class SubmitButtonExtensions_SubmitButton
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			string name = "Name";
			string buttonText = "ButtonText";
			string value = "Value";

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.SubmitButton( name, buttonText, value );

			string expectedResult = string.Format( "<button name=\"{0}\" type=\"submit\" value=\"{1}\">{2}</button>", name, value, buttonText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithHtmlAttributesObjectReturnsCorrectly()
		{
			string name = "Name";
			string buttonText = "ButtonText";
			string value = "Value";
			string attributeValue = "AttributeValue";

			var htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.SubmitButton( name, buttonText, value, htmlAttributes );

			string expectedResult = string.Format( "<button AttributeName=\"{0}\" name=\"{1}\" type=\"submit\" value=\"{2}\">{3}</button>", attributeValue, name, value, buttonText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithHtmlAttributesDictionaryReturnsCorrectly()
		{
			string name = "Name";
			string buttonText = "ButtonText";
			string value = "Value";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.SubmitButton( name, buttonText, value, htmlAttributes );

			string expectedResult = string.Format( "<button {0}=\"{1}\" name=\"{2}\" type=\"submit\" value=\"{3}\">{4}</button>", attributeName, attributeValue, name, value, buttonText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithAttributeExpressionReturnsCorrectly()
		{
			string name = "Name";
			string buttonText = "ButtonText";
			string value = "Value";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.SubmitButton( name, buttonText, value, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<button {0}=\"{1}\" name=\"{2}\" type=\"submit\" value=\"{3}\">{4}</button>", attributeName, attributeValue, name, value, buttonText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
