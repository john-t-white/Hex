using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilderTests
{
	[TestClass]
	public class HtmlAttributeBuilder_ContentEditable
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.ContentEditable();

			Assert.AreSame( builder, result );
			Assert.AreEqual( ContentEditableType.True.ToString().ToLower(), builder.Attributes[ HtmlAttributes.ContentEditable ] );
		}

		[TestMethod]
		public void WithSpecifiedValueAddsAttributeCorrectly()
		{
			ContentEditableType value = ContentEditableType.False;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.ContentEditable( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value.ToString().ToLower(), builder.Attributes[ HtmlAttributes.ContentEditable ] );
		}
	}
}
