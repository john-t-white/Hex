using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.InputAttributeBuilderTests
{
	[TestClass]
	public class InputAttributeBuilder_ReadOnly
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			InputAttributeBuilderFake builder = new InputAttributeBuilderFake();
			var result = builder.ReadOnly();

			Assert.AreSame( builder, result );
			Assert.AreEqual( HtmlAttributes.ReadOnly, builder.Attributes[ HtmlAttributes.ReadOnly ] );
		}

		[TestMethod]
		public void WithTrueAddsAttributeCorrectly()
		{
			bool value = true;

			InputAttributeBuilderFake builder = new InputAttributeBuilderFake();
			var result = builder.ReadOnly( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( HtmlAttributes.ReadOnly, builder.Attributes[ HtmlAttributes.ReadOnly ] );
		}

		[TestMethod]
		public void WithFalseDoesNotAddAttribute()
		{
			bool value = false;

			InputAttributeBuilderFake builder = new InputAttributeBuilderFake();
			var result = builder.ReadOnly( value );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.ReadOnly ) );
		}

		[TestMethod]
		public void WithFalseRemovesAttributeIfPresent()
		{
			InputAttributeBuilderFake builder = new InputAttributeBuilderFake();
			var result = builder.ReadOnly( true ).ReadOnly( false );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.ReadOnly ) );
		}
	}
}
