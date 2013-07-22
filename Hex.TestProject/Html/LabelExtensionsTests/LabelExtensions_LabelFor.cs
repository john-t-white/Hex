using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;

namespace Hex.TestProject.Html.LabelExtensionsTests
{
	[TestClass]
	public class LabelExtensions_LabelFor
	{
		[TestMethod]
		public void WithExpressionAndAttributeExpressionReturnsCorrectly()
		{
			string labelValue = "LabelValue";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var viewModel = new LabelViewModel( labelValue );

			HtmlHelper<LabelViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.LabelFor( x => x.LabelValue, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<label {0}=\"{1}\" for=\"LabelValue\">LabelValue</label>", attributeName, attributeValue );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionLabelTextAndAttributeExpressionReturnsCorrectly()
		{
			string labelValue = "LabelValue";
			string labelText = "LabelText";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var viewModel = new LabelViewModel( labelValue );

			HtmlHelper<LabelViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.LabelFor( x => x.LabelValue, labelText, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<label {0}=\"{1}\" for=\"LabelValue\">{2}</label>", attributeName, attributeValue, labelText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
