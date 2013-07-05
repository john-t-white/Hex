using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using System.Text.RegularExpressions;

namespace Hex.TestProject.AttributeBuilders.TextInputAttributeBuilderTests
{
	[TestClass]
	public class TextInputAttributeBuilder_Pattern
	{
		[TestMethod]
		public void WithRegexValueAddsAttributeCorrectly()
		{
			Regex value = new Regex( "Regex" );

			TextInputAttributeBuilderFake builder = new TextInputAttributeBuilderFake();
			var result = builder.Pattern( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value.ToString(), builder.Attributes[ HtmlAttributes.Pattern ] );
		}

		[TestMethod]
		public void WithNullRegexValueDoesNotAddAttribute()
		{
			Regex value = null;

			TextInputAttributeBuilderFake builder = new TextInputAttributeBuilderFake();
			var result = builder.Pattern( value );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.Pattern ) );
		}

		[TestMethod]
		public void WithStringValueAddsAttributeCorrectly()
		{
			string value = "Value";

			TextInputAttributeBuilderFake builder = new TextInputAttributeBuilderFake();
			var result = builder.Pattern( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value, builder.Attributes[ HtmlAttributes.Pattern ] );
		}
	}
}
