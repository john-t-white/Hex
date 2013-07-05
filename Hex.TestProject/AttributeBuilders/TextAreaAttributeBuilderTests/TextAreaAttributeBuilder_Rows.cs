using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.TextAreaAttributeBuilderTests
{
	[TestClass]
	public class TextAreaAttributeBuilder_Rows
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			int value = 1;

			TextAreaAttributeBuilder builder = new TextAreaAttributeBuilder();
			var result = builder.Rows( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value, builder.Attributes[ HtmlAttributes.Rows ] );
		}
	}
}
