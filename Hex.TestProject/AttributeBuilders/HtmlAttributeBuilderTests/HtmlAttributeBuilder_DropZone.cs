using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilderTests
{
	[TestClass]
	public class HtmlAttributeBuilder_DropZone
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.DropZone();

			Assert.AreSame( builder, result );
			Assert.AreEqual( DropZoneType.Move.ToString().ToLower(), builder.Attributes[ HtmlAttributes.DropZone ] );
		}

		[TestMethod]
		public void WithSpecifiedValueAddsAttributeCorrectly()
		{
			DropZoneType value = DropZoneType.Copy;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.DropZone( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value.ToString().ToLower(), builder.Attributes[ HtmlAttributes.DropZone ] );
		}
	}
}
