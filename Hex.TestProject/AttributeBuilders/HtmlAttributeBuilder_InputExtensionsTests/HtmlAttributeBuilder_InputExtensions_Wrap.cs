using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilder_InputExtensionsTests
{
	[TestClass]
	public class HtmlAttributeBuilder_InputExtensions_Wrap
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();

			var result = builder.Wrap();

			Assert.AreSame( builder, result );
			Assert.AreEqual( WrapType.Hard.ToString().ToLower(), builder.Attributes[ HtmlAttributes.Wrap ] );
		}

		[TestMethod]
		public void WithSpecifiedValueAddsAttributeCorrectly()
		{
			WrapType value = WrapType.Hard;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Wrap( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value.ToString().ToLower(), builder.Attributes[ HtmlAttributes.Wrap ] );
		}
	}
}
