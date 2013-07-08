using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilderTests
{
	[TestClass]
	public class HtmlAttributeBuilder_Data
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			string name = "Name";
			string value = "Value";

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Data( name, value );

			string expectedAttributeName = string.Format( "data-{0}", name );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value, builder.Attributes[ expectedAttributeName ] );
		}

		[TestMethod]
		public void WithNullNameDoesNotAddAttribute()
		{
			string name = null;
			string value = "Value";

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Data( name, value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( 0, builder.Attributes.Count );
		}

		[TestMethod]
		public void WithEmptyNameDoesNotAddAttribute()
		{
			string name = string.Empty;
			string value = "Value";

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Data( name, value );

			string expectedAttributeName = string.Format( "data-{0}", name );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( expectedAttributeName ) );
		}

		[TestMethod]
		public void WithWhiteSpaceNameDoesNotAddAttribute()
		{
			string name = " ";
			string value = "Value";

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Data( name, value );

			string expectedAttributeName = string.Format( "data-{0}", name );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( expectedAttributeName ) );
		}
	}
}
