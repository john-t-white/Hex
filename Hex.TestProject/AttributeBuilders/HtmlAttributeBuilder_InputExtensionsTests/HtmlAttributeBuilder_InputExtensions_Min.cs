using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilder_InputExtensionsTests
{
	[TestClass]
	public class HtmlAttributeBuilder_InputExtensions_Min
	{
		[TestMethod]
		public void WithIntValueAddsAttributeCorrectly()
		{
			int value = 1;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Min( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value, builder.Attributes[ HtmlAttributes.Min ] );
		}

		[TestMethod]
		public void WithDateTimeValueAddsAttributeCorrectly()
		{
			DateTime value = new DateTime( 1 );

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Min( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value, builder.Attributes[ HtmlAttributes.Min ] );
		}
	}
}
