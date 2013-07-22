using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;

namespace Hex.TestProject.Html.RadioButtonExtensionsTests
{
	[TestClass]
	public class RadioButtonExtensions_RadioButtonFor
	{
		[TestMethod]
		public void WithExpressionAndAttributeExpressionReturnsCorrectly()
		{
			string value = "Value";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var viewModel = new RadioButtonViewModel( value );

			HtmlHelper<RadioButtonViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.RadioButtonFor( x => x.RadioValue, value, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" checked=\"checked\" id=\"RadioValue\" name=\"RadioValue\" type=\"radio\" value=\"{2}\" />", attributeName, attributeValue, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
