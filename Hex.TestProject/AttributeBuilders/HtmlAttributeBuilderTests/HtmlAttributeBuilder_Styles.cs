using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Hex.Html;

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

			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.Styles( x => x.Style( name, value ) );

			Assert.AreSame( builder, result );

			AttributeNameValueCollection attributeNameValues = builder.Attributes[ HtmlAttributes.Style ] as AttributeNameValueCollection;
			Assert.IsNotNull( attributeNameValues );
			Assert.AreEqual( value, attributeNameValues[ name ] );
		}

		[TestMethod]
		public void WithNullStyleAttributeExpressionReturnsCorrectly()
		{
			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.Styles( null );

			Assert.AreSame( builder, result );
			Assert.AreEqual( 0, builder.Attributes.Count );
		}
	}
}
