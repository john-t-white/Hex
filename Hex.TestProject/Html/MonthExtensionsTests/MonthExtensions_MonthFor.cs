using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;
using System.Collections.Generic;

namespace Hex.TestProject.Html.MonthExtensionsTests
{
	[TestClass]
	public class MonthExtensions_MonthFor
	{
		[TestMethod]
		public void WithExpressionReturnsCorrectly()
		{
			var viewModel = new MonthViewModel( "2000-01" );

			HtmlHelper<MonthViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.MonthFor( x => x.MonthAsString );

			string expectedResult = string.Format( "<input id=\"MonthAsString\" name=\"MonthAsString\" type=\"month\" value=\"{0}\" />", viewModel.MonthAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndHtmlAttributesObjectReturnsCorrectly()
		{
			var viewModel = new MonthViewModel( "2000-01" );
			string attributeValue = "attributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			HtmlHelper<MonthViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.MonthFor( x => x.MonthAsString, htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" id=\"MonthAsString\" name=\"MonthAsString\" type=\"month\" value=\"{1}\" />", attributeValue, viewModel.MonthAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			var viewModel = new MonthViewModel( "2000-01" );
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			HtmlHelper<MonthViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.MonthFor( x => x.MonthAsString, htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"MonthAsString\" name=\"MonthAsString\" type=\"month\" value=\"{2}\" />", attributeName, attributeValue, viewModel.MonthAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndAttributeExpressionReturnsCorrectly()
		{
			var viewModel = new MonthViewModel( "2000-01" );
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			HtmlHelper<MonthViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.MonthFor( x => x.MonthAsString, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"MonthAsString\" name=\"MonthAsString\" type=\"month\" value=\"{2}\" />", attributeName, attributeValue, viewModel.MonthAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAsDateTimeReturnsCorrectly()
		{
			var viewModel = new MonthViewModel( new DateTime( 2000, 1, 1 ) );

			HtmlHelper<MonthViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.MonthFor( x => x.Month );

			string expectedResult = string.Format( "<input id=\"Month\" name=\"Month\" type=\"month\" value=\"{0}\" />", viewModel.Month.ToString( "yyyy-MM" ) );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
