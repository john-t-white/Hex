using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilderTests
{
	[TestClass]
	public class HtmlAttributeBuilder_Translate
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Translate();

			Assert.AreSame( builder, result );
			Assert.AreEqual( TranslateType.Yes.ToString().ToLower(), builder.Attributes[ HtmlAttributes.Translate ] );
		}

		[TestMethod]
		public void WithSpecifiedValueAddsAttributeCorrectly()
		{
			TranslateType value = TranslateType.No;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Translate( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value.ToString().ToLower(), builder.Attributes[ HtmlAttributes.Translate ] );
		}
	}
}
