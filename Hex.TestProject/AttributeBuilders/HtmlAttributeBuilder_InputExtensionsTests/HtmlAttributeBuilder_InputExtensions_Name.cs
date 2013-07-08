using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilder_InputExtensionsTests
{
	[TestClass]
	public class HtmlAttributeBuilder_InputExtensions_Name
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			string name = "Value";

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Name( name );

			Assert.AreSame( builder, result );
			Assert.AreEqual( name, builder.Attributes[ HtmlAttributes.Name ] );
		}
	}
}
