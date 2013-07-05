using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.TextInputAttributeBuilderTests
{
	[TestClass]
	public class TextInputAttributeBuilder_Max
	{
		[TestMethod]
		public void WithIntValueAddsAttributeCorrectly()
		{
			int value = 1;

			TextInputAttributeBuilderFake builder = new TextInputAttributeBuilderFake();
			var result = builder.Max( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value, builder.Attributes[ HtmlAttributes.Max ] );
		}

		[TestMethod]
		public void WithDateTimeValueAddsAttributeCorrectly()
		{
			DateTime value = new DateTime( 1 );

			TextInputAttributeBuilderFake builder = new TextInputAttributeBuilderFake();
			var result = builder.Max( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value, builder.Attributes[ HtmlAttributes.Max ] );
		}
	}
}
