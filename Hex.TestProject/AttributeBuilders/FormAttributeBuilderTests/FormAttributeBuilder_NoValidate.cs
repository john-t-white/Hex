using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.FormAttributeBuilderTests
{
	[TestClass]
	public class FormAttributeBuilder_NoValidate
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			FormAttributeBuilder builder = new FormAttributeBuilder();
			var result = builder.NoValidate();

			Assert.AreSame( builder, result );
			Assert.AreEqual( HtmlAttributes.NoValidate, builder.Attributes[ HtmlAttributes.NoValidate ] );
		}

		[TestMethod]
		public void WithTrueAddsAttributeCorrectly()
		{
			bool value = true;

			FormAttributeBuilder builder = new FormAttributeBuilder();
			var result = builder.NoValidate( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( HtmlAttributes.NoValidate, builder.Attributes[ HtmlAttributes.NoValidate ] );
		}

		[TestMethod]
		public void WithFalseDoesNotAddAttribute()
		{
			bool value = false;

			FormAttributeBuilder builder = new FormAttributeBuilder();
			var result = builder.NoValidate( value );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.NoValidate ) );
		}

		[TestMethod]
		public void WithFalseRemovesAttributeIfPresent()
		{
			FormAttributeBuilder builder = new FormAttributeBuilder();
			var result = builder.NoValidate( true ).NoValidate( false );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.NoValidate ) );
		}
	}
}
