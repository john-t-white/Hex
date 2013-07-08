using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilderTests
{
	[TestClass]
	public class HtmlAttributeBuilder_Attribute
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			string name = "Name";
			string value = "Value";

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Attribute( name, value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value, builder.Attributes[ name ] );
		}

		[TestMethod]
		public void WithNullNameDoesNotAddAttribute()
		{
			string name = null;
			string value = "Value";

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Attribute( name, value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( 0, builder.Attributes.Count );
		}

		[TestMethod]
		public void WithEmptyNameDoesNotAddAttribute()
		{
			string name = string.Empty;
			string value = "Value";

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Attribute( name, value );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( name ) );
		}

		[TestMethod]
		public void WithWhiteSpaceNameDoesNotAddAttribute()
		{
			string name = " ";
			string value = "Value";

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Attribute( name, value );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( name ) );
		}
	}
}
