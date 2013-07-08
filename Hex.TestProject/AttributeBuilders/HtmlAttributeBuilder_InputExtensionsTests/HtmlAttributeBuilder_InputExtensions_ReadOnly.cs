using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilder_InputExtensionsTests
{
	[TestClass]
	public class HtmlAttributeBuilder_InputExtensions_ReadOnly
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.ReadOnly();

			Assert.AreSame( builder, result );
			Assert.AreEqual( HtmlAttributes.ReadOnly, builder.Attributes[ HtmlAttributes.ReadOnly ] );
		}

		[TestMethod]
		public void WithTrueAddsAttributeCorrectly()
		{
			bool value = true;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.ReadOnly( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( HtmlAttributes.ReadOnly, builder.Attributes[ HtmlAttributes.ReadOnly ] );
		}

		[TestMethod]
		public void WithFalseDoesNotAddAttribute()
		{
			bool value = false;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.ReadOnly( value );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.ReadOnly ) );
		}

		[TestMethod]
		public void WithFalseRemovesAttributeIfPresent()
		{
			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.ReadOnly( true ).ReadOnly( false );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.ReadOnly ) );
		}
	}
}
