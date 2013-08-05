using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.AttributeBuilders;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilder_ImageExtensionsTests
{
	[TestClass]
	public class HtmlAttributeBuilder_ImageExtensions_Src
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			string url = "http://www.example.com";

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Src( url );

			Assert.AreSame( builder, result );
			Assert.AreEqual( url, builder.Attributes[ HtmlAttributes.Src ] );
		}

		[TestMethod]
		public void WithAbsoluteUriValueAddsAttributeCorrectly()
		{
			string urlAsString = "http://www.example.com";
			Uri url = new Uri( urlAsString, UriKind.Absolute );

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Src( url );

			Assert.AreSame( builder, result );
			Assert.AreEqual( url.OriginalString, builder.Attributes[ HtmlAttributes.Src ] );
		}

		[TestMethod]
		public void WithRelativeUriValueAddsAttributeCorrectly()
		{
			string urlAsString = "/Relative/Path";
			Uri url = new Uri( urlAsString, UriKind.Relative );

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.Src( url );

			Assert.AreSame( builder, result );
			Assert.AreEqual( url.OriginalString, builder.Attributes[ HtmlAttributes.Src ] );
		}
	}
}
