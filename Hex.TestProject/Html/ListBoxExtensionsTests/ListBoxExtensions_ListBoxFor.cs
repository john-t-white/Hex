using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;

namespace Hex.TestProject.Html.ListBoxExtensionsTests
{
	[TestClass]
	public class ListBoxExtensions_ListBoxFor
	{
		[TestMethod]
		public void WithNameAndAttributeExpressionReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var viewModel = new ListBoxViewModel();

			HtmlHelper<ListBoxViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.ListBoxFor( x => x.SelectList, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<select {0}=\"{1}\" id=\"SelectList\" multiple=\"multiple\" name=\"SelectList\"><option value=\"Value1\">Text1</option>\r\n</select>", attributeName, attributeValue );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameSelectListAndAttributeExpressionReturnsCorrectly()
		{
			string name = "SelectList";
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

			var viewModel = new ListBoxViewModel( selectListItemValue );

			HtmlHelper<ListBoxViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.ListBoxFor( x => x.SelectedValues, selectList, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<select {0}=\"{1}\" id=\"SelectedValues\" multiple=\"multiple\" name=\"SelectedValues\"><option selected=\"selected\" value=\"{2}\">{3}</option>\r\n</select>", attributeName, attributeValue, selectListItemValue, selectListItemText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
