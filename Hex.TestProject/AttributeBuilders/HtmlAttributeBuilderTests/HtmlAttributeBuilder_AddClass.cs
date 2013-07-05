using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilderTests
{
	[TestClass]
	public class HtmlAttributeBuilder_AddClass
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			string @class = "class";

			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.AddClass( @class );

			Assert.AreSame( builder, result );

			AttributeValueCollection attributeValues = builder.Attributes[ HtmlAttributes.Class ] as AttributeValueCollection;

			Assert.IsNotNull( attributeValues );
			Assert.AreEqual( @class, attributeValues[ 0 ] );
		}

		[TestMethod]
		public void WithMultipleClassesAddsAttributeCorrectly()
		{
			string[] classes = new string[]
			{
				"Class1",
				"Class2"
			};

			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.AddClass( classes );

			Assert.AreSame( builder, result );

			AttributeValueCollection attributeValues = builder.Attributes[ HtmlAttributes.Class ] as AttributeValueCollection;
			
			Assert.IsNotNull( attributeValues );
			CollectionAssert.AreEquivalent( classes, attributeValues );
		}

		[TestMethod]
		public void WithMultipleCallsAppendsAttributeValuesCorrectly()
		{
			string[] classes = new string[]
			{
				"Class1",
				"Class2"
			};

			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.AddClass( classes[ 0 ] ).AddClass( classes[ 1 ] );

			Assert.AreSame( builder, result );

			AttributeValueCollection attributeValues = builder.Attributes[ HtmlAttributes.Class ] as AttributeValueCollection;

			Assert.IsNotNull( attributeValues );
			CollectionAssert.AreEquivalent( classes, attributeValues );
		}
	}
}
