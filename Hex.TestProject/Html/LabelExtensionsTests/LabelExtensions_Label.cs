using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;

namespace Hex.TestProject.Html.LabelExtensionsTests
{
	[TestClass]
	public class LabelExtensions_Label
	{
		[TestMethod]
		public void WithExpressionAndAttributeExpressionReturnsCorrectly()
		{
			string expression = "Expression";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.Label( expression, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<label {0}=\"{1}\" for=\"{2}\">{2}</label>", attributeName, attributeValue, expression );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionLabelTextAndAttributeExpressionReturnsCorrectly()
		{
			string expression = "Expression";
			string labelText = "LabelText";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.Label( expression, labelText, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<label {0}=\"{1}\" for=\"{2}\">{3}</label>", attributeName, attributeValue, expression, labelText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
