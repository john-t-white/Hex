using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilderTests
{
	[TestClass]
	public class HtmlAttributeBuilder_ContentEditable
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.ContentEditable();

			Assert.AreSame( builder, result );
			Assert.AreEqual( ContentEditableType.True.ToString().ToLower(), builder.Attributes[ HtmlAttributes.ContentEditable ] );
		}

		[TestMethod]
		public void WithSpecifiedValueAddsAttributeCorrectly()
		{
			ContentEditableType value = ContentEditableType.False;

			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.ContentEditable( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value.ToString().ToLower(), builder.Attributes[ HtmlAttributes.ContentEditable ] );
		}
	}
}
