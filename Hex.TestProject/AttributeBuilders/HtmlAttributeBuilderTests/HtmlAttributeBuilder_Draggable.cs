using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilderTests
{
	[TestClass]
	public class HtmlAttributeBuilder_Draggable
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.Draggable();

			Assert.AreSame( builder, result );
			Assert.AreEqual( DraggableType.True.ToString().ToLower(), builder.Attributes[ HtmlAttributes.Draggable ] );
		}

		[TestMethod]
		public void WithSpecifiedValueAddsAttributeCorrectly()
		{
			DraggableType value = DraggableType.False;

			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.Draggable( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value.ToString().ToLower(), builder.Attributes[ HtmlAttributes.Draggable ] );
		}
	}
}
