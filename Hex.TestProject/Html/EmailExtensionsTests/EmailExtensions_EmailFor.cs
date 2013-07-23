﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;
using System.Collections.Generic;

namespace Hex.TestProject.Html.EmailExtensionsTests
{
	[TestClass]
	public class EmailExtensions_EmailFor
	{
		[TestMethod]
		public void WithExpressionReturnsCorrectly()
		{
			var viewModel = new EmailViewModel( "email@example.com" );

			HtmlHelper<EmailViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.EmailFor( x => x.Email );

			string expectedResult = string.Format( "<input id=\"Email\" name=\"Email\" type=\"email\" value=\"{0}\" />", viewModel.Email );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndHtmlAttributesObjectReturnsCorrectly()
		{
			var viewModel = new EmailViewModel( "email@example.com" );
			string attributeValue = "attributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			HtmlHelper<EmailViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.EmailFor( x => x.Email, htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" id=\"Email\" name=\"Email\" type=\"email\" value=\"{1}\" />", attributeValue, viewModel.Email );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			var viewModel = new EmailViewModel( "email@example.com" );
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			HtmlHelper<EmailViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.EmailFor( x => x.Email, htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"Email\" name=\"Email\" type=\"email\" value=\"{2}\" />", attributeName, attributeValue, viewModel.Email );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionAndAttributeExpressionReturnsCorrectly()
		{
			var viewModel = new EmailViewModel( "email@example.com" );
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			HtmlHelper<EmailViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.EmailFor( x => x.Email, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"Email\" name=\"Email\" type=\"email\" value=\"{2}\" />", attributeName, attributeValue, viewModel.Email );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
