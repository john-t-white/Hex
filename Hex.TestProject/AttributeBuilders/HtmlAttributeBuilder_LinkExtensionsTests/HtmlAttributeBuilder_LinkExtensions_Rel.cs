using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilder_LinkExtensionsTests
{
	[TestClass]
	public class HtmlAttributeBuilder_LinkExtensions_Rel
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			RelType value = RelType.Alternate;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Rel( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value.ToString().ToLower(), builder.Attributes[ HtmlAttributes.Rel ] );
		}
	}
}
