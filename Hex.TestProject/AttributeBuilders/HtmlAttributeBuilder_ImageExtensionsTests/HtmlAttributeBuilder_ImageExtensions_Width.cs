using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.AttributeBuilders;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilder_ImageExtensionsTests
{
	[TestClass]
	public class HtmlAttributeBuilder_ImageExtensions_Width
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			int value = 20;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Width( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value, builder.Attributes[ HtmlAttributes.Width ] );
		}
	}
}
