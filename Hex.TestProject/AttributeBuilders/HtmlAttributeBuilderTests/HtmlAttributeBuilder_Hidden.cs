using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilderTests
{
	[TestClass]
	public class HtmlAttributeBuilder_Hidden
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Hidden();

			Assert.AreSame( builder, result );
			Assert.AreEqual( HtmlAttributes.Hidden, builder.Attributes[ HtmlAttributes.Hidden ] );
		}

		[TestMethod]
		public void WithTrueAddsAttributeCorrectly()
		{
			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Hidden( true );

			Assert.AreSame( builder, result );
			Assert.AreEqual( HtmlAttributes.Hidden, builder.Attributes[ HtmlAttributes.Hidden ] );
		}

		[TestMethod]
		public void WithFalseDoesNotAddAttribute()
		{
			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Hidden( false );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.Hidden ) );
		}

		[TestMethod]
		public void WithFalseRemovesAttributeIfPresent()
		{
			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Hidden( true ).Hidden( false );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.Hidden ) );
		}
	}
}
