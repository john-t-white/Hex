using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;

namespace Hex.TestProject.Html.BeginLinkExtenionsTests
{
	[TestClass]
	public class BeginLinkExtensions_EndLink
	{
		[TestMethod]
		public void WritesClosingAnchorTag()
		{
			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			htmlHelper.EndLink();

			Assert.AreEqual( "</a>", htmlHelper.ViewContext.Writer.ToString() );
		}
	}
}
