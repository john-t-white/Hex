using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilderTests
{
	[TestClass]
	public class HtmlAttributeBuilder_AddMultiValueAttribute
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			string name = "Name";
			string value = "Value";

			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.AddMultiValueAttribute( name, value );

			Assert.AreSame( builder, result );

			AttributeValueCollection attributeValues = builder.Attributes[ name ] as AttributeValueCollection;
			Assert.IsNotNull( attributeValues );
			Assert.AreEqual( value, attributeValues[ 0 ] );
		}

		[TestMethod]
		public void WithMultipleValuesAddsAttributeCorrectly()
		{
			string name = "Name";
			string[] values = new string[]
			{
				"Value1",
				"Value2"
			};

			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.AddMultiValueAttribute( name, values );

			Assert.AreSame( builder, result );

			AttributeValueCollection attributeValues = builder.Attributes[ name ] as AttributeValueCollection;
			Assert.IsNotNull( attributeValues );
			Assert.AreEqual( values[ 0 ], attributeValues[ 0 ] );
			Assert.AreEqual( values[ 1 ], attributeValues[ 1 ] );
		}

		[TestMethod]
		public void WithMultipleCallsAppendsAttributeValuesCorrectly()
		{
			string name = "Name";
			string[] values = new string[]
			{
				"Value1",
				"Value2"
			};

			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.AddMultiValueAttribute( name, values[ 0 ] ).AddMultiValueAttribute( name, values[ 1 ] );

			Assert.AreSame( builder, result );

			AttributeValueCollection attributeValues = builder.Attributes[ name ] as AttributeValueCollection;
			Assert.IsNotNull( attributeValues );
			Assert.AreEqual( values[ 0 ], attributeValues[ 0 ] );
			Assert.AreEqual( values[ 1 ], attributeValues[ 1 ] );
		}

		[TestMethod]
		public void WithNullNameDoesNotAddAttribute()
		{
			string name = null;
			string value = "Value";

			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.AddMultiValueAttribute( name, value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( 0, builder.Attributes.Count );
		}

		[TestMethod]
		public void WithEmptyNameDoesNotAddAttribute()
		{
			string name = string.Empty;
			string value = "Value";

			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.AddMultiValueAttribute( name, value );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( name ) );
		}

		[TestMethod]
		public void WithWhiteSpaceNameDoesNotAddAttribute()
		{
			string name = " ";
			string value = "Value";

			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.AddMultiValueAttribute( name, value );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( name ) );
		}
	}
}
