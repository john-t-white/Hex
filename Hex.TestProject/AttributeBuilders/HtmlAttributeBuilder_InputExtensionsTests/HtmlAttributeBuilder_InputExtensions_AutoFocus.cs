using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilder_InputExtensionsTests
{
	[TestClass]
	public class HtmlAttributeBuilder_InputExtensions_AutoFocus
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.AutoFocus();

			Assert.AreSame( builder, result );
			Assert.AreEqual( HtmlAttributes.AutoFocus, builder.Attributes[ HtmlAttributes.AutoFocus ] );
		}

		[TestMethod]
		public void WithTrueAddsAttributeCorrectly()
		{
			bool value = true;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.AutoFocus( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( HtmlAttributes.AutoFocus, builder.Attributes[ HtmlAttributes.AutoFocus ] );
		}

		[TestMethod]
		public void WithFalseDoesNotAddAttribute()
		{
			bool value = false;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.AutoFocus( value );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.AutoFocus ) );
		}

		[TestMethod]
		public void WithFalseRemovesAttributeIfPresent()
		{
			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.AutoFocus( true ).AutoFocus( false );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.AutoFocus ) );
		}
	}
}
