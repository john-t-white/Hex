using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Ajax;

namespace Hex.TestProject.Ajax.BeginLinkExtensionsTests
{
	[TestClass]
	public class BeginLinkExtensions_EndLink
	{
		[TestMethod]
		public void WritesClosingAnchorTag()
		{
			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			ajaxHelper.EndLink();

			Assert.AreEqual( "</a>", ajaxHelper.ViewContext.Writer.ToString() );
		}
	}
}
