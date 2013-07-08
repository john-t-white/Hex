using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilder_LinkExtensionsTests
{
	[TestClass]
	public class HtmlAttributeBuilder_LinkExtensions_HrefLang
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			string value = "Value";

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.HrefLang( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value, builder.Attributes[ HtmlAttributes.HrefLang ] );
		}
	}
}
