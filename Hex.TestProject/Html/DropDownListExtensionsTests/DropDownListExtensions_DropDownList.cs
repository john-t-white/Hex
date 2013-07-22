using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;

namespace Hex.TestProject.Html.DropDownListExtensionsTests
{
	[TestClass]
	public class DropDownListExtensions_DropDownList
	{
		[TestMethod]
		public void WithNameAndAttributeExpressionReturnsCorrectly()
		{
			string name = "DropDownList";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var viewModel = new DropDownListViewModel();

			HtmlHelper<DropDownListViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.DropDownList( name, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<select {0}=\"{1}\" id=\"{2}\" name=\"{2}\"><option value=\"Value1\">Text1</option>\r\n</select>", attributeName, attributeValue, name );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameOptionLabelAndAttributeExpressionReturnsCorrectly()
		{
			string name = "DropDownList";
			string optionLabel = "OptionLabel";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var viewModel = new DropDownListViewModel();

			HtmlHelper<DropDownListViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.DropDownList( name, optionLabel, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<select {0}=\"{1}\" id=\"{2}\" name=\"{2}\"><option value=\"\">OptionLabel</option>\r\n<option value=\"Value1\">Text1</option>\r\n</select>", attributeName, attributeValue, name );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameSelectListAndAttributeExpressionReturnsCorrectly()
		{
			string name = "DropDownList";
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

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.DropDownList( name, selectList, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<select {0}=\"{1}\" id=\"{2}\" name=\"{2}\"><option value=\"{3}\">{4}</option>\r\n</select>", attributeName, attributeValue, name, selectListItemValue, selectListItemText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameSelectListOptionLabelAndAttributeExpressionReturnsCorrectly()
		{
			string name = "DropDownList";
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

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.DropDownList( name, selectList, optionLabel, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<select {0}=\"{1}\" id=\"{2}\" name=\"{2}\"><option value=\"\">OptionLabel</option>\r\n<option value=\"{3}\">{4}</option>\r\n</select>", attributeName, attributeValue, name, selectListItemValue, selectListItemText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
