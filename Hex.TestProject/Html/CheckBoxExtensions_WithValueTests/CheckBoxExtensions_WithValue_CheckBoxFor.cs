using Hex.Html;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Globalization;

namespace Hex.TestProject.Html.CheckBoxExtensions_WithValueTests
{
	[TestClass]
	public class CheckBoxExtensions_WithValue_CheckBoxFor
	{
		[TestMethod]
		public void WithViewModelPropertyDoesNotHaveEitherValueReturnsCorrectly()
		{
			string checkedValue = "CheckedValue";
			string uncheckedValue = "UncheckedValue";

			var viewModel = new CheckBoxViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<CheckBoxViewModel>( viewModel );
			var result = htmlHelper.CheckBoxFor( x => x.CheckBoxValue, checkedValue, uncheckedValue );

			string expectedResult = string.Format( "<input id=\"CheckBoxValue\" name=\"CheckBoxValue\" type=\"checkbox\" value=\"{0}\" /><input name=\"CheckBoxValue\" type=\"hidden\" value=\"{1}\" />", checkedValue, uncheckedValue );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentNullException ) )]
		public void WithNullCheckedValueThrowsArgumentNullException()
		{
			string checkedValue = null;
			string uncheckedValue = "UncheckedValue";

			var viewModel = new CheckBoxViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<CheckBoxViewModel>( viewModel );
			htmlHelper.CheckBoxFor( x => x.CheckBoxValue, checkedValue, uncheckedValue );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentNullException ) )]
		public void WithNullUncheckedValueThrowsArgumentNullException()
		{
			string checkedValue = "CheckedValue";
			string uncheckedValue = null;

			var viewModel = new CheckBoxViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<CheckBoxViewModel>( viewModel );
			htmlHelper.CheckBoxFor( x => x.CheckBoxValue, checkedValue, uncheckedValue );
		}

		[TestMethod]
		public void WithViewModelPropertyEqualsCheckedValueReturnsCorrectly()
		{
			string checkedValue = "CheckedValue";
			string uncheckedValue = "UncheckedValue";

			var viewModel = new CheckBoxViewModel()
			{
				CheckBoxValue = checkedValue
			};

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<CheckBoxViewModel>( viewModel );
			var result = htmlHelper.CheckBoxFor( x => x.CheckBoxValue, checkedValue, uncheckedValue );

			string expectedResult = string.Format( "<input checked=\"checked\" id=\"CheckBoxValue\" name=\"CheckBoxValue\" type=\"checkbox\" value=\"{0}\" /><input name=\"CheckBoxValue\" type=\"hidden\" value=\"{1}\" />", checkedValue, uncheckedValue );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithViewModelPropertyEqualsUncheckedValueReturnsCorrectly()
		{
			string checkedValue = "CheckedValue";
			string uncheckedValue = "UncheckedValue";

			var viewModel = new CheckBoxViewModel()
			{
				CheckBoxValue = uncheckedValue
			};

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<CheckBoxViewModel>( viewModel );
			var result = htmlHelper.CheckBoxFor( x => x.CheckBoxValue, checkedValue, uncheckedValue );

			string expectedResult = string.Format( "<input id=\"CheckBoxValue\" name=\"CheckBoxValue\" type=\"checkbox\" value=\"{0}\" /><input name=\"CheckBoxValue\" type=\"hidden\" value=\"{1}\" />", checkedValue, uncheckedValue );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithHtmlAttributesObjectReturnsCorrectly()
		{
			string checkedValue = "CheckedValue";
			string uncheckedValue = "UncheckedValue";
			string attributeValue = "attributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			var viewModel = new CheckBoxViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<CheckBoxViewModel>( viewModel );
			var result = htmlHelper.CheckBoxFor( x => x.CheckBoxValue, checkedValue, uncheckedValue, htmlAttributes );

			string expectedResult = string.Format( "<input AttributeName=\"{0}\" id=\"CheckBoxValue\" name=\"CheckBoxValue\" type=\"checkbox\" value=\"{1}\" /><input name=\"CheckBoxValue\" type=\"hidden\" value=\"{2}\" />", attributeValue, checkedValue, uncheckedValue );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithHtmlAttributesDictionaryReturnsCorrectly()
		{
			string checkedValue = "CheckedValue";
			string uncheckedValue = "UncheckedValue";
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			var viewModel = new CheckBoxViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<CheckBoxViewModel>( viewModel );
			var result = htmlHelper.CheckBoxFor( x => x.CheckBoxValue, checkedValue, uncheckedValue, htmlAttributes );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"CheckBoxValue\" name=\"CheckBoxValue\" type=\"checkbox\" value=\"{2}\" /><input name=\"CheckBoxValue\" type=\"hidden\" value=\"{3}\" />", attributeName, attributeValue, checkedValue, uncheckedValue );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithAttributeExpressionReturnsCorrectly()
		{
			string checkedValue = "CheckedValue";
			string uncheckedValue = "UncheckedValue";
			string attributeName = "attributeName";
			string attributeValue = "attributeValue";

			var viewModel = new CheckBoxViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<CheckBoxViewModel>( viewModel );
			var result = htmlHelper.CheckBoxFor( x => x.CheckBoxValue, checkedValue, uncheckedValue, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<input {0}=\"{1}\" id=\"CheckBoxValue\" name=\"CheckBoxValue\" type=\"checkbox\" value=\"{2}\" /><input name=\"CheckBoxValue\" type=\"hidden\" value=\"{3}\" />", attributeName, attributeValue, checkedValue, uncheckedValue );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithModelStateErrorReturnsCorrectly()
		{
			string checkedValue = "CheckedValue";
			string uncheckedValue = "UncheckedValue";

			var viewModel = new CheckBoxViewModel();

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<CheckBoxViewModel>( viewModel );
			( ( HtmlHelper )htmlHelper ).ViewData.ModelState.AddModelError( "CheckBoxValue", "ErrorMessage" );
			var result = htmlHelper.CheckBoxFor( x => x.CheckBoxValue, checkedValue, uncheckedValue );

			string expectedResult = string.Format( "<input class=\"input-validation-error\" id=\"CheckBoxValue\" name=\"CheckBoxValue\" type=\"checkbox\" value=\"{0}\" /><input name=\"CheckBoxValue\" type=\"hidden\" value=\"{1}\" />", checkedValue, uncheckedValue );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithModelStateValueEqualsCheckedValueAndModelValueEqualsUncheckedValueReturnsCorrectly()
		{
			string checkedValue = "CheckedValue";
			string uncheckedValue = "UncheckedValue";

			var viewModel = new CheckBoxViewModel()
			{
				CheckBoxValue = uncheckedValue
			};

			ModelState modelState = new ModelState();
			modelState.Value = new ValueProviderResult( checkedValue, checkedValue, CultureInfo.InvariantCulture );

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<CheckBoxViewModel>( viewModel );
			( ( HtmlHelper )htmlHelper ).ViewData.ModelState.Add( "CheckBoxValue", modelState );

			var result = htmlHelper.CheckBoxFor( x => x.CheckBoxValue, checkedValue, uncheckedValue );

			string expectedResult = string.Format( "<input id=\"CheckBoxValue\" name=\"CheckBoxValue\" type=\"checkbox\" value=\"{0}\" /><input name=\"CheckBoxValue\" type=\"hidden\" value=\"{1}\" />", checkedValue, uncheckedValue );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithModelStateValueEqualsUncheckedValueAndModelValueEqualsCheckedValueReturnsCorrectly()
		{
			string checkedValue = "CheckedValue";
			string uncheckedValue = "UncheckedValue";

			var viewModel = new CheckBoxViewModel()
			{
				CheckBoxValue = checkedValue
			};

			ModelState modelState = new ModelState();
			modelState.Value = new ValueProviderResult( uncheckedValue, uncheckedValue, CultureInfo.InvariantCulture );

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<CheckBoxViewModel>( viewModel );
			( ( HtmlHelper )htmlHelper ).ViewData.ModelState.Add( "CheckBoxValue", modelState );

			var result = htmlHelper.CheckBoxFor( x => x.CheckBoxValue, checkedValue, uncheckedValue );

			string expectedResult = string.Format( "<input checked=\"checked\" id=\"CheckBoxValue\" name=\"CheckBoxValue\" type=\"checkbox\" value=\"{0}\" /><input name=\"CheckBoxValue\" type=\"hidden\" value=\"{1}\" />", checkedValue, uncheckedValue );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithModelStateValueEqualsCheckedValueAndModelValueIsNullReturnsCorrectly()
		{
			string checkedValue = "CheckedValue";
			string uncheckedValue = "UncheckedValue";

			var viewModel = new CheckBoxViewModel();

			ModelState modelState = new ModelState();
			modelState.Value = new ValueProviderResult( checkedValue, checkedValue, CultureInfo.InvariantCulture );

			var htmlHelper = HtmlHelperGenerator.CreateHtmlHelper<CheckBoxViewModel>( viewModel );
			( ( HtmlHelper )htmlHelper ).ViewData.ModelState.Add( "CheckBoxValue", modelState );

			var result = htmlHelper.CheckBoxFor( x => x.CheckBoxValue, checkedValue, uncheckedValue );

			string expectedResult = string.Format( "<input id=\"CheckBoxValue\" name=\"CheckBoxValue\" type=\"checkbox\" value=\"{0}\" /><input name=\"CheckBoxValue\" type=\"hidden\" value=\"{1}\" />", checkedValue, uncheckedValue );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
