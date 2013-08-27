using Hex.Html;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Hex.TestProject.Html.SubmitButtonExtensionsTests
{
	[TestClass]
	public class SubmitButtonExtensions_SubmitButtonFor
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			string value = "Value";

			var viewModel = new SubmitButtonViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<SubmitButtonViewModel>( viewModel );

			var result = htmlHelper.SubmitButtonFor( x => x.SubmitButton, value );

			string expectedResult = string.Format( "<input id=\"SubmitButton\" name=\"SubmitButton\" type=\"submit\" value=\"{0}\" />", value );
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

			var viewModel = new SubmitButtonViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<SubmitButtonViewModel>( viewModel );

			var result = htmlHelper.SubmitButtonFor( x => x.SubmitButton, value, htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" id=\"SubmitButton\" name=\"SubmitButton\" type=\"submit\" value=\"{1}\" />", attributeValue, value );
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

			var viewModel = new SubmitButtonViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<SubmitButtonViewModel>( viewModel );

			var result = htmlHelper.SubmitButtonFor( x => x.SubmitButton, value, htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"SubmitButton\" name=\"SubmitButton\" type=\"submit\" value=\"{2}\" />", attributeName, attributeValue, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithAttributeExpressionReturnsCorrectly()
		{
			string value = "Value";
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			var viewModel = new SubmitButtonViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<SubmitButtonViewModel>( viewModel );

			var result = htmlHelper.SubmitButtonFor( x => x.SubmitButton, value, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"SubmitButton\" name=\"SubmitButton\" type=\"submit\" value=\"{2}\" />", attributeName, attributeValue, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
