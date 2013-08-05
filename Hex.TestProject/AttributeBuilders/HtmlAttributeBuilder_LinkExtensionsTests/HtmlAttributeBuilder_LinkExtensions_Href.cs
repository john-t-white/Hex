using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilder_LinkExtensionsTests
{
	[TestClass]
	public class HtmlAttributeBuilder_LinkExtensions_Href
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			string url = "http://www.example.com";

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Href( url );

			Assert.AreSame( builder, result );
			Assert.AreEqual( url, builder.Attributes[ HtmlAttributes.Href ] );
		}

		[TestMethod]
		public void WithAbsoluteUriValueAddsAttributeCorrectly()
		{
			string urlAsString = "http://www.example.com";
			Uri url = new Uri( urlAsString, UriKind.Absolute );

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Href( url );

			Assert.AreSame( builder, result );
			Assert.AreEqual( url.OriginalString, builder.Attributes[ HtmlAttributes.Href ] );
		}

		[TestMethod]
		public void WithRelativeUriValueAddsAttributeCorrectly()
		{
			string urlAsString = "/Relative/Path";
			Uri url = new Uri( urlAsString, UriKind.Relative );

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Href( url );

			Assert.AreSame( builder, result );
			Assert.AreEqual( url.OriginalString, builder.Attributes[ HtmlAttributes.Href ] );
		}
	}
}
