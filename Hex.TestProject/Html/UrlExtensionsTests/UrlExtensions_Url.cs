using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;
using System.Collections.Generic;

namespace Hex.TestProject.Html.UrlExtensionsTests
{
	[TestClass]
	public class UrlExtensions_Url
	{
		[TestMethod]
		public void WithNameReturnsCorrectly()
		{
			string name = "Name";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.Url( name );

			string expectedResult = string.Format( "<input id=\"{0}\" name=\"{0}\" type=\"url\" value=\"\" />", name );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameAndAttributeExpressionReturnsCorrectly()
		{
			string name = "Name";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.Url( name, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"{2}\" name=\"{2}\" type=\"url\" value=\"\" />", attributeName, attributeValue, name );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameAndValueReturnsCorrectly()
		{
			string name = "Name";
			string value = "http://www.example.com";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.Url( name, value );

			string expectedResult = string.Format( "<input id=\"{0}\" name=\"{0}\" type=\"url\" value=\"{1}\" />", name, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameValueAndHtmlAttributesObjectReturnsCorrectly()
		{
			string name = "Name";
			string value = "http://www.example.com";
			string attributeValue = "attributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.Url( name, value, htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" id=\"{1}\" name=\"{1}\" type=\"url\" value=\"{2}\" />", attributeValue, name, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameValueAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			string name = "Name";
			string value = "http://www.example.com";
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.Url( name, value, htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"{2}\" name=\"{2}\" type=\"url\" value=\"{3}\" />", attributeName, attributeValue, name, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameValueAndAttributeExpressionReturnsCorrectly()
		{
			string name = "Name";
			string value = "http://www.example.com";
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.Url( name, value, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"{2}\" name=\"{2}\" type=\"url\" value=\"{3}\" />", attributeName, attributeValue, name, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithUriValueReturnsCorrectly()
		{
			string name = "Name";
			Uri value = new Uri( "http://www.example.com", UriKind.Absolute );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.Url( name, value );

			string expectedResult = string.Format( "<input id=\"{0}\" name=\"{0}\" type=\"url\" value=\"{1}\" />", name, value.OriginalString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
