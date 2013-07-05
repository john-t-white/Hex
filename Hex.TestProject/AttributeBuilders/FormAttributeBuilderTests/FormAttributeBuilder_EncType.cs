using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.FormAttributeBuilderTests
{
	[TestClass]
	public class FormAttributeBuilder_EncType
	{
		[TestMethod]
		public void MultipartValueAddsAttributeCorrectly()
		{
			EncodingType value = EncodingType.Multipart;

			FormAttributeBuilder builder = new FormAttributeBuilder();
			var result = builder.EncType( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( "multipart/form-data", builder.Attributes[ HtmlAttributes.EncType ] );
		}

		[TestMethod]
		public void PlainValueAddsAttributeCorrectly()
		{
			EncodingType value = EncodingType.Plain;

			FormAttributeBuilder builder = new FormAttributeBuilder();
			var result = builder.EncType( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( "text/plain", builder.Attributes[ HtmlAttributes.EncType ] );
		}

		[TestMethod]
		public void UrlEncodingValueAddsAttributeCorrectly()
		{
			EncodingType value = EncodingType.UrlEncoding;

			FormAttributeBuilder builder = new FormAttributeBuilder();
			var result = builder.EncType( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( "application/x-www-form-urlencoded", builder.Attributes[ HtmlAttributes.EncType ] );
		}
	}
}
