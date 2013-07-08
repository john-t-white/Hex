using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilderTests
{
	[TestClass]
	public class HtmlAttributeBuilder_SpellCheck
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.SpellCheck();

			Assert.AreSame( builder, result );
			Assert.AreEqual( true.ToString().ToLower(), builder.Attributes[ HtmlAttributes.SpellCheck ] );
		}

		[TestMethod]
		public void WithSpecifiedValueAddsAttributeCorrectly()
		{
			bool value = false;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.SpellCheck( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value.ToString().ToLower(), builder.Attributes[ HtmlAttributes.SpellCheck ] );
		}
	}
}
