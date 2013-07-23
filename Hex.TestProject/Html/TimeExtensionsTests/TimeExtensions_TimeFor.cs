using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;
using System.Collections.Generic;

namespace Hex.TestProject.Html.TimeExtensionsTests
{
	[TestClass]
	public class TimeExtensions_TimeFor
	{
		[TestMethod]
		public void WithExpressionReturnsCorrectly()
		{
			var viewModel = new TimeViewModel( "13:01" );

			HtmlHelper<TimeViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.TimeFor( x => x.TimeAsString );

			string expectedResult = string.Format( "<input id=\"TimeAsString\" name=\"TimeAsString\" type=\"time\" value=\"{0}\" />", viewModel.TimeAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndHtmlAttributesObjectReturnsCorrectly()
		{
			var viewModel = new TimeViewModel( "13:01" );
			string attributeValue = "attributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			HtmlHelper<TimeViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.TimeFor( x => x.TimeAsString, htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" id=\"TimeAsString\" name=\"TimeAsString\" type=\"time\" value=\"{1}\" />", attributeValue, viewModel.TimeAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			var viewModel = new TimeViewModel( "13:01" );
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			HtmlHelper<TimeViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.TimeFor( x => x.TimeAsString, htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"TimeAsString\" name=\"TimeAsString\" type=\"time\" value=\"{2}\" />", attributeName, attributeValue, viewModel.TimeAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndAttributeExpressionReturnsCorrectly()
		{
			var viewModel = new TimeViewModel( "13:01" );
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			HtmlHelper<TimeViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.TimeFor( x => x.TimeAsString, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"TimeAsString\" name=\"TimeAsString\" type=\"time\" value=\"{2}\" />", attributeName, attributeValue, viewModel.TimeAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndTimeFormatReturnsCorrectly()
		{
			var viewModel = new TimeViewModel( "13:01:01" );
			TimeFormat timeFormat = TimeFormat.Second;

			HtmlHelper<TimeViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.TimeFor( x => x.TimeAsString, timeFormat );

			string expectedResult = string.Format( "<input id=\"TimeAsString\" name=\"TimeAsString\" step=\"1\" type=\"time\" value=\"{0}\" />", viewModel.TimeAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionTimeFormatAndHtmlAttributesObjectReturnsCorrectly()
		{
			var viewModel = new TimeViewModel( "13:01:01" );
			TimeFormat timeFormat = TimeFormat.Second;
			string attributeValue = "attributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			HtmlHelper<TimeViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.TimeFor( x => x.TimeAsString, timeFormat, htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" id=\"TimeAsString\" name=\"TimeAsString\" step=\"1\" type=\"time\" value=\"{1}\" />", attributeValue, viewModel.TimeAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionTimeFormatAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			var viewModel = new TimeViewModel( "13:01:01" );
			TimeFormat timeFormat = TimeFormat.Second;
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			HtmlHelper<TimeViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.TimeFor( x => x.TimeAsString, timeFormat, htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"TimeAsString\" name=\"TimeAsString\" step=\"1\" type=\"time\" value=\"{2}\" />", attributeName, attributeValue, viewModel.TimeAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionTimeFormatAndAttributeExpressionReturnsCorrectly()
		{
			var viewModel = new TimeViewModel( "13:01:01" );
			TimeFormat timeFormat = TimeFormat.Second;
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			HtmlHelper<TimeViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.TimeFor( x => x.TimeAsString, timeFormat, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"TimeAsString\" name=\"TimeAsString\" step=\"1\" type=\"time\" value=\"{2}\" />", attributeName, attributeValue, viewModel.TimeAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAsDateTimeReturnsCorrectly()
		{
			var viewModel = new TimeViewModel( new DateTime( 2000, 1, 1, 13, 1, 1 ) );

			HtmlHelper<TimeViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.TimeFor( x => x.Time );

			string expectedResult = string.Format( "<input id=\"Time\" name=\"Time\" type=\"time\" value=\"{0}\" />", viewModel.Time.ToString( "HH:mm" ) );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
