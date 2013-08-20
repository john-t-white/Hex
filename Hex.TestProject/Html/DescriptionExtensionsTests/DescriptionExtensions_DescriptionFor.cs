using Hex.Html;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Hex.TestProject.Html.DescriptionExtensionsTests
{
	[TestClass]
	public class DescriptionExtensions_DescriptionFor
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			var viewModel = new DescriptionViewModel();
			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<DescriptionViewModel>( viewModel );

			var result = htmlHelper.DescriptionFor( x => x.WithDescription );

			Assert.IsNotNull( result );
			Assert.AreEqual( "Description", result.ToHtmlString() );
		}

		[TestMethod]
		public void WithoutDescriptionReturnsCorrectly()
		{
			var viewModel = new DescriptionViewModel();
			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<DescriptionViewModel>( viewModel );

			var result = htmlHelper.DescriptionFor( x => x.WithoutDescription );

			Assert.IsNotNull( result );
			Assert.AreEqual( string.Empty, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithIEnumerableModelReturnsCorrectly()
		{
			var viewModel = new[] { new DescriptionViewModel() };
			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<IEnumerable<DescriptionViewModel>>( viewModel );

			var result = htmlHelper.DescriptionFor( x => x.WithDescription );

			Assert.IsNotNull( result );
			Assert.AreEqual( "Description", result.ToHtmlString() );
		}

		[TestMethod]
		public void WithIEnumerableModelWithoutDescriptionReturnsCorrectly()
		{
			var viewModel = new[] { new DescriptionViewModel() };
			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<IEnumerable<DescriptionViewModel>>( viewModel );

			var result = htmlHelper.DescriptionFor( x => x.WithoutDescription );

			Assert.IsNotNull( result );
			Assert.AreEqual( string.Empty, result.ToHtmlString() );
		}
	}
}
