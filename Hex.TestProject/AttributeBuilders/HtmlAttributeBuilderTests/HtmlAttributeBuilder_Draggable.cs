using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilderTests
{
	[TestClass]
	public class HtmlAttributeBuilder_Draggable
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Draggable();

			Assert.AreSame( builder, result );
			Assert.AreEqual( DraggableType.True.ToString().ToLower(), builder.Attributes[ HtmlAttributes.Draggable ] );
		}

		[TestMethod]
		public void WithSpecifiedValueAddsAttributeCorrectly()
		{
			DraggableType value = DraggableType.False;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Draggable( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value.ToString().ToLower(), builder.Attributes[ HtmlAttributes.Draggable ] );
		}
	}
}
