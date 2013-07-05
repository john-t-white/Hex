using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilderTests
{
	[TestClass]
	public class HtmlAttributeBuilder_ContextMenu
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			string elementId = "ElementId";

			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.ContextMenu( elementId );

			Assert.AreSame( builder, result );
			Assert.AreEqual( elementId, builder.Attributes[ HtmlAttributes.ContextMenu ] );
		}
	}
}
