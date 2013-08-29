using Hex.Html;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Hex.TestProject.Html.BeginButtonExtensionsTests
{
	[TestClass]
	public class BeginButtonExtensions_BeginButton
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			string name = "Name";
			string value = "Value";

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.BeginButton( name, value );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<button name=\"{0}\" type=\"button\" value=\"{1}\">", name, value );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithHtmlAttributesObjectReturnsCorrectly()
		{
			string name = "Name";
			string value = "Value";
			string attributeValue = "AttributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.BeginButton( name, value, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<button AttributeName=\"{0}\" name=\"{1}\" type=\"button\" value=\"{2}\">", attributeValue, name, value );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithHtmlAttributesDictionaryReturnsCorrectly()
		{
			string name = "Name";
			string value = "Value";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.BeginButton( name, value, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<button {0}=\"{1}\" name=\"{2}\" type=\"button\" value=\"{3}\">", attributeName, attributeValue, name, value );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithAttributeExpressionReturnsCorrectly()
		{
			string name = "Name";
			string value = "Value";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.BeginButton( name, value, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<button {0}=\"{1}\" name=\"{2}\" type=\"button\" value=\"{3}\">", attributeName, attributeValue, name, value );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}
	}
}
