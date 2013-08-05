using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.AttributeBuilders;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilder_ImageExtensionsTests
{
	[TestClass]
	public class HtmlAttributeBuilder_ImageExtensions_CrossOrigin
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			string value = "Value";

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.CrossOrigin( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value, builder.Attributes[ HtmlAttributes.CrossOrigin ] );
		}

		[TestMethod]
		public void WithCrossOriginTypeValueAddsAttributeCorrectly()
		{
			CrossOriginType value = CrossOriginType.Use_Credentials;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.CrossOrigin( value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( "use-credentials", builder.Attributes[ HtmlAttributes.CrossOrigin ] );
		}
	}
}
