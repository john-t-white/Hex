﻿using Hex.Html;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Hex.TestProject.Html.ButtonExtensionsTests
{
	[TestClass]
	public class ButtonExtensions_ButtonFor
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			string buttonText = "ButtonText";
			string value = "Value";

			var viewModel = new ButtonViewModel();
			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.ButtonFor( x => x.Button, buttonText, value );

			string expectedResult = string.Format( "<button name=\"Button\" type=\"button\" value=\"{0}\">{1}</button>", value, buttonText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithHtmlAttributesObjectReturnsCorrectly()
		{
			string buttonText = "ButtonText";
			string value = "Value";
			string attributeValue = "AttributeValue";

			var htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			var viewModel = new ButtonViewModel();
			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.ButtonFor( x => x.Button, buttonText, value, htmlAttributes );

			string expectedResult = string.Format( "<button AttributeName=\"{0}\" name=\"Button\" type=\"button\" value=\"{1}\">{2}</button>", attributeValue, value, buttonText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithHtmlAttributesDictionaryReturnsCorrectly()
		{
			string buttonText = "ButtonText";
			string value = "Value";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			var viewModel = new ButtonViewModel();
			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.ButtonFor( x => x.Button, buttonText, value, htmlAttributes );

			string expectedResult = string.Format( "<button {0}=\"{1}\" name=\"Button\" type=\"button\" value=\"{2}\">{3}</button>", attributeName, attributeValue, value, buttonText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithAttributeExpressionReturnsCorrectly()
		{
			string buttonText = "ButtonText";
			string value = "Value";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var viewModel = new ButtonViewModel();
			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.ButtonFor( x => x.Button, buttonText, value, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<button {0}=\"{1}\" name=\"Button\" type=\"button\" value=\"{2}\">{3}</button>", attributeName, attributeValue, value, buttonText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
