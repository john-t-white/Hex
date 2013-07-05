using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.SelectAttributeBuilderTests
{
	[TestClass]
	public class SelectAttributeBuilder_Size
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			int value = 1;

			SelectAttributeBuilderFake builder = new SelectAttributeBuilderFake();
			var result = builder.Size( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value, builder.Attributes[ HtmlAttributes.Size ] );
		}
	}
}
