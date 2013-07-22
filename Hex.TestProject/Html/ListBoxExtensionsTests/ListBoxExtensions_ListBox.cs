using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;

namespace Hex.TestProject.Html.ListBoxExtensionsTests
{
	[TestClass]
	public class ListBoxExtensions_ListBox
	{
		[TestMethod]
		public void WithNameAndAttributeExpressionReturnsCorrectly()
		{
			string name = "SelectList";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var viewModel = new ListBoxViewModel();

			HtmlHelper<ListBoxViewModel> htmlHelper = HtmlHelperGenerator.CreateHtmlHelper( viewModel );

			var result = htmlHelper.ListBox( name, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<select {0}=\"{1}\" id=\"{2}\" multiple=\"multiple\" name=\"{2}\"><option value=\"Value1\">Text1</option>\r\n</select>", attributeName, attributeValue, name );
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

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.ListBox( name, selectList, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<select {0}=\"{1}\" id=\"{2}\" multiple=\"multiple\" name=\"{2}\"><option value=\"{3}\">{4}</option>\r\n</select>", attributeName, attributeValue, name, selectListItemValue, selectListItemText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
