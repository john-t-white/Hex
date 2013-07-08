using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilderTests
{
	[TestClass]
	public class HtmlAttributeBuilder_TabIndex
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			int value = 1;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.TabIndex( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value, builder.Attributes[ HtmlAttributes.TabIndex ] );
		}
	}
}
