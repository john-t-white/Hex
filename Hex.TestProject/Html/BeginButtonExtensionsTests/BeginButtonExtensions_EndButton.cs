using Hex.Html;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hex.TestProject.Html.BeginButtonExtensionsTests
{
	[TestClass]
	public class BeginButtonExtensions_EndButton
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			htmlHelper.EndButton();

			Assert.AreEqual( "</button>", htmlHelper.ViewContext.Writer.ToString() );
		}
	}
}
