using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.FormAttributeBuilderTests
{
	[TestClass]
	public class FormAttributeBuilder_AddAcceptCharsets
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			string characterSet = "CharacterSet";

			FormAttributeBuilder builder = new FormAttributeBuilder();
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

			FormAttributeBuilder builder = new FormAttributeBuilder();
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

			FormAttributeBuilder builder = new FormAttributeBuilder();
			var result = builder.AddAcceptCharsets( characterSets[ 0 ] ).AddAcceptCharsets( characterSets[ 1 ] );

			Assert.AreSame( builder, result );

			AttributeValueCollection attributeValues = builder.Attributes[ HtmlAttributes.AcceptCharset ] as AttributeValueCollection;

			Assert.IsNotNull( attributeValues );
			CollectionAssert.AreEquivalent( characterSets, attributeValues );
		}
	}
}
