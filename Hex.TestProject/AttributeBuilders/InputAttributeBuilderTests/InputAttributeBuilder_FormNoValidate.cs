using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.InputAttributeBuilderTests
{
	[TestClass]
	public class InputAttributeBuilder_FormNoValidate
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			InputAttributeBuilderFake builder = new InputAttributeBuilderFake();
			var result = builder.FormNoValidate();

			Assert.AreSame( builder, result );
			Assert.AreEqual( HtmlAttributes.FormNoValidate, builder.Attributes[ HtmlAttributes.FormNoValidate ] );
		}

		[TestMethod]
		public void WithTrueAddsAttributeCorrectly()
		{
			bool value = true;

			InputAttributeBuilderFake builder = new InputAttributeBuilderFake();
			var result = builder.FormNoValidate( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( HtmlAttributes.FormNoValidate, builder.Attributes[ HtmlAttributes.FormNoValidate ] );
		}

		[TestMethod]
		public void WithFalseDoesNotAddAttribute()
		{
			bool value = false;

			InputAttributeBuilderFake builder = new InputAttributeBuilderFake();
			var result = builder.FormNoValidate( value );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.FormNoValidate ) );
		}

		[TestMethod]
		public void WithFalseRemovesAttributeIfPresent()
		{
			InputAttributeBuilderFake builder = new InputAttributeBuilderFake();
			var result = builder.FormNoValidate( true ).FormNoValidate( false );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.FormNoValidate ) );
		}
	}
}
