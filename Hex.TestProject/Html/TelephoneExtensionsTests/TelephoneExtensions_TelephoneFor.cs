using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;
using System.Collections.Generic;

namespace Hex.TestProject.Html.TelephoneExtensionsTests
{
	[TestClass]
	public class TelephoneExtensions_TelephoneFor
	{
		[TestMethod]
		public void WithExpressionReturnsCorrectly()
		{
			var viewModel = new TelephoneViewModel( "(123) 456-7890" );

			HtmlHelper<TelephoneViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.TelephoneFor( x => x.TelephoneNumber );

			string expectedResult = string.Format( "<input id=\"TelephoneNumber\" name=\"TelephoneNumber\" type=\"tel\" value=\"{0}\" />", viewModel.TelephoneNumber );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndHtmlAttributesObjectReturnsCorrectly()
		{
			var viewModel = new TelephoneViewModel( "(123) 456-7890" );
			string attributeValue = "attributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			HtmlHelper<TelephoneViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.TelephoneFor( x => x.TelephoneNumber, htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" id=\"TelephoneNumber\" name=\"TelephoneNumber\" type=\"tel\" value=\"{1}\" />", attributeValue, viewModel.TelephoneNumber );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			var viewModel = new TelephoneViewModel( "(123) 456-7890" );
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			HtmlHelper<TelephoneViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.TelephoneFor( x => x.TelephoneNumber, htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"TelephoneNumber\" name=\"TelephoneNumber\" type=\"tel\" value=\"{2}\" />", attributeName, attributeValue, viewModel.TelephoneNumber );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndAttributeExpressionReturnsCorrectly()
		{
			var viewModel = new TelephoneViewModel( "(123) 456-7890" );
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			HtmlHelper<TelephoneViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.TelephoneFor( x => x.TelephoneNumber, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"TelephoneNumber\" name=\"TelephoneNumber\" type=\"tel\" value=\"{2}\" />", attributeName, attributeValue, viewModel.TelephoneNumber );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
