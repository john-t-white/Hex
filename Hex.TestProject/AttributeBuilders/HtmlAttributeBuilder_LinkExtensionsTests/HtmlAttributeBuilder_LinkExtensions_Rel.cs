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
			string rel = "Alternate";

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Rel( rel );

			Assert.AreSame( builder, result );
			Assert.AreEqual( rel, builder.Attributes[ HtmlAttributes.Rel ] );
		}

		[TestMethod]
		public void WithRelTypeValueAddsAttributeCorrectly()
		{
			RelType rel = RelType.Alternate;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Rel( rel );

			Assert.AreSame( builder, result );
			Assert.AreEqual( rel.ToString().ToLower(), builder.Attributes[ HtmlAttributes.Rel ] );
		}
	}
}
