using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.HyperLinkAttributeBuilderTests
{
	[TestClass]
	public class HtmlAttributeBuilder_Type
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			string value = "Value";

			HyperLinkAttributeBuilderFake builder = new HyperLinkAttributeBuilderFake();
			var result = builder.Type( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value, builder.Attributes[ HtmlAttributes.Type ] );
		}
	}
}
