using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;
using System.Collections.Generic;

namespace Hex.TestProject.Html.AttributesExtensionsTests
{
	[TestClass]
	public class AttributesExtensions_Attributes
	{
		[TestMethod]
		public void WithHtmlAttributesObjectReturnsCorrectly()
		{
			string attributeValue1 = "AttributeValue1";
			string attributeValue2 = "AttributeValue2";

			object htmlAttributes = new
			{
				AttributeName1 = attributeValue1,
				AttributeName2 = attributeValue2
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.Attributes( htmlAttributes );

			string expectedResult = string.Format( "AttributeName1=\"{0}\" AttributeName2=\"{1}\"", attributeValue1, attributeValue2 );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithHtmlAttributesDictionaryReturnsCorrectly()
		{
			string attributeName1 = "AttributeName1";
			string attributeValue1 = "AttributeValue1";

			string attributeName2 = "AttributeName2";
			string attributeValue2 = "AttributeValue2";

			Dictionary<string, object> htmlAttributes = new Dictionary<string,object>();
			htmlAttributes.Add( attributeName1, attributeValue1 );
			htmlAttributes.Add( attributeName2, attributeValue2 );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.Attributes( htmlAttributes );

			string expectedResult = string.Format( "{0}=\"{1}\" {2}=\"{3}\"", attributeName1, attributeValue1, attributeName2, attributeValue2 );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNullHtmlAttributesDictionaryReturnsCorrectly()
		{
			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			Dictionary<string, object> htmlAttributes = null;
			var result = htmlHelper.Attributes( htmlAttributes );

			Assert.AreEqual( string.Empty, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithAttributeExpressionReturnsCorrectly()
		{
			string attributeName1 = "AttributeName1";
			string attributeValue1 = "AttributeValue1";

			string attributeName2 = "AttributeName2";
			string attributeValue2 = "AttributeValue2";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.Attributes( x => x.Attribute( attributeName1, attributeValue1 ).Attribute( attributeName2, attributeValue2 ) );

			string expectedResult = string.Format( "{0}=\"{1}\" {2}=\"{3}\"", attributeName1, attributeValue1, attributeName2, attributeValue2 );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void EncodesAndReturnsCorrectly()
		{
			string attributeName1 = "AttributeName1";
			string attributeValue1 = "\"AttributeValue1\"";

			string attributeName2 = "AttributeName2";
			string attributeValue2 = "\"AttributeValue2\"";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.Attributes( x => x.Attribute( attributeName1, attributeValue1 ).Attribute( attributeName2, attributeValue2 ) );

			string expectedResult = string.Format( "{0}=\"{1}\" {2}=\"{3}\"", attributeName1, htmlHelper.AttributeEncode( attributeValue1 ), attributeName2, htmlHelper.AttributeEncode( attributeValue2 ) );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
