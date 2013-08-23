using Hex.Html;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Globalization;

namespace Hex.TestProject.Html.CheckBoxListItemExtensionsTests
{
	[TestClass]
	public class CheckBoxListItemExtensions_CheckBoxListItem
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			string name = "Name";
			string value = "Value One";

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.CheckBoxListItem( name, value );

			string expectedId = string.Format( "{0}_{1}", name, value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input name=\"{0}.CheckBoxList\" type=\"hidden\" value=\"\" /><input id=\"{1}\" name=\"{0}\" type=\"checkbox\" value=\"{2}\" />", name, expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentNullException ) )]
		public void WithNullValueThrowsArgumentNullException()
		{
			string name = "Name";
			string value = null;

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			htmlHelper.CheckBoxListItem( name, value );
		}

		[TestMethod]
		public void WithHtmlAttributesObjectReturnsCorrectly()
		{
			string name = "Name";
			string value = "Value One";
			string attributeValue = "AttributeValue";

			var htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.CheckBoxListItem( name, value, htmlAttributes );

			string expectedId = string.Format( "{0}_{1}", name, value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input name=\"{0}.CheckBoxList\" type=\"hidden\" value=\"\" /><input AttributeName=\"{1}\" id=\"{2}\" name=\"{0}\" type=\"checkbox\" value=\"{3}\" />", name, attributeValue, expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithHtmlAttributesDictionaryReturnsCorrectly()
		{
			string name = "Name";
			string value = "Value One";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.CheckBoxListItem( name, value, htmlAttributes );

			string expectedId = string.Format( "{0}_{1}", name, value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input name=\"{0}.CheckBoxList\" type=\"hidden\" value=\"\" /><input {1}=\"{2}\" id=\"{3}\" name=\"{0}\" type=\"checkbox\" value=\"{4}\" />", name, attributeName, attributeValue, expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithAttributeExpressionReturnsCorrectly()
		{
			string name = "Name";
			string value = "Value One";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.CheckBoxListItem( name, value, x => x.Attribute( attributeName, attributeValue ) );

			string expectedId = string.Format( "{0}_{1}", name, value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input name=\"{0}.CheckBoxList\" type=\"hidden\" value=\"\" /><input {1}=\"{2}\" id=\"{3}\" name=\"{0}\" type=\"checkbox\" value=\"{4}\" />", name, attributeName, attributeValue, expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithSelectedValuesContainsValueReturnsCorrectly()
		{
			string name = "Name";
			string value = "Value One";

			string[] selectedValues =
			{
				value,
				"Value Two"
			};

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.CheckBoxListItem( name, value, selectedValues );

			string expectedId = string.Format( "{0}_{1}", name, value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input name=\"{0}.CheckBoxList\" type=\"hidden\" value=\"\" /><input checked=\"checked\" id=\"{1}\" name=\"{0}\" type=\"checkbox\" value=\"{2}\" />", name, expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithSelectedValuesDoesNotContainValueReturnsCorrectly()
		{
			string name = "Name";
			string value = "Value One";

			string[] selectedValues =
			{
				"Value Two",
				"Value Three"
			};

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.CheckBoxListItem( name, value, selectedValues );

			string expectedId = string.Format( "{0}_{1}", name, value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input name=\"{0}.CheckBoxList\" type=\"hidden\" value=\"\" /><input id=\"{1}\" name=\"{0}\" type=\"checkbox\" value=\"{2}\" />", name, expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithSelectedValuesAndHtmlAttributesObjectReturnsCorrectly()
		{
			string name = "Name";
			string value = "Value One";

			string[] selectedValues =
			{
				value,
				"Value Two"
			};

			string attributeValue = "AttributeValue";

			var htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.CheckBoxListItem( name, value, selectedValues, htmlAttributes );

			string expectedId = string.Format( "{0}_{1}", name, value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input name=\"{0}.CheckBoxList\" type=\"hidden\" value=\"\" /><input AttributeName=\"{1}\" checked=\"checked\" id=\"{2}\" name=\"{0}\" type=\"checkbox\" value=\"{3}\" />", name, attributeValue, expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithSelectedValuesAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			string name = "Name";
			string value = "Value One";

			string[] selectedValues =
			{
				value,
				"Value Two"
			};

			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.CheckBoxListItem( name, value, selectedValues, htmlAttributes );

			string expectedId = string.Format( "{0}_{1}", name, value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input name=\"{0}.CheckBoxList\" type=\"hidden\" value=\"\" /><input {1}=\"{2}\" checked=\"checked\" id=\"{3}\" name=\"{0}\" type=\"checkbox\" value=\"{4}\" />", name, attributeName, attributeValue, expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithSelectedValuesAndAttributeExpressionReturnsCorrectly()
		{
			string name = "Name";
			string value = "Value One";

			string[] selectedValues =
			{
				value,
				"Value Two"
			};

			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.CheckBoxListItem( name, value, selectedValues, x => x.Attribute( attributeName, attributeValue ) );

			string expectedId = string.Format( "{0}_{1}", name, value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input name=\"{0}.CheckBoxList\" type=\"hidden\" value=\"\" /><input {1}=\"{2}\" checked=\"checked\" id=\"{3}\" name=\"{0}\" type=\"checkbox\" value=\"{4}\" />", name, attributeName, attributeValue, expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithModelStateReturnsCorrectly()
		{
			string name = "Name";
			string value = "Value One";

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			( ( HtmlHelper )htmlHelper ).ViewData.ModelState.AddModelError( name, "ErrorMessage" );

			var result = htmlHelper.CheckBoxListItem( name, value );

			string expectedId = string.Format( "{0}_{1}", name, value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input name=\"{0}.CheckBoxList\" type=\"hidden\" value=\"\" /><input class=\"input-validation-error\" id=\"{1}\" name=\"{0}\" type=\"checkbox\" value=\"{2}\" />", name, expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithModelStateValueContainsValueAndSelectedValuesDoesNotContainValueReturnsCorrectly()
		{
			string name = "Name";
			string value = "Value One";

			string[] selectedValues =
			{
				"Value Two",
				"Value Three"
			};

			string[] modelStateValue = new string[] { value, "Value Four" };

			ModelState modelState = new ModelState();
			modelState.Value = new ValueProviderResult( modelStateValue, string.Join( ",", modelStateValue ), CultureInfo.InvariantCulture );

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			( ( HtmlHelper )htmlHelper ).ViewData.ModelState.Add( name, modelState );

			var result = htmlHelper.CheckBoxListItem( name, value, selectedValues );

			string expectedId = string.Format( "{0}_{1}", name, value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input name=\"{0}.CheckBoxList\" type=\"hidden\" value=\"\" /><input checked=\"checked\" id=\"{1}\" name=\"{0}\" type=\"checkbox\" value=\"{2}\" />", name, expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithModelStateValueDoesNotContainValueAndSelectedValuesContainsValueReturnsCorrectly()
		{
			string name = "Name";
			string value = "Value One";

			string[] selectedValues =
			{
				value,
				"Value Three"
			};

			string[] modelStateValue = new string[] { "ValueThree", "Value Four" };

			ModelState modelState = new ModelState();
			modelState.Value = new ValueProviderResult( modelStateValue, string.Join( ",", modelStateValue ), CultureInfo.InvariantCulture );

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();
			( ( HtmlHelper )htmlHelper ).ViewData.ModelState.Add( name, modelState );

			var result = htmlHelper.CheckBoxListItem( name, value, selectedValues );

			string expectedId = string.Format( "{0}_{1}", name, value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input name=\"{0}.CheckBoxList\" type=\"hidden\" value=\"\" /><input id=\"{1}\" name=\"{0}\" type=\"checkbox\" value=\"{2}\" />", name, expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithValueAttributeSpecifiedReturnsCorrectly()
		{
			string name = "Name";
			string value = "Value One";

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.CheckBoxListItem( name, value, x => x.Attribute( "value", "Updated Value" ) );

			string expectedId = string.Format( "{0}_{1}", name, value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input name=\"{0}.CheckBoxList\" type=\"hidden\" value=\"\" /><input id=\"{1}\" name=\"{0}\" type=\"checkbox\" value=\"{2}\" />", name, expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithNameAttributeSpecifiedReturnsCorrectly()
		{
			string name = "Name";
			string value = "Value One";

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.CheckBoxListItem( name, value, x => x.Attribute( "name", "Updated Name" ) );

			string expectedId = string.Format( "{0}_{1}", name, value.Replace( ' ', '_' ) );
			string expectedResult = string.Format( "<input name=\"{0}.CheckBoxList\" type=\"hidden\" value=\"\" /><input id=\"{1}\" name=\"{0}\" type=\"checkbox\" value=\"{2}\" />", name, expectedId, value );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void MultipleCallsOnlyRendersOneHiddenInputReturnsCorrectly()
		{
			string name = "Name";
			string valueOne = "Value One";
			string valueTwo = "Value Two";

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var firstResult = htmlHelper.CheckBoxListItem( name, valueOne );
			var secondResult = htmlHelper.CheckBoxListItem( name, valueTwo );

			string expectedFirstId = string.Format( "{0}_{1}", name, valueOne.Replace( ' ', '_' ) );
			string expectedFirstResult = string.Format( "<input name=\"{0}.CheckBoxList\" type=\"hidden\" value=\"\" /><input id=\"{1}\" name=\"{0}\" type=\"checkbox\" value=\"{2}\" />", name, expectedFirstId, valueOne );
			Assert.AreEqual( expectedFirstResult, firstResult.ToHtmlString() );

			string expectedSecondId = string.Format( "{0}_{1}", name, valueTwo.Replace( ' ', '_' ) );
			string expectedSecondResult = string.Format( "<input id=\"{1}\" name=\"{0}\" type=\"checkbox\" value=\"{2}\" />", name, expectedSecondId, valueTwo );
			Assert.AreEqual( expectedSecondResult, secondResult.ToHtmlString() );
		}
	}
}
