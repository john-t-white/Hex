using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;
using System.Collections.Generic;

namespace Hex.TestProject.Html.DateTimeLocalExtensionsTests
{
	[TestClass]
	public class DateTimeLocalExtensions_DateTimeLocalFor
	{
		[TestMethod]
		public void WithExpressionReturnsCorrectly()
		{
			var viewModel = new DateTimeLocalViewModel( "2000-01-01T13:01" );

			HtmlHelper<DateTimeLocalViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.DateTimeLocalFor( x => x.DateTimeLocalAsString );

			string expectedResult = string.Format( "<input id=\"DateTimeLocalAsString\" name=\"DateTimeLocalAsString\" type=\"datetime-local\" value=\"{0}\" />", viewModel.DateTimeLocalAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndHtmlAttributesObjectReturnsCorrectly()
		{
			var viewModel = new DateTimeLocalViewModel( "2000-01-01T13:01" );
			string attributeValue = "attributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			HtmlHelper<DateTimeLocalViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.DateTimeLocalFor( x => x.DateTimeLocalAsString, htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" id=\"DateTimeLocalAsString\" name=\"DateTimeLocalAsString\" type=\"datetime-local\" value=\"{1}\" />", attributeValue, viewModel.DateTimeLocalAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			var viewModel = new DateTimeLocalViewModel( "2000-01-01T13:01" );
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			HtmlHelper<DateTimeLocalViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.DateTimeLocalFor( x => x.DateTimeLocalAsString, htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"DateTimeLocalAsString\" name=\"DateTimeLocalAsString\" type=\"datetime-local\" value=\"{2}\" />", attributeName, attributeValue, viewModel.DateTimeLocalAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndAttributeExpressionReturnsCorrectly()
		{
			var viewModel = new DateTimeLocalViewModel( "2000-01-01T13:01" );
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			HtmlHelper<DateTimeLocalViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.DateTimeLocalFor( x => x.DateTimeLocalAsString, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"DateTimeLocalAsString\" name=\"DateTimeLocalAsString\" type=\"datetime-local\" value=\"{2}\" />", attributeName, attributeValue, viewModel.DateTimeLocalAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndTimeFormatReturnsCorrectly()
		{
			var viewModel = new DateTimeLocalViewModel( "2000-01-01T13:01:01" );
			TimeFormat timeFormat = TimeFormat.Second;

			HtmlHelper<DateTimeLocalViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.DateTimeLocalFor( x => x.DateTimeLocalAsString, timeFormat );

			string expectedResult = string.Format( "<input id=\"DateTimeLocalAsString\" name=\"DateTimeLocalAsString\" step=\"1\" type=\"datetime-local\" value=\"{0}\" />", viewModel.DateTimeLocalAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionTimeFormatAndHtmlAttributesObjectReturnsCorrectly()
		{
			var viewModel = new DateTimeLocalViewModel( "2000-01-01T13:01:01" );
			TimeFormat timeFormat = TimeFormat.Second;
			string attributeValue = "attributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			HtmlHelper<DateTimeLocalViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.DateTimeLocalFor( x => x.DateTimeLocalAsString, timeFormat, htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" id=\"DateTimeLocalAsString\" name=\"DateTimeLocalAsString\" step=\"1\" type=\"datetime-local\" value=\"{1}\" />", attributeValue, viewModel.DateTimeLocalAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionTimeFormatAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			var viewModel = new DateTimeLocalViewModel( "2000-01-01T13:01:01" );
			TimeFormat timeFormat = TimeFormat.Second;
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			HtmlHelper<DateTimeLocalViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.DateTimeLocalFor( x => x.DateTimeLocalAsString, timeFormat, htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"DateTimeLocalAsString\" name=\"DateTimeLocalAsString\" step=\"1\" type=\"datetime-local\" value=\"{2}\" />", attributeName, attributeValue, viewModel.DateTimeLocalAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionTimeFormatAndAttributeExpressionReturnsCorrectly()
		{
			var viewModel = new DateTimeLocalViewModel( "2000-01-01T13:01:01" );
			TimeFormat timeFormat = TimeFormat.Second;
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			HtmlHelper<DateTimeLocalViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.DateTimeLocalFor( x => x.DateTimeLocalAsString, timeFormat, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"DateTimeLocalAsString\" name=\"DateTimeLocalAsString\" step=\"1\" type=\"datetime-local\" value=\"{2}\" />", attributeName, attributeValue, viewModel.DateTimeLocalAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAsDateTimeReturnsCorrectly()
		{
			var viewModel = new DateTimeLocalViewModel( new DateTime( 2000, 1, 1, 13, 1, 1 ) );

			HtmlHelper<DateTimeLocalViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.DateTimeLocalFor( x => x.DateTimeLocal );

			string expectedResult = string.Format( "<input id=\"DateTimeLocal\" name=\"DateTimeLocal\" type=\"datetime-local\" value=\"{0}\" />", viewModel.DateTimeLocal.ToString( "yyyy-MM-ddTHH:mm" ) );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
