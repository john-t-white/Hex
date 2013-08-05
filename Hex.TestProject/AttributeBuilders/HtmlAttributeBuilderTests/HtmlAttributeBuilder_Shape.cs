using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilderTests
{
	[TestClass]
	public class HtmlAttributeBuilder_Shape
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			string value = "Value";

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Shape( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value, builder.Attributes[ HtmlAttributes.Shape ] );
		}

		[TestMethod]
		public void WithShapeTypeValueAddsAttributeCorrectly()
		{
			ShapeType value = ShapeType.Circle;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Shape( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value.ToString().ToLower(), builder.Attributes[ HtmlAttributes.Shape ] );
		}
	}
}
