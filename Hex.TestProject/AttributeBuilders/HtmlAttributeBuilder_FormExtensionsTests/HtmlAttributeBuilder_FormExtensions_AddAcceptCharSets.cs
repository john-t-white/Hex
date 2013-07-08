using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilder_FormExtensionsTests
{
	[TestClass]
	public class HtmlAttributeBuilder_FormExtensions_AddAcceptCharSets
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			string characterSet = "CharacterSet";

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.AddAcceptCharsets( characterSet );

			Assert.AreSame( builder, result );

			AttributeValueCollection attributeValues = builder.Attributes[ HtmlAttributes.AcceptCharset ] as AttributeValueCollection;

			Assert.IsNotNull( attributeValues );
			Assert.AreEqual( characterSet, attributeValues[ 0 ] );
		}

		[TestMethod]
		public void WithMultipleClassesAddsAttributeCorrectly()
		{
			string[] characterSets = new string[]
			{
				"CharacterSet1",
				"CharacterSet2"
			};

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.AddAcceptCharsets( characterSets );

			Assert.AreSame( builder, result );

			AttributeValueCollection attributeValues = builder.Attributes[ HtmlAttributes.AcceptCharset ] as AttributeValueCollection;

			Assert.IsNotNull( attributeValues );
			CollectionAssert.AreEquivalent( characterSets, attributeValues );
		}

		[TestMethod]
		public void WithMultipleCallsAppendsAttributeValuesCorrectly()
		{
			string[] characterSets = new string[]
			{
				"CharacterSet1",
				"CharacterSet2"
			};

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.AddAcceptCharsets( characterSets[ 0 ] ).AddAcceptCharsets( characterSets[ 1 ] );

			Assert.AreSame( builder, result );

			AttributeValueCollection attributeValues = builder.Attributes[ HtmlAttributes.AcceptCharset ] as AttributeValueCollection;

			Assert.IsNotNull( attributeValues );
			CollectionAssert.AreEquivalent( characterSets, attributeValues );
		}
	}
}
