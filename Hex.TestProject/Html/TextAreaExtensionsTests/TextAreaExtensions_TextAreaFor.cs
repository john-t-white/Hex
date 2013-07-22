using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;

namespace Hex.TestProject.Html.TextAreaExtensionsTests
{
	[TestClass]
	public class TextAreaExtensions_TextAreaFor
	{
		[TestMethod]
		public void WithExpressionAndAttributeExpressionReturnsCorrectly()
		{
			string value = "Value";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var viewModel = new TextAreaViewModel( value );

			HtmlHelper<TextAreaViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.TextAreaFor( x => x.TextAreaValue, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<textarea {0}=\"{1}\" cols=\"20\" id=\"TextAreaValue\" name=\"TextAreaValue\" rows=\"2\">\r\n{2}</textarea>", attributeName, attributeValue, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionRowsColumnsAndAttributeExpressionReturnsCorrectly()
		{
			string value = "Value";
			int rows = 20;
			int columns = 10;
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var viewModel = new TextAreaViewModel( value );

			HtmlHelper<TextAreaViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.TextAreaFor( x => x.TextAreaValue, rows, columns, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<textarea {0}=\"{1}\" cols=\"{2}\" id=\"TextAreaValue\" name=\"TextAreaValue\" rows=\"{3}\">\r\n{4}</textarea>", attributeName, attributeValue, columns, rows, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
