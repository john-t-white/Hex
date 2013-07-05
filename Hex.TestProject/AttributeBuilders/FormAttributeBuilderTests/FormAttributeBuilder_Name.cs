using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.FormAttributeBuilderTests
{
	[TestClass]
	public class FormAttributeBuilder_Name
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			string name = "Value";

			FormAttributeBuilder builder = new FormAttributeBuilder();
			var result = builder.Name( name );

			Assert.AreSame( builder, result );
			Assert.AreEqual( name, builder.Attributes[ HtmlAttributes.Name ] );
		}
	}
}
