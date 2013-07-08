using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilder_InputExtensionsTests
{
	[TestClass]
	public class HtmlAttributeBuilder_InputExtensions_Disabled
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Disabled();

			Assert.AreSame( builder, result );
			Assert.AreEqual( HtmlAttributes.Disabled, builder.Attributes[ HtmlAttributes.Disabled ] );
		}

		[TestMethod]
		public void WithTrueAddsAttributeCorrectly()
		{
			bool value = true;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Disabled( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( HtmlAttributes.Disabled, builder.Attributes[ HtmlAttributes.Disabled ] );
		}

		[TestMethod]
		public void WithFalseDoesNotAddAttribute()
		{
			bool value = false;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Disabled( value );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.Disabled ) );
		}

		[TestMethod]
		public void WithFalseRemovesAttributeIfPresent()
		{
			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Disabled( true ).Disabled( false );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.Disabled ) );
		}
	}
}
