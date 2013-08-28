using Hex.Html;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Hex.TestProject.Html.SubmitInputButtonExtensionsTests
{
	[TestClass]
	public class SubmitInputExtensions_SubmitInputFor
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			string value = "Value";

			var viewModel = new SubmitInputButtonViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<SubmitInputButtonViewModel>( viewModel );

			var result = htmlHelper.SubmitInputButtonFor( x => x.SubmitInputButton, value );

			string expectedResult = string.Format( "<input name=\"SubmitInputButton\" type=\"submit\" value=\"{0}\" />", value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithHtmlAttributesObjectReturnsCorrectly()
		{
			string value = "Value";
			string attributeValue = "attributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			var viewModel = new SubmitInputButtonViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<SubmitInputButtonViewModel>( viewModel );

			var result = htmlHelper.SubmitInputButtonFor( x => x.SubmitInputButton, value, htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" name=\"SubmitInputButton\" type=\"submit\" value=\"{1}\" />", attributeValue, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithHtmlAttributesDictionaryReturnsCorrectly()
		{
			string value = "Value";
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			var viewModel = new SubmitInputButtonViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<SubmitInputButtonViewModel>( viewModel );

			var result = htmlHelper.SubmitInputButtonFor( x => x.SubmitInputButton, value, htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" name=\"SubmitInputButton\" type=\"submit\" value=\"{2}\" />", attributeName, attributeValue, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithAttributeExpressionReturnsCorrectly()
		{
			string value = "Value";
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			var viewModel = new SubmitInputButtonViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<SubmitInputButtonViewModel>( viewModel );

			var result = htmlHelper.SubmitInputButtonFor( x => x.SubmitInputButton, value, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" name=\"SubmitInputButton\" type=\"submit\" value=\"{2}\" />", attributeName, attributeValue, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
