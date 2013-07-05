using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.TextInputAttributeBuilderTests
{
	[TestClass]
	public class TextInputAttributeBuilder_PlaceHolder
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			string value = "Value";

			TextInputAttributeBuilderFake builder = new TextInputAttributeBuilderFake();
			var result = builder.PlaceHolder( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value, builder.Attributes[ HtmlAttributes.PlaceHolder ] );
		}
	}
}
