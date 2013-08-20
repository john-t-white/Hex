using Hex.Html;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hex.TestProject.Html.DescriptionExtensionsTests
{
	[TestClass]
	public class DescriptionExtensions_Description
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			var viewModel = new DescriptionViewModel();
			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<DescriptionViewModel>( viewModel );

			var result = htmlHelper.Description( "WithDescription" );

			Assert.IsNotNull( result );
			Assert.AreEqual( "Description", result.ToHtmlString() );
		}

		[TestMethod]
		public void WithoutDescriptionReturnsCorrectly()
		{
			var viewModel = new DescriptionViewModel();
			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<DescriptionViewModel>( viewModel );

			var result = htmlHelper.Description( "WithoutDescription" );

			Assert.IsNotNull( result );
			Assert.AreEqual( string.Empty, result.ToHtmlString() );
		}
	}
}
