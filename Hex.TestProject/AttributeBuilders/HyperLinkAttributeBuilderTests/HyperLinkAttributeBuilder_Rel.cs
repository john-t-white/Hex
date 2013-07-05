using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.HyperLinkAttributeBuilderTests
{
	[TestClass]
	public class HtmlAttributeBuilder_Rel
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			RelType value = RelType.Alternate;

			HyperLinkAttributeBuilderFake builder = new HyperLinkAttributeBuilderFake();
			var result = builder.Rel( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value.ToString().ToLower(), builder.Attributes[ HtmlAttributes.Rel ] );
		}
	}
}
