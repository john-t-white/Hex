using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;

namespace Hex.TestProject.Html.DropDownListExtensionsTests
{
	[TestClass]
	public class DropDownListExtensions_DropDownListFor
	{
		[TestMethod]
		public void WithExpressionAndAttributeExpressionReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var viewModel = new DropDownListViewModel();

			HtmlHelper<DropDownListViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.DropDownListFor( x => x.DropDownList, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<select {0}=\"{1}\" id=\"DropDownList\" name=\"DropDownList\"><option value=\"Value1\">Text1</option>\r\n</select>", attributeName, attributeValue );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionOptionLabelAndAttributeExpressionReturnsCorrectly()
		{
			string optionLabel = "OptionLabel";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var viewModel = new DropDownListViewModel();

			HtmlHelper<DropDownListViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.DropDownListFor( x => x.DropDownList, optionLabel, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<select {0}=\"{1}\" id=\"DropDownList\" name=\"DropDownList\"><option value=\"\">OptionLabel</option>\r\n<option value=\"Value1\">Text1</option>\r\n</select>", attributeName, attributeValue );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionSelectListAndAttributeExpressionReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string selectListItemText = "Text1";
			string selectListItemValue = "Value1";

			SelectListItem[] selectList = new SelectListItem[]
			{
				new SelectListItem()
					{
						Text = selectListItemText,
						Value = selectListItemValue
					}
			};

			var viewModel = new DropDownListViewModel();

			HtmlHelper<DropDownListViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.DropDownListFor( x => x.SelectedValue, selectList, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<select {0}=\"{1}\" id=\"SelectedValue\" name=\"SelectedValue\"><option value=\"{2}\">{3}</option>\r\n</select>", attributeName, attributeValue, selectListItemValue, selectListItemText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithExpressionSelectListOptionLabelAndAttributeExpressionReturnsCorrectly()
		{
			string optionLabel = "OptionLabel";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string selectListItemText = "Text1";
			string selectListItemValue = "Value1";

			SelectListItem[] selectList = new SelectListItem[]
			{
				new SelectListItem()
					{
						Text = selectListItemText,
						Value = selectListItemValue
					}
			};

			var viewModel = new DropDownListViewModel();

			HtmlHelper<DropDownListViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.DropDownListFor( x => x.SelectedValue, selectList, optionLabel, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<select {0}=\"{1}\" id=\"SelectedValue\" name=\"SelectedValue\"><option value=\"\">OptionLabel</option>\r\n<option value=\"{2}\">{3}</option>\r\n</select>", attributeName, attributeValue, selectListItemValue, selectListItemText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
