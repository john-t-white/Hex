using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilderTests
{
	[TestClass]
	public class HtmlAttributeBuilder_DropZone
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.DropZone();

			Assert.AreSame( builder, result );
			Assert.AreEqual( DropZoneType.Move.ToString().ToLower(), builder.Attributes[ HtmlAttributes.DropZone ] );
		}

		[TestMethod]
		public void WithSpecifiedValueAddsAttributeCorrectly()
		{
			DropZoneType value = DropZoneType.Copy;

			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.DropZone( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value.ToString().ToLower(), builder.Attributes[ HtmlAttributes.DropZone ] );
		}
	}
}
