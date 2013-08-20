using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilderTests
{
	[TestClass]
	public class HtmlAttributeBuilder_RemoveClass
	{
		[TestMethod]
		public void RemovesClassCorrectly()
		{
			string class1 = "Class1";
			string class2 = "Class2";

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.AddClass( class1, class2 ).RemoveClass( class1 );

			Assert.AreSame( builder, result );

			AttributeValueCollection attributeValues = builder.Attributes[ HtmlAttributes.Class ] as AttributeValueCollection;

			Assert.IsNotNull( attributeValues );
			Assert.AreEqual( 1, attributeValues.Count );
			Assert.AreEqual( class2, attributeValues[ 0 ] );
		}

		[TestMethod]
		public void RemovesMultipleClassesCorrectly()
		{
			string class1 = "Class1";
			string class2 = "Class2";
			string class3 = "Class3";

			string[] classes = new string[]
			{
				class1,
				class2,
				class3
			};

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.AddClass( classes ).RemoveClass( class1, class3 );

			Assert.AreSame( builder, result );

			AttributeValueCollection attributeValues = builder.Attributes[ HtmlAttributes.Class ] as AttributeValueCollection;

			Assert.IsNotNull( attributeValues );
			Assert.AreEqual( 1, attributeValues.Count );
			Assert.AreEqual( class2, attributeValues[ 0 ] );
		}

		[TestMethod]
		public void WithMultipleCallsRemovesClassesCorrectly()
		{
			string class1 = "Class1";
			string class2 = "Class2";
			string class3 = "Class3";

			string[] classes = new string[]
			{
				class1,
				class2,
				class3
			};

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.AddClass( classes ).RemoveClass( class1 ).RemoveClass( class3 );

			Assert.AreSame( builder, result );

			AttributeValueCollection attributeValues = builder.Attributes[ HtmlAttributes.Class ] as AttributeValueCollection;

			Assert.IsNotNull( attributeValues );
			Assert.AreEqual( 1, attributeValues.Count );
			Assert.AreEqual( class2, attributeValues[ 0 ] );
		}

		[TestMethod]
		public void RemovingLastClassRemovesAttributeCorrectly()
		{
			string class1 = "Class1";

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.AddClass( class1 ).RemoveClass( class1 );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.Class ) );
		}

		[TestMethod]
		public void NullClassesReturnsCorrectly()
		{
			string[] classes = null;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.RemoveClass( @classes );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.Class ) );
		}
	}
}
