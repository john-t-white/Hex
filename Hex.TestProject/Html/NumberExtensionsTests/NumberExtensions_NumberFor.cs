using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;
using System.Collections.Generic;

namespace Hex.TestProject.Html.NumberExtensionsTests
{
	[TestClass]
	public class NumberExtensions_NumberFor
	{
		[TestMethod]
		public void WithExpressionReturnsCorrectly()
		{
			var viewModel = new NumberViewModel( 1 );

			HtmlHelper<NumberViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.NumberFor( x => x.Number );

			string expectedResult = string.Format( "<input id=\"Number\" name=\"Number\" type=\"number\" value=\"{0}\" />", viewModel.Number );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndHtmlAttributesObjectReturnsCorrectly()
		{
			var viewModel = new NumberViewModel( 1 );
			string attributeValue = "attributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			HtmlHelper<NumberViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.NumberFor( x => x.Number, htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" id=\"Number\" name=\"Number\" type=\"number\" value=\"{1}\" />", attributeValue, viewModel.Number );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			var viewModel = new NumberViewModel( 1 );
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			HtmlHelper<NumberViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.NumberFor( x => x.Number, htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"Number\" name=\"Number\" type=\"number\" value=\"{2}\" />", attributeName, attributeValue, viewModel.Number );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndAttributeExpressionReturnsCorrectly()
		{
			var viewModel = new NumberViewModel( 1 );
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			HtmlHelper<NumberViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.NumberFor( x => x.Number, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"Number\" name=\"Number\" type=\"number\" value=\"{2}\" />", attributeName, attributeValue, viewModel.Number );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
