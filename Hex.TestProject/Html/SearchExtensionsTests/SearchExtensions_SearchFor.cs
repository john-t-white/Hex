using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;
using System.Collections.Generic;

namespace Hex.TestProject.Html.SearchExtensionsTests
{
	[TestClass]
	public class SearchExtensions_SearchFor
	{
		[TestMethod]
		public void WithExpressionReturnsCorrectly()
		{
			var viewModel = new SearchViewModel( "Search Text" );

			HtmlHelper<SearchViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.SearchFor( x => x.SearchText );

			string expectedResult = string.Format( "<input id=\"SearchText\" name=\"SearchText\" type=\"search\" value=\"{0}\" />", viewModel.SearchText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndHtmlAttributesObjectReturnsCorrectly()
		{
			var viewModel = new SearchViewModel( "Search Text" );
			string attributeValue = "attributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			HtmlHelper<SearchViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.SearchFor( x => x.SearchText, htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" id=\"SearchText\" name=\"SearchText\" type=\"search\" value=\"{1}\" />", attributeValue, viewModel.SearchText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			var viewModel = new SearchViewModel( "Search Text" );
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			HtmlHelper<SearchViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.SearchFor( x => x.SearchText, htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"SearchText\" name=\"SearchText\" type=\"search\" value=\"{2}\" />", attributeName, attributeValue, viewModel.SearchText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndAttributeExpressionReturnsCorrectly()
		{
			var viewModel = new SearchViewModel( "Search Text" );
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			HtmlHelper<SearchViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.SearchFor( x => x.SearchText, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"SearchText\" name=\"SearchText\" type=\"search\" value=\"{2}\" />", attributeName, attributeValue, viewModel.SearchText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
