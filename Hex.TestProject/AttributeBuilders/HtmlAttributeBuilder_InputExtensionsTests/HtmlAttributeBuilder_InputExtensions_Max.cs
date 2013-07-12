using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilder_InputExtensionsTests
{
	[TestClass]
	public class HtmlAttributeBuilder_InputExtensions_Max
	{
		[TestMethod]
		public void WithIntValueAddsAttributeCorrectly()
		{
			int value = 1;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Max( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value, builder.Attributes[ HtmlAttributes.Max ] );
		}

		[TestMethod]
		public void WithDateTimeValueAddsAttributeCorrectly()
		{
			DateTime value = new DateTime( 1 );

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Max( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value.ToString( "yyyy-MM-dd" ), builder.Attributes[ HtmlAttributes.Max ] );
		}
	}
}
