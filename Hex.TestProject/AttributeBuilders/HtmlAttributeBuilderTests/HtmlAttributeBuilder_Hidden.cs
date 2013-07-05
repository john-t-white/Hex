using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilderTests
{
	[TestClass]
	public class HtmlAttributeBuilder_Hidden
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.Hidden();

			Assert.AreSame( builder, result );
			Assert.AreEqual( HtmlAttributes.Hidden, builder.Attributes[ HtmlAttributes.Hidden ] );
		}

		[TestMethod]
		public void WithTrueAddsAttributeCorrectly()
		{
			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.Hidden( true );

			Assert.AreSame( builder, result );
			Assert.AreEqual( HtmlAttributes.Hidden, builder.Attributes[ HtmlAttributes.Hidden ] );
		}

		[TestMethod]
		public void WithFalseDoesNotAddAttribute()
		{
			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.Hidden( false );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.Hidden ) );
		}

		[TestMethod]
		public void WithFalseRemovesAttributeIfPresent()
		{
			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.Hidden( true ).Hidden( false );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.Hidden ) );
		}
	}
}
