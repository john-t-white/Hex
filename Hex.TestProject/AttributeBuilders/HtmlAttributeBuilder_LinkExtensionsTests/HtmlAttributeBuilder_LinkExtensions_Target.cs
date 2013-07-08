using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilder_LinkExtensionsTests
{
	[TestClass]
	public class HtmlAttributeBuilder_LinkExtensions_Target
	{
		[TestMethod]
		public void WithTargetTypeAddsAttributeCorrectly()
		{
			TargetType value = TargetType.Blank;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Target( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( string.Format( "_{0}", value.ToString().ToLower() ), builder.Attributes[ HtmlAttributes.Target ] );
		}

		[TestMethod]
		public void WithStringAddsAttributeCorrectly()
		{
			string value = "Value";

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Target( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value, builder.Attributes[ HtmlAttributes.Target ] );
		}
	}
}
