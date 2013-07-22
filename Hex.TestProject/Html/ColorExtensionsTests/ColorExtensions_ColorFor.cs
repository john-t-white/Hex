using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Web.Mvc;
using Hex.Html;
using Hex.Extensions;
using System.Collections.Generic;

namespace Hex.TestProject.Html.ColorExtensionsTests
{
	[TestClass]
	public class ColorExtensions_ColorFor
	{
		[TestMethod]
		public void WithExpressionReturnsCorrectly()
		{
			var viewModel = new ColorViewModel( "#FFFFFF" );

			HtmlHelper<ColorViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.ColorFor( x => x.ColorAsString );

			string expectedResult = string.Format( "<input id=\"ColorAsString\" name=\"ColorAsString\" type=\"color\" value=\"{0}\" />", viewModel.ColorAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndHtmlAttributesObjectReturnsCorrectly()
		{
			var viewModel = new ColorViewModel( "#FFFFFF" );
			string attributeValue = "attributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			HtmlHelper<ColorViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.ColorFor( x => x.ColorAsString, htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" id=\"ColorAsString\" name=\"ColorAsString\" type=\"color\" value=\"{1}\" />", attributeValue, viewModel.ColorAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			var viewModel = new ColorViewModel( "#FFFFFF" );
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			HtmlHelper<ColorViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.ColorFor( x => x.ColorAsString, htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"ColorAsString\" name=\"ColorAsString\" type=\"color\" value=\"{2}\" />", attributeName, attributeValue, viewModel.ColorAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndAttributeExpressionReturnsCorrectly()
		{
			var viewModel = new ColorViewModel( "#FFFFFF" );
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			HtmlHelper<ColorViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.ColorFor( x => x.ColorAsString, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"ColorAsString\" name=\"ColorAsString\" type=\"color\" value=\"{2}\" />", attributeName, attributeValue, viewModel.ColorAsString );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAsColorReturnsCorrectly()
		{
			var viewModel = new ColorViewModel( Color.Red );

			HtmlHelper<ColorViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.ColorFor( x => x.Color );

			string expectedResult = string.Format( "<input id=\"Color\" name=\"Color\" type=\"color\" value=\"{0}\" />", viewModel.Color.ToHexadecimal() );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
