using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.InputAttributeBuilderTests
{
	[TestClass]
	public class InputAttributeBuilder_AutoFocus
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			InputAttributeBuilderFake builder = new InputAttributeBuilderFake();
			var result = builder.AutoFocus();

			Assert.AreSame( builder, result );
			Assert.AreEqual( HtmlAttributes.AutoFocus, builder.Attributes[ HtmlAttributes.AutoFocus ] );
		}

		[TestMethod]
		public void WithTrueAddsAttributeCorrectly()
		{
			bool value = true;

			InputAttributeBuilderFake builder = new InputAttributeBuilderFake();
			var result = builder.AutoFocus( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( HtmlAttributes.AutoFocus, builder.Attributes[ HtmlAttributes.AutoFocus ] );
		}

		[TestMethod]
		public void WithFalseDoesNotAddAttribute()
		{
			bool value = false;

			InputAttributeBuilderFake builder = new InputAttributeBuilderFake();
			var result = builder.AutoFocus( value );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.AutoFocus ) );
		}

		[TestMethod]
		public void WithFalseRemovesAttributeIfPresent()
		{
			InputAttributeBuilderFake builder = new InputAttributeBuilderFake();
			var result = builder.AutoFocus( true ).AutoFocus( false );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.AutoFocus ) );
		}
	}
}
