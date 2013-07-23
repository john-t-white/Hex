using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Collections.Generic;
using Hex.Html;

namespace Hex.TestProject.Html.DateExtensionsTests
{
	[TestClass]
	public class DateExtensions_DateFor
	{
		[TestMethod]
		public void WithExpressionReturnsCorrectly()
		{
			var viewModel = new DateViewModel( "2000-01-01" );

			HtmlHelper<DateViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.DateFor( x => x.DateAsString );

			string expectedResult = string.Format( "<input id=\"DateAsString\" name=\"DateAsString\" type=\"date\" value=\"{0}\" />", viewModel.DateAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndHtmlAttributesObjectReturnsCorrectly()
		{
			var viewModel = new DateViewModel( "2000-01-01" );
			string attributeValue = "attributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			HtmlHelper<DateViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.DateFor( x => x.DateAsString, htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" id=\"DateAsString\" name=\"DateAsString\" type=\"date\" value=\"{1}\" />", attributeValue, viewModel.DateAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			var viewModel = new DateViewModel( "2000-01-01" );
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			HtmlHelper<DateViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.DateFor( x => x.DateAsString, htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"DateAsString\" name=\"DateAsString\" type=\"date\" value=\"{2}\" />", attributeName, attributeValue, viewModel.DateAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndAttributeExpressionReturnsCorrectly()
		{
			var viewModel = new DateViewModel( "2000-01-01" );
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			HtmlHelper<DateViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.DateFor( x => x.DateAsString, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"DateAsString\" name=\"DateAsString\" type=\"date\" value=\"{2}\" />", attributeName, attributeValue, viewModel.DateAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAsDateTimeReturnsCorrectly()
		{
			var viewModel = new DateViewModel( new DateTime( 2000, 1, 1 ) );

			HtmlHelper<DateViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.DateFor( x => x.Date );

			string expectedResult = string.Format( "<input id=\"Date\" name=\"Date\" type=\"date\" value=\"{0}\" />", viewModel.Date.ToString( "yyyy-MM-dd" ) );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
