using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;

namespace Hex.TestProject.Html.HiddenExtensionsTests
{
	[TestClass]
	public class HiddenExtensions_HiddenFor
	{
		[TestMethod]
		public void WithExpressionAndAttributeExpressionReturnsCorrectly()
		{
			string value = "Value";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var viewModel = new HiddenViewModel( value );

			HtmlHelper<HiddenViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.HiddenFor( x => x.HiddenValue, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"HiddenValue\" name=\"HiddenValue\" type=\"hidden\" value=\"{2}\" />", attributeName, attributeValue, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
