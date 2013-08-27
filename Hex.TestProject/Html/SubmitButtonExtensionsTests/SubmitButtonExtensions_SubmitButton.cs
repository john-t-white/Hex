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
			string value = "Value";

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.SubmitButton( name, value );

			string expectedResult = string.Format( "<input id=\"{0}\" name=\"{0}\" type=\"submit\" value=\"{1}\" />", name, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithHtmlAttributesObjectReturnsCorrectly()
		{
			string name = "Name";
			string value = "Value";
			string attributeValue = "attributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.SubmitButton( name, value, htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" id=\"{1}\" name=\"{1}\" type=\"submit\" value=\"{2}\" />", attributeValue, name, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithHtmlAttributesDictionaryReturnsCorrectly()
		{
			string name = "Name";
			string value = "Value";
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.SubmitButton( name, value, htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"{2}\" name=\"{2}\" type=\"submit\" value=\"{3}\" />", attributeName, attributeValue, name, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithAttributeExpressionReturnsCorrectly()
		{
			string name = "Name";
			string value = "Value";
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.SubmitButton( name, value, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"{2}\" name=\"{2}\" type=\"submit\" value=\"{3}\" />", attributeName, attributeValue, name, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
