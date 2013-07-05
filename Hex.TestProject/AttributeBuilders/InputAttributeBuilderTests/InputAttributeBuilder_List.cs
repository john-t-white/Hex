using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.InputAttributeBuilderTests
{
	[TestClass]
	public class InputAttributeBuilder_List
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			string value = "Value";

			InputAttributeBuilderFake builder = new InputAttributeBuilderFake();
			var result = builder.List( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value, builder.Attributes[ HtmlAttributes.List ] );
		}
	}
}
