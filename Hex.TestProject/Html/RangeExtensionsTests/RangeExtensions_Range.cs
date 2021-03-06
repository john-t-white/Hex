﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;
using System.Collections.Generic;

namespace Hex.TestProject.Html.RangeExtensionsTests
{
	[TestClass]
	public class RangeExtensions_Range
	{
		[TestMethod]
		public void WithNameReturnsCorrectly()
		{
			string name = "Name";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.Range( name );

			string expectedResult = string.Format( "<input id=\"{0}\" name=\"{0}\" type=\"range\" value=\"\" />", name );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameAndAttributeExpressionReturnsCorrectly()
		{
			string name = "Name";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.Range( name, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"{2}\" name=\"{2}\" type=\"range\" value=\"\" />", attributeName, attributeValue, name );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameAndValueReturnsCorrectly()
		{
			string name = "Name";
			string value = "1";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.Range( name, value );

			string expectedResult = string.Format( "<input id=\"{0}\" name=\"{0}\" type=\"range\" value=\"{1}\" />", name, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameValueAndHtmlAttributesObjectReturnsCorrectly()
		{
			string name = "Name";
			string value = "1";
			string attributeValue = "attributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.Range( name, value, htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" id=\"{1}\" name=\"{1}\" type=\"range\" value=\"{2}\" />", attributeValue, name, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameValueAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			string name = "Name";
			string value = "1";
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.Range( name, value, htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"{2}\" name=\"{2}\" type=\"range\" value=\"{3}\" />", attributeName, attributeValue, name, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameValueAndAttributeExpressionReturnsCorrectly()
		{
			string name = "Name";
			string value = "1";
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.Range( name, value, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"{2}\" name=\"{2}\" type=\"range\" value=\"{3}\" />", attributeName, attributeValue, name, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameValueMinAndMaxReturnsCorrectly()
		{
			string name = "Name";
			string value = "1";
			int min = 0;
			int max = 10;
			
			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.Range( name, value, min, max );

			string expectedResult = string.Format( "<input id=\"{0}\" max=\"{1}\" min=\"{2}\" name=\"{0}\" type=\"range\" value=\"{3}\" />", name, max, min, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameValueMinMaxAndHtmlAttributesObjectReturnsCorrectly()
		{
			string name = "Name";
			string value = "1";
			int min = 0;
			int max = 10;
			string attributeValue = "attributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.Range( name, value, min, max, htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" id=\"{1}\" max=\"{2}\" min=\"{3}\" name=\"{1}\" type=\"range\" value=\"{4}\" />", attributeValue, name, max, min, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameValueMinMaxAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			string name = "Name";
			string value = "1";
			int min = 0;
			int max = 10;
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.Range( name, value, min, max, htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"{2}\" max=\"{3}\" min=\"{4}\" name=\"{2}\" type=\"range\" value=\"{5}\" />", attributeName, attributeValue, name, max, min, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameValueMinMaxAndAttributeExpressionReturnsCorrectly()
		{
			string name = "Name";
			string value = "1";
			int min = 0;
			int max = 10;
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.Range( name, value, min, max, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"{2}\" max=\"{3}\" min=\"{4}\" name=\"{2}\" type=\"range\" value=\"{5}\" />", attributeName, attributeValue, name, max, min, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
