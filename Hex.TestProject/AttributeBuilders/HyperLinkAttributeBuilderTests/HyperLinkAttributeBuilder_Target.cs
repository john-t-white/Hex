using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.HyperLinkAttributeBuilderTests
{
	[TestClass]
	public class HtmlAttributeBuilder_Target
	{
		[TestMethod]
		public void WithTargetTypeAddsAttributeCorrectly()
		{
			TargetType value = TargetType.Blank;

			HyperLinkAttributeBuilderFake builder = new HyperLinkAttributeBuilderFake();
			var result = builder.Target( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( string.Format( "_{0}", value.ToString().ToLower() ), builder.Attributes[ HtmlAttributes.Target ] );
		}

		[TestMethod]
		public void WithStringAddsAttributeCorrectly()
		{
			string value = "Value";

			HyperLinkAttributeBuilderFake builder = new HyperLinkAttributeBuilderFake();
			var result = builder.Target( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value, builder.Attributes[ HtmlAttributes.Target ] );
		}
	}
}
