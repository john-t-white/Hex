using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;
using Hex.Extensions;
using System.Drawing;
using System.Collections.Generic;

namespace Hex.TestProject.Html.ColorExtensionsTests
{
	[TestClass]
	public class ColorExtensions_Color
	{
		[TestMethod]
		public void WithNameReturnsCorrectly()
		{
			string name = "Name";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.Color( name );

			string expectedResult = string.Format( "<input id=\"{0}\" name=\"{0}\" type=\"color\" value=\"\" />", name );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameAndAttributeExpressionReturnsCorrectly()
		{
			string name = "Name";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.Color( name, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"{2}\" name=\"{2}\" type=\"color\" value=\"\" />", attributeName, attributeValue, name );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameAndValueReturnsCorrectly()
		{
			string name = "Name";
			string value = "#FFFFFF";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.Color( name, value );

			string expectedResult = string.Format( "<input id=\"{0}\" name=\"{0}\" type=\"color\" value=\"{1}\" />", name, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameValueAndHtmlAttributesObjectReturnsCorrectly()
		{
			string name = "Name";
			string value = "#FFFFFF";
			string attributeValue = "attributeValue";
			
			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.Color( name, value, htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" id=\"{1}\" name=\"{1}\" type=\"color\" value=\"{2}\" />", attributeValue, name, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameValueAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			string name = "Name";
			string value = "#FFFFFF";
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.Color( name, value, htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"{2}\" name=\"{2}\" type=\"color\" value=\"{3}\" />", attributeName, attributeValue, name, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameValueAndAttributeExpressionReturnsCorrectly()
		{
			string name = "Name";
			string value = "#FFFFFF";
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.Color( name, value, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"{2}\" name=\"{2}\" type=\"color\" value=\"{3}\" />", attributeName, attributeValue, name, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithColorValueReturnsCorrectly()
		{
			string name = "Name";
			Color value = Color.Red;

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.Color( name, value );

			string expectedResult = string.Format( "<input id=\"{0}\" name=\"{0}\" type=\"color\" value=\"{1}\" />", name, value.ToHexadecimal() );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
