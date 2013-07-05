using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.TextAreaAttributeBuilderTests
{
	[TestClass]
	public class TextAreaAttributeBuilder_Wrap
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			TextAreaAttributeBuilder builder = new TextAreaAttributeBuilder();
			var result = builder.Wrap();

			Assert.AreSame( builder, result );
			Assert.AreEqual( WrapType.Hard.ToString().ToLower(), builder.Attributes[ HtmlAttributes.Wrap ] );
		}

		[TestMethod]
		public void WithSpecifiedValueAddsAttributeCorrectly()
		{
			WrapType value = WrapType.Hard;

			TextAreaAttributeBuilder builder = new TextAreaAttributeBuilder();
			var result = builder.Wrap( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value.ToString().ToLower(), builder.Attributes[ HtmlAttributes.Wrap ] );
		}
	}
}
