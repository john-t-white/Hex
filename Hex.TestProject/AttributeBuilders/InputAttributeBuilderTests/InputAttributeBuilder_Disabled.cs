using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.InputAttributeBuilderTests
{
	[TestClass]
	public class InputAttributeBuilder_Disabled
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			InputAttributeBuilderFake builder = new InputAttributeBuilderFake();
			var result = builder.Disabled();

			Assert.AreSame( builder, result );
			Assert.AreEqual( HtmlAttributes.Disabled, builder.Attributes[ HtmlAttributes.Disabled ] );
		}

		[TestMethod]
		public void WithTrueAddsAttributeCorrectly()
		{
			bool value = true;

			InputAttributeBuilderFake builder = new InputAttributeBuilderFake();
			var result = builder.Disabled( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( HtmlAttributes.Disabled, builder.Attributes[ HtmlAttributes.Disabled ] );
		}

		[TestMethod]
		public void WithFalseDoesNotAddAttribute()
		{
			bool value = false;

			InputAttributeBuilderFake builder = new InputAttributeBuilderFake();
			var result = builder.Disabled( value );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.Disabled ) );
		}

		[TestMethod]
		public void WithFalseRemovesAttributeIfPresent()
		{
			InputAttributeBuilderFake builder = new InputAttributeBuilderFake();
			var result = builder.Disabled( true ).Disabled( false );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.Disabled ) );
		}
	}
}
