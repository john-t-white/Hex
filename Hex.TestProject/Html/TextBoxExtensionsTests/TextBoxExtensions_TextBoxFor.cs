using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;

namespace Hex.TestProject.Html.TextBoxExtensionsTests
{
	[TestClass]
	public class TextBoxExtensions_TextBoxFor
	{
		[TestMethod]
		public void WithExpressionAndAttributeExpressionReturnsCorrectly()
		{
			string value = "Value";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var viewModel = new TextBoxViewModel( value );

			HtmlHelper<TextBoxViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.TextBoxFor( x => x.TextBoxValue, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"TextBoxValue\" name=\"TextBoxValue\" type=\"text\" value=\"{2}\" />", attributeName, attributeValue, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionRowsColumnsAndAttributeExpressionReturnsCorrectly()
		{
			string value = "Value";
			string format = "{0:yyyy-MM-dd}";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var viewModel = new TextBoxViewModel( value );

			HtmlHelper<TextBoxViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.TextBoxFor( x => x.TextBoxValue, format, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"TextBoxValue\" name=\"TextBoxValue\" type=\"text\" value=\"{2}\" />", attributeName, attributeValue, string.Format( format, value ) );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
