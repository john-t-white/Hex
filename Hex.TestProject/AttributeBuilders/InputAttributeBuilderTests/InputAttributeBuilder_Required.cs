using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.InputAttributeBuilderTests
{
	[TestClass]
	public class InputAttributeBuilder_Required
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			InputAttributeBuilderFake builder = new InputAttributeBuilderFake();
			var result = builder.Required();

			Assert.AreSame( builder, result );
			Assert.AreEqual( HtmlAttributes.Required, builder.Attributes[ HtmlAttributes.Required ] );
		}

		[TestMethod]
		public void WithTrueAddsAttributeCorrectly()
		{
			bool value = true;

			InputAttributeBuilderFake builder = new InputAttributeBuilderFake();
			var result = builder.Required( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( HtmlAttributes.Required, builder.Attributes[ HtmlAttributes.Required ] );
		}

		[TestMethod]
		public void WithFalseDoesNotAddAttribute()
		{
			bool value = false;

			InputAttributeBuilderFake builder = new InputAttributeBuilderFake();
			var result = builder.Required( value );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.Required ) );
		}

		[TestMethod]
		public void WithFalseRemovesAttributeIfPresent()
		{
			InputAttributeBuilderFake builder = new InputAttributeBuilderFake();
			var result = builder.Required( true ).Required( false );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.Required ) );
		}
	}
}
