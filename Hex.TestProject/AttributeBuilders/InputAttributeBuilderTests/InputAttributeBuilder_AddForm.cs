using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.InputAttributeBuilderTests
{
	[TestClass]
	public class InputAttributeBuilder_AddForm
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			string form = "Form";

			InputAttributeBuilderFake builder = new InputAttributeBuilderFake();
			var result = builder.AddForm( form );

			Assert.AreSame( builder, result );

			AttributeValueCollection attributeValues = builder.Attributes[ HtmlAttributes.Form ] as AttributeValueCollection;

			Assert.IsNotNull( attributeValues );
			Assert.AreEqual( form, attributeValues[ 0 ] );
		}

		[TestMethod]
		public void WithMultipleClassesAddsAttributeCorrectly()
		{
			string[] forms = new string[]
			{
				"Form1",
				"Form2"
			};

			InputAttributeBuilderFake builder = new InputAttributeBuilderFake();
			var result = builder.AddForm( forms );

			Assert.AreSame( builder, result );

			AttributeValueCollection attributeValues = builder.Attributes[ HtmlAttributes.Form ] as AttributeValueCollection;

			Assert.IsNotNull( attributeValues );
			CollectionAssert.AreEquivalent( forms, attributeValues );
		}

		[TestMethod]
		public void WithMultipleCallsAppendsAttributeValuesCorrectly()
		{
			string[] forms = new string[]
			{
				"Form1",
				"Form2"
			};

			InputAttributeBuilderFake builder = new InputAttributeBuilderFake();
			var result = builder.AddForm( forms[ 0 ] ).AddForm( forms[ 1 ] );

			Assert.AreSame( builder, result );

			AttributeValueCollection attributeValues = builder.Attributes[ HtmlAttributes.Form ] as AttributeValueCollection;

			Assert.IsNotNull( attributeValues );
			CollectionAssert.AreEquivalent( forms, attributeValues );
		}
	}
}
