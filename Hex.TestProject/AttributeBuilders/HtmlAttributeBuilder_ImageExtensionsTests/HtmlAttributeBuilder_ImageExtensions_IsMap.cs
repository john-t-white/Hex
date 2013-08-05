using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.AttributeBuilders;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilder_ImageExtensionsTests
{
	[TestClass]
	public class HtmlAttributeBuilder_ImageExtensions_IsMap
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.IsMap();

			Assert.AreSame( builder, result );
			Assert.AreEqual( HtmlAttributes.IsMap, builder.Attributes[ HtmlAttributes.IsMap ] );
		}

		[TestMethod]
		public void WithTrueAddsAttributeCorrectly()
		{
			bool value = true;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.IsMap( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( HtmlAttributes.IsMap, builder.Attributes[ HtmlAttributes.IsMap ] );
		}

		[TestMethod]
		public void WithFalseDoesNotAddAttribute()
		{
			bool value = false;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.IsMap( value );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.IsMap ) );
		}

		[TestMethod]
		public void WithFalseRemovesAttributeIfPresent()
		{
			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.IsMap( true ).IsMap( false );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.IsMap ) );
		}
	}
}
