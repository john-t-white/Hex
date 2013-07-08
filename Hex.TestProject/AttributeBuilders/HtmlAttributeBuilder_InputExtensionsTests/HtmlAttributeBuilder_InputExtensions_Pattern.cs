using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using System.Text.RegularExpressions;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilder_InputExtensionsTests
{
	[TestClass]
	public class HtmlAttributeBuilder_InputExtensions_Pattern
	{
		[TestMethod]
		public void WithRegexValueAddsAttributeCorrectly()
		{
			Regex value = new Regex( "Regex" );

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Pattern( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value.ToString(), builder.Attributes[ HtmlAttributes.Pattern ] );
		}

		[TestMethod]
		public void WithNullRegexValueDoesNotAddAttribute()
		{
			Regex value = null;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Pattern( value );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.Pattern ) );
		}

		[TestMethod]
		public void WithStringValueAddsAttributeCorrectly()
		{
			string value = "Value";

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Pattern( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value, builder.Attributes[ HtmlAttributes.Pattern ] );
		}
	}
}
