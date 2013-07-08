using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilder_FormExtensionsTests
{
	[TestClass]
	public class HtmlAttributeBuilder_FormExtensions_NoValidate
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.NoValidate();

			Assert.AreSame( builder, result );
			Assert.AreEqual( HtmlAttributes.NoValidate, builder.Attributes[ HtmlAttributes.NoValidate ] );
		}

		[TestMethod]
		public void WithTrueAddsAttributeCorrectly()
		{
			bool value = true;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.NoValidate( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( HtmlAttributes.NoValidate, builder.Attributes[ HtmlAttributes.NoValidate ] );
		}

		[TestMethod]
		public void WithFalseDoesNotAddAttribute()
		{
			bool value = false;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.NoValidate( value );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.NoValidate ) );
		}

		[TestMethod]
		public void WithFalseRemovesAttributeIfPresent()
		{
			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.NoValidate( true ).NoValidate( false );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.NoValidate ) );
		}
	}
}
