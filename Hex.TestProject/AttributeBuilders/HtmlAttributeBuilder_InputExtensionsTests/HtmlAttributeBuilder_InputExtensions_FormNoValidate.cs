using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilder_InputExtensionsTests
{
	[TestClass]
	public class HtmlAttributeBuilder_InputExtensions_FormNoValidate
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.FormNoValidate();

			Assert.AreSame( builder, result );
			Assert.AreEqual( HtmlAttributes.FormNoValidate, builder.Attributes[ HtmlAttributes.FormNoValidate ] );
		}

		[TestMethod]
		public void WithTrueAddsAttributeCorrectly()
		{
			bool value = true;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.FormNoValidate( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( HtmlAttributes.FormNoValidate, builder.Attributes[ HtmlAttributes.FormNoValidate ] );
		}

		[TestMethod]
		public void WithFalseDoesNotAddAttribute()
		{
			bool value = false;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.FormNoValidate( value );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.FormNoValidate ) );
		}

		[TestMethod]
		public void WithFalseRemovesAttributeIfPresent()
		{
			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.FormNoValidate( true ).FormNoValidate( false );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.FormNoValidate ) );
		}
	}
}
