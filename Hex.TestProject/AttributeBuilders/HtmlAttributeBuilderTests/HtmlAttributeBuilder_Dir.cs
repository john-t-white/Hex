﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilderTests
{
	[TestClass]
	public class HtmlAttributeBuilder_Dir
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			string value = "Value";

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Dir( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value, builder.Attributes[ HtmlAttributes.Dir ] );
		}

		[TestMethod]
		public void WithDirTypeValueAddsAttributeCorrectly()
		{
			DirType value = DirType.Ltr;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Dir( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value.ToString().ToLower(), builder.Attributes[ HtmlAttributes.Dir ] );
		}
	}
}
