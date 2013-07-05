using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilderTests
{
	[TestClass]
	public class HtmlAttributeBuilder_Dir
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			DirType value = DirType.Ltr;

			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.Dir( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value.ToString().ToLower(), builder.Attributes[ HtmlAttributes.Dir ] );
		}
	}
}
