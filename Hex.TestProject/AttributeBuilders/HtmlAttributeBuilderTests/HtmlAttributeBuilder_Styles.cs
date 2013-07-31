using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilderTests
{
	[TestClass]
	public class HtmlAttributeBuilder_Styles
	{
		[TestMethod]
		public void AddsStyleAttributeCorrectly()
		{
			string name = "Name";
			string value = "Value";

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Styles( x => x.Style( name, value ) );

			Assert.AreSame( builder, result );

			StyleCollection styles = builder.Attributes[ HtmlAttributes.Style ] as StyleCollection;
			Assert.IsNotNull( styles );
			Assert.AreEqual( value, styles[ name ] );
		}

		[TestMethod]
		public void WithNullStyleAttributeExpressionReturnsCorrectly()
		{
			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Styles( null );

			Assert.AreSame( builder, result );
			Assert.AreEqual( 0, builder.Attributes.Count );
		}
	}
}
