using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;

namespace Hex.TestProject.Html.TextAreaExtensionsTests
{
	[TestClass]
	public class TextAreaExtensions_TextArea
	{
		[TestMethod]
		public void WithNameAndAttributeExpressionReturnsCorrectly()
		{
			string name = "Name";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.TextArea( name, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<textarea {0}=\"{1}\" cols=\"20\" id=\"{2}\" name=\"{2}\" rows=\"2\">\r\n</textarea>", attributeName, attributeValue, name );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameValueAndAttributeExpressionReturnsCorrectly()
		{
			string name = "Name";
			string value = "Value";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.TextArea( name, value, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<textarea {0}=\"{1}\" cols=\"20\" id=\"{2}\" name=\"{2}\" rows=\"2\">\r\n{3}</textarea>", attributeName, attributeValue, name, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameValueRowsColumnsAndAttributeExpressionReturnsCorrectly()
		{
			string name = "Name";
			string value = "Value";
			int rows = 20;
			int columns = 10;
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.TextArea( name, value, rows, columns, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<textarea {0}=\"{1}\" cols=\"{2}\" id=\"{3}\" name=\"{3}\" rows=\"{4}\">\r\n{5}</textarea>", attributeName, attributeValue, columns, name, rows, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
