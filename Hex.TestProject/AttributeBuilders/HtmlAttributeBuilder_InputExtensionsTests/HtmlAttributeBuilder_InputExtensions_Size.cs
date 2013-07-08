using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilder_InputExtensionsTests
{
	[TestClass]
	public class HtmlAttributeBuilder_InputExtensions_Size
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			int value = 1;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Size( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value, builder.Attributes[ HtmlAttributes.Size ] );
		}
	}
}
