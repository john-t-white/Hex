﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.AttributeBuilders;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.EventAttributeBuilderTests
{
	[TestClass]
	public class EventAttributeBuilder_OnDragEnd
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			string script = "Script";

			var attributes = new AttributeCollection();
			var builder = new EventAttributeBuilder( attributes );

			var result = builder.OnDragEnd( script );

			Assert.AreSame( builder, result );
			Assert.AreEqual( script, attributes[ HtmlAttributes.Events.OnDragEnd ] );
		}
	}
}
