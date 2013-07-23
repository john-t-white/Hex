using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;
using System.Collections.Generic;

namespace Hex.TestProject.Html.UrlExtensionsTests
{
	[TestClass]
	public class UrlExtensions_UrlFor
	{
		[TestMethod]
		public void WithExpressionReturnsCorrectly()
		{
			var viewModel = new UrlViewModel( "http://www.example.com" );

			HtmlHelper<UrlViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.UrlFor( x => x.UrlAsString );

			string expectedResult = string.Format( "<input id=\"UrlAsString\" name=\"UrlAsString\" type=\"url\" value=\"{0}\" />", viewModel.UrlAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndHtmlAttributesObjectReturnsCorrectly()
		{
			var viewModel = new UrlViewModel( "http://www.example.com" );
			string attributeValue = "attributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			HtmlHelper<UrlViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.UrlFor( x => x.UrlAsString, htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" id=\"UrlAsString\" name=\"UrlAsString\" type=\"url\" value=\"{1}\" />", attributeValue, viewModel.UrlAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			var viewModel = new UrlViewModel( "http://www.example.com" );
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			HtmlHelper<UrlViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.UrlFor( x => x.UrlAsString, htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"UrlAsString\" name=\"UrlAsString\" type=\"url\" value=\"{2}\" />", attributeName, attributeValue, viewModel.UrlAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndAttributeExpressionReturnsCorrectly()
		{
			var viewModel = new UrlViewModel( "http://www.example.com" );
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			HtmlHelper<UrlViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.UrlFor( x => x.UrlAsString, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"UrlAsString\" name=\"UrlAsString\" type=\"url\" value=\"{2}\" />", attributeName, attributeValue, viewModel.UrlAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAsColorReturnsCorrectly()
		{
			var viewModel = new UrlViewModel( new Uri( "http://www.example.com", UriKind.Absolute ) );

			HtmlHelper<UrlViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.UrlFor( x => x.Url );

			string expectedResult = string.Format( "<input id=\"Url\" name=\"Url\" type=\"url\" value=\"{0}\" />", viewModel.Url.OriginalString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
