using Hex.Html;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Hex.TestProject.Html.BeginButtonExtensionsTests
{
	[TestClass]
	public class BeginButtonExtensions_BeginSubmitButtonFor
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			string value = "Value";

			var viewModel = new BeginButtonViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );
			var result = htmlHelper.BeginSubmitButtonFor( x => x.BeginSubmitButton, value );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<button name=\"BeginSubmitButton\" type=\"submit\" value=\"{0}\">", value );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithHtmlAttributesObjectReturnsCorrectly()
		{
			string value = "Value";
			string attributeValue = "AttributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			var viewModel = new BeginButtonViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );
			var result = htmlHelper.BeginSubmitButtonFor( x => x.BeginSubmitButton, value, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<button AttributeName=\"{0}\" name=\"BeginSubmitButton\" type=\"submit\" value=\"{1}\">", attributeValue, value );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithHtmlAttributesDictionaryReturnsCorrectly()
		{
			string value = "Value";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			var viewModel = new BeginButtonViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );
			var result = htmlHelper.BeginSubmitButtonFor( x => x.BeginSubmitButton, value, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<button {0}=\"{1}\" name=\"BeginSubmitButton\" type=\"submit\" value=\"{2}\">", attributeName, attributeValue, value );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithAttributeExpressionReturnsCorrectly()
		{
			string value = "Value";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var viewModel = new BeginButtonViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );
			var result = htmlHelper.BeginSubmitButtonFor( x => x.BeginSubmitButton, value, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<button {0}=\"{1}\" name=\"BeginSubmitButton\" type=\"submit\" value=\"{2}\">", attributeName, attributeValue, value );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}
	}
}
