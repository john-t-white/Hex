using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;

namespace Hex.TestProject.Html.CheckBoxExtensionsTests
{
	[TestClass]
	public class CheckBoxExtensions_CheckBoxFor
	{
		[TestMethod]
		public void WithNameAndAttributeExpressionReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			CheckBoxViewModel viewModel = new CheckBoxViewModel( true );

			HtmlHelper<CheckBoxViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<CheckBoxViewModel>( viewModel );

			var result = htmlHelper.CheckBoxFor( x => x.CheckBox, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" checked=\"checked\" id=\"CheckBox\" name=\"CheckBox\" type=\"checkbox\" value=\"true\" /><input name=\"CheckBox\" type=\"hidden\" value=\"false\" />", attributeName, attributeValue );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
