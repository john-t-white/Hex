using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilderTests
{
	[TestClass]
	public class HtmlAttributeBuilder_Events
	{
		[TestMethod]
		public void AddsEventAttributeCorrectly()
		{
			string name = "Name";
			string value = "Value";

			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.Events( x => x.Event( name, value ) );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value, builder.Attributes[ name ] );
		}

		[TestMethod]
		public void WithNullEventAttributeExpressionReturnsCorrectly()
		{
			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.Events( null );

			Assert.AreSame( builder, result );
			Assert.AreEqual( 0, builder.Attributes.Count );
		}
	}
}
