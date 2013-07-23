using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;
using System.Collections.Generic;

namespace Hex.TestProject.Html.RangeExtensionsTests
{
	[TestClass]
	public class RangeExtensions_RangeFor
	{
		[TestMethod]
		public void WithExpressionReturnsCorrectly()
		{
			var viewModel = new RangeViewModel( 1 );

			HtmlHelper<RangeViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.RangeFor( x => x.Number );

			string expectedResult = string.Format( "<input id=\"Number\" name=\"Number\" type=\"range\" value=\"{0}\" />", viewModel.Number );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndHtmlAttributesObjectReturnsCorrectly()
		{
			var viewModel = new RangeViewModel( 1 );
			string attributeValue = "attributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			HtmlHelper<RangeViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.RangeFor( x => x.Number, htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" id=\"Number\" name=\"Number\" type=\"range\" value=\"{1}\" />", attributeValue, viewModel.Number );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			var viewModel = new RangeViewModel( 1 );
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			HtmlHelper<RangeViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.RangeFor( x => x.Number, htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"Number\" name=\"Number\" type=\"range\" value=\"{2}\" />", attributeName, attributeValue, viewModel.Number );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndAttributeExpressionReturnsCorrectly()
		{
			var viewModel = new RangeViewModel( 1 );
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			HtmlHelper<RangeViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.RangeFor( x => x.Number, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"Number\" name=\"Number\" type=\"range\" value=\"{2}\" />", attributeName, attributeValue, viewModel.Number );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionMinAndMaxReturnsCorrectly()
		{
			var viewModel = new RangeViewModel( 1 );
			int min = 0;
			int max = 10;

			HtmlHelper<RangeViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.RangeFor( x => x.Number, min, max );

			string expectedResult = string.Format( "<input id=\"Number\" max=\"{0}\" min=\"{1}\" name=\"Number\" type=\"range\" value=\"{2}\" />", max, min, viewModel.Number );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionMinMaxAndHtmlAttributesObjectReturnsCorrectly()
		{
			var viewModel = new RangeViewModel( 1 );
			int min = 0;
			int max = 10;
			string attributeValue = "attributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			HtmlHelper<RangeViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.RangeFor( x => x.Number, min, max, htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" id=\"Number\" max=\"{1}\" min=\"{2}\" name=\"Number\" type=\"range\" value=\"{3}\" />", attributeValue, max, min, viewModel.Number );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionMinMaxAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			var viewModel = new RangeViewModel( 1 );
			int min = 0;
			int max = 10;
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			HtmlHelper<RangeViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.RangeFor( x => x.Number, min, max, htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"Number\" max=\"{2}\" min=\"{3}\" name=\"Number\" type=\"range\" value=\"{4}\" />", attributeName, attributeValue, max, min, viewModel.Number );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionMinMaxAndAttributeExpressionReturnsCorrectly()
		{
			var viewModel = new RangeViewModel( 1 );
			int min = 0;
			int max = 10;
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			HtmlHelper<RangeViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.RangeFor( x => x.Number, min, max, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"Number\" max=\"{2}\" min=\"{3}\" name=\"Number\" type=\"range\" value=\"{4}\" />", attributeName, attributeValue, max, min, viewModel.Number );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
