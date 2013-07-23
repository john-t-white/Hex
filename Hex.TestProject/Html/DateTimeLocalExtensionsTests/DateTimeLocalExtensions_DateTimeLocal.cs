using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;
using System.Collections.Generic;

namespace Hex.TestProject.Html.DateTimeLocalExtensionsTests
{
	[TestClass]
	public class DateTimeLocalExtensions_DateTimeLocal
	{
		[TestMethod]
		public void WithNameReturnsCorrectly()
		{
			string name = "Name";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.DateTimeLocal( name );

			string expectedResult = string.Format( "<input id=\"{0}\" name=\"{0}\" type=\"datetime-local\" value=\"\" />", name );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameAndAttributeExpressionReturnsCorrectly()
		{
			string name = "Name";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.DateTimeLocal( name, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"{2}\" name=\"{2}\" type=\"datetime-local\" value=\"\" />", attributeName, attributeValue, name );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameAndValueReturnsCorrectly()
		{
			string name = "Name";
			string value = "2000-01-01T13:01";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.DateTimeLocal( name, value );

			string expectedResult = string.Format( "<input id=\"{0}\" name=\"{0}\" type=\"datetime-local\" value=\"{1}\" />", name, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameValueAndHtmlAttributesObjectReturnsCorrectly()
		{
			string name = "Name";
			string value = "2000-01-01T13:01";
			string attributeValue = "attributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.DateTimeLocal( name, value, htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" id=\"{1}\" name=\"{1}\" type=\"datetime-local\" value=\"{2}\" />", attributeValue, name, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameValueAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			string name = "Name";
			string value = "2000-01-01T13:01";
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.DateTimeLocal( name, value, htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"{2}\" name=\"{2}\" type=\"datetime-local\" value=\"{3}\" />", attributeName, attributeValue, name, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameValueAndAttributeExpressionReturnsCorrectly()
		{
			string name = "Name";
			string value = "2000-01-01T13:01";
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.DateTimeLocal( name, value, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"{2}\" name=\"{2}\" type=\"datetime-local\" value=\"{3}\" />", attributeName, attributeValue, name, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameAndTimeFormatReturnsCorrectly()
		{
			string name = "Name";
			TimeFormat timeFormat = TimeFormat.Second;

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.DateTimeLocal( name, timeFormat );

			string expectedResult = string.Format( "<input id=\"{0}\" name=\"{0}\" step=\"1\" type=\"datetime-local\" value=\"\" />", name );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameTimeFormatAndHtmlAttributesObjectReturnsCorrectly()
		{
			string name = "Name";
			TimeFormat timeFormat = TimeFormat.Second;
			string attributeValue = "attributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.DateTimeLocal( name, timeFormat, htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" id=\"{1}\" name=\"{1}\" step=\"1\" type=\"datetime-local\" value=\"\" />", attributeValue, name );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameTimeFormatAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			string name = "Name";
			TimeFormat timeFormat = TimeFormat.Second;
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.DateTimeLocal( name, timeFormat, htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"{2}\" name=\"{2}\" step=\"1\" type=\"datetime-local\" value=\"\" />", attributeName, attributeValue, name );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameTimeFormatAndAttributeExpressionReturnsCorrectly()
		{
			string name = "Name";
			TimeFormat timeFormat = TimeFormat.Second;
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.DateTimeLocal( name, timeFormat, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"{2}\" name=\"{2}\" step=\"1\" type=\"datetime-local\" value=\"\" />", attributeName, attributeValue, name );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameValueAndTimeFormatReturnsCorrectly()
		{
			string name = "Name";
			string value = "2000-01-01T13:01:01";
			TimeFormat timeFormat = TimeFormat.Second;

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.DateTimeLocal( name, value, timeFormat );

			string expectedResult = string.Format( "<input id=\"{0}\" name=\"{0}\" step=\"1\" type=\"datetime-local\" value=\"{1}\" />", name, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameValueTimeFormatAndHtmlAttributesObjectReturnsCorrectly()
		{
			string name = "Name";
			string value = "2000-01-01T13:01:01";
			TimeFormat timeFormat = TimeFormat.Second;
			string attributeValue = "attributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.DateTimeLocal( name, value, timeFormat, htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" id=\"{1}\" name=\"{1}\" step=\"1\" type=\"datetime-local\" value=\"{2}\" />", attributeValue, name, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameValueTimeFormatAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			string name = "Name";
			string value = "2000-01-01T13:01:01";
			TimeFormat timeFormat = TimeFormat.Second;
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.DateTimeLocal( name, value, timeFormat, htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"{2}\" name=\"{2}\" step=\"1\" type=\"datetime-local\" value=\"{3}\" />", attributeName, attributeValue, name, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameValueTimeFormatAndAttributeExpressionReturnsCorrectly()
		{
			string name = "Name";
			string value = "2000-01-01T13:01:01";
			TimeFormat timeFormat = TimeFormat.Second;
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.DateTimeLocal( name, value, timeFormat, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"{2}\" name=\"{2}\" step=\"1\" type=\"datetime-local\" value=\"{3}\" />", attributeName, attributeValue, name, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithDateTimeValueReturnsCorrectly()
		{
			string name = "Name";
			DateTime value = new DateTime( 2000, 1, 1, 13, 1, 1 );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.DateTimeLocal( name, value );

			string expectedResult = string.Format( "<input id=\"{0}\" name=\"{0}\" type=\"datetime-local\" value=\"{1}\" />", name, value.ToString( "yyyy-MM-ddTHH:mm" ) );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithSpecifyingStepAttributeOverridesTimeFormatReturnsCorrectly()
		{
			string name = "Name";
			TimeFormat timeFormat = TimeFormat.Second;
			double step = 10;

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.DateTimeLocal( name, timeFormat, x => x.Step( step ) );

			string expectedResult = string.Format( "<input id=\"{0}\" name=\"{0}\" step=\"{1}\" type=\"datetime-local\" value=\"\" />", name, step );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
