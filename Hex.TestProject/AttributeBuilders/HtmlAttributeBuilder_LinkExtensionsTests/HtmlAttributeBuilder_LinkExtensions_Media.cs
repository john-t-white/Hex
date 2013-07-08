using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilder_LinkExtensionsTests
{
	[TestClass]
	public class HtmlAttributeBuilder_LinkExtensions_Media
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			string value = "Value";

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Media( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value, builder.Attributes[ HtmlAttributes.Media ] );
		}
	}
}
