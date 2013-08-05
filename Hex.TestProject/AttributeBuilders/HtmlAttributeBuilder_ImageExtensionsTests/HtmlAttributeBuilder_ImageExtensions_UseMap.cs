using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.AttributeBuilders;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilder_ImageExtensionsTests
{
	[TestClass]
	public class HtmlAttributeBuilder_ImageExtensions_UseMap
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			string mapName = "MapName";

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.UseMap( mapName );

			Assert.AreSame( builder, result );
			Assert.AreEqual( mapName, builder.Attributes[ HtmlAttributes.UseMap ] );
		}
	}
}
