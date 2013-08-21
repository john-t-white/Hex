using Hex.Html;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Globalization;

namespace Hex.TestProject.Html.CheckBoxExtensions_WithValueTests
{
	[TestClass]
	public class CheckBoxExtensions_WithValue_CheckBox
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			string name = "Name";
			string checkedValue = "CheckedValue";
			string uncheckedValue = "UncheckedValue";

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.CheckBox( name, checkedValue, uncheckedValue );

			string expectedResult = string.Format( "<input id=\"{0}\" name=\"{0}\" type=\"checkbox\" value=\"{1}\" /><input name=\"{0}\" type=\"hidden\" value=\"{2}\" />", name, checkedValue, uncheckedValue );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentNullException ) )]
		public void WithNullCheckedValueThrowsArgumentNullException()
		{
			string name = "Name";
			string checkedValue = null;
			string uncheckedValue = "UncheckedValue";

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			htmlHelper.CheckBox( name, checkedValue, uncheckedValue );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentNullException ) )]
		public void WithNullUncheckedValueThrowsArgumentNullException()
		{
			string name = "Name";
			string checkedValue = "CheckedValue";
			string uncheckedValue = null;

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			htmlHelper.CheckBox( name, checkedValue, uncheckedValue );
		}

		[TestMethod]
		public void WithHtmlAttributesObjectReturnsCorrectly()
		{
			string name = "Name";
			string checkedValue = "CheckedValue";
			string uncheckedValue = "UncheckedValue";
			string attributeValue = "attributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.CheckBox( name, checkedValue, uncheckedValue, htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" id=\"{1}\" name=\"{1}\" type=\"checkbox\" value=\"{2}\" /><input name=\"{1}\" type=\"hidden\" value=\"{3}\" />", attributeValue, name, checkedValue, uncheckedValue );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithHtmlAttributesDictionaryReturnsCorrectly()
		{
			string name = "Name";
			string checkedValue = "CheckedValue";
			string uncheckedValue = "UncheckedValue";
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.CheckBox( name, checkedValue, uncheckedValue, htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"{2}\" name=\"{2}\" type=\"checkbox\" value=\"{3}\" /><input name=\"{2}\" type=\"hidden\" value=\"{4}\" />", attributeName, attributeValue, name, checkedValue, uncheckedValue );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithAttributeExpressionReturnsCorrectly()
		{
			string name = "Name";
			string checkedValue = "CheckedValue";
			string uncheckedValue = "UncheckedValue";
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.CheckBox( name, checkedValue, uncheckedValue, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"{2}\" name=\"{2}\" type=\"checkbox\" value=\"{3}\" /><input name=\"{2}\" type=\"hidden\" value=\"{4}\" />", attributeName, attributeValue, name, checkedValue, uncheckedValue );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithIsCheckedTrueReturnsCorrectly()
		{
			string name = "Name";
			string checkedValue = "CheckedValue";
			string uncheckedValue = "UncheckedValue";
			bool isChecked = true;

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.CheckBox( name, checkedValue, uncheckedValue, isChecked );

			string expectedResult = string.Format( "<input checked=\"checked\" id=\"{0}\" name=\"{0}\" type=\"checkbox\" value=\"{1}\" /><input name=\"{0}\" type=\"hidden\" value=\"{2}\" />", name, checkedValue, uncheckedValue );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithIsCheckedFalseReturnsCorrectly()
		{
			string name = "Name";
			string checkedValue = "CheckedValue";
			string uncheckedValue = "UncheckedValue";
			bool isChecked = false;

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.CheckBox( name, checkedValue, uncheckedValue, isChecked );

			string expectedResult = string.Format( "<input id=\"{0}\" name=\"{0}\" type=\"checkbox\" value=\"{1}\" /><input name=\"{0}\" type=\"hidden\" value=\"{2}\" />", name, checkedValue, uncheckedValue );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithIsCheckedTrueAndHtmlAttributesObjectReturnsCorrectly()
		{
			string name = "Name";
			string checkedValue = "CheckedValue";
			string uncheckedValue = "UncheckedValue";
			bool isChecked = true;
			string attributeValue = "attributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.CheckBox( name, checkedValue, uncheckedValue, isChecked, htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" checked=\"checked\" id=\"{1}\" name=\"{1}\" type=\"checkbox\" value=\"{2}\" /><input name=\"{1}\" type=\"hidden\" value=\"{3}\" />", attributeValue, name, checkedValue, uncheckedValue );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithIsCheckedTrueAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			string name = "Name";
			string checkedValue = "CheckedValue";
			string uncheckedValue = "UncheckedValue";
			bool isChecked = true;
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.CheckBox( name, checkedValue, uncheckedValue, isChecked, htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" checked=\"checked\" id=\"{2}\" name=\"{2}\" type=\"checkbox\" value=\"{3}\" /><input name=\"{2}\" type=\"hidden\" value=\"{4}\" />", attributeName, attributeValue, name, checkedValue, uncheckedValue );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithIsCheckedTrueAndAttributeExpressionReturnsCorrectly()
		{
			string name = "Name";
			string checkedValue = "CheckedValue";
			string uncheckedValue = "UncheckedValue";
			bool isChecked = true;
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			var result = htmlHelper.CheckBox( name, checkedValue, uncheckedValue, isChecked, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" checked=\"checked\" id=\"{2}\" name=\"{2}\" type=\"checkbox\" value=\"{3}\" /><input name=\"{2}\" type=\"hidden\" value=\"{4}\" />", attributeName, attributeValue, name, checkedValue, uncheckedValue );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithModelStateErrorReturnsCorrectly()
		{
			string name = "Name";
			string checkedValue = "CheckedValue";
			string uncheckedValue = "UncheckedValue";

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			( ( HtmlHelper )htmlHelper ).ViewData.ModelState.AddModelError( name, "ErrorMessage" );

			var result = htmlHelper.CheckBox( name, checkedValue, uncheckedValue );

			string expectedResult = string.Format( "<input class=\"input-validation-error\" id=\"{0}\" name=\"{0}\" type=\"checkbox\" value=\"{1}\" /><input name=\"{0}\" type=\"hidden\" value=\"{2}\" />", name, checkedValue, uncheckedValue );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithIsCheckedTrueAndModelStateWithUncheckedValueReturnsCorrectly()
		{
			string name = "Name";
			string checkedValue = "CheckedValue";
			string uncheckedValue = "UncheckedValue";
			bool isChecked = true;

			ModelState modelState = new ModelState();
			modelState.Value = new ValueProviderResult( uncheckedValue, uncheckedValue, CultureInfo.InvariantCulture );

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			( ( HtmlHelper )htmlHelper ).ViewData.ModelState.Add( name, modelState );

			var result = htmlHelper.CheckBox( name, checkedValue, uncheckedValue, isChecked );

			string expectedResult = string.Format( "<input id=\"{0}\" name=\"{0}\" type=\"checkbox\" value=\"{1}\" /><input name=\"{0}\" type=\"hidden\" value=\"{2}\" />", name, checkedValue, uncheckedValue );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithIsCheckedFalseAndModelStateWithCheckedValueReturnsCorrectly()
		{
			string name = "Name";
			string checkedValue = "CheckedValue";
			string uncheckedValue = "UncheckedValue";
			bool isChecked = false;

			ModelState modelState = new ModelState();
			modelState.Value = new ValueProviderResult( checkedValue, checkedValue, CultureInfo.InvariantCulture );

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			( ( HtmlHelper )htmlHelper ).ViewData.ModelState.Add( name, modelState );

			var result = htmlHelper.CheckBox( name, checkedValue, uncheckedValue, isChecked );

			string expectedResult = string.Format( "<input checked=\"checked\" id=\"{0}\" name=\"{0}\" type=\"checkbox\" value=\"{1}\" /><input name=\"{0}\" type=\"hidden\" value=\"{2}\" />", name, checkedValue, uncheckedValue );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
