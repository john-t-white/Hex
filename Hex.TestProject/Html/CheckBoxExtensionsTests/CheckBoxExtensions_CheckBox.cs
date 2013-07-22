using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;

namespace Hex.TestProject.Html.CheckBoxExtensionsTests
{
	[TestClass]
	public class CheckBoxExtensions_CheckBox
	{
		[TestMethod]
		public void WithNameAndAttributeExpressionReturnsCorrectly()
		{
			string name = "Name";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.CheckBox( name, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"{2}\" name=\"{2}\" type=\"checkbox\" value=\"true\" /><input name=\"{2}\" type=\"hidden\" value=\"false\" />", attributeName, attributeValue, name );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameIsCheckedAndAttributeExpressionReturnsCorrectly()
		{
			string name = "Name";
			bool isChecked = true;
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.CheckBox( name, isChecked, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" checked=\"checked\" id=\"{2}\" name=\"{2}\" type=\"checkbox\" value=\"true\" /><input name=\"{2}\" type=\"hidden\" value=\"false\" />", attributeName, attributeValue, name );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
