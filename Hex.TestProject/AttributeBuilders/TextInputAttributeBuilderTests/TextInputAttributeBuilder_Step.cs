using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.TextInputAttributeBuilderTests
{
	[TestClass]
	public class TextInputAttributeBuilder_Step
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			int value = 1;

			TextInputAttributeBuilderFake builder = new TextInputAttributeBuilderFake();
			var result = builder.Step( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value, builder.Attributes[ HtmlAttributes.Step ] );
		}
	}
}
