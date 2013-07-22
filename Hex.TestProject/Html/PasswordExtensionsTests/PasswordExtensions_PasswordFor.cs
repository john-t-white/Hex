using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;

namespace Hex.TestProject.Html.PasswordExtensionsTests
{
	[TestClass]
	public class PasswordExtensions_PasswordFor
	{
		[TestMethod]
		public void WithExpressionAndAttributeExpressionReturnsCorrectly()
		{
			string value = "Value";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var viewModel = new PasswordViewModel( value );

			HtmlHelper<PasswordViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.PasswordFor( x => x.PasswordValue, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"PasswordValue\" name=\"PasswordValue\" type=\"password\" />", attributeName, attributeValue );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
