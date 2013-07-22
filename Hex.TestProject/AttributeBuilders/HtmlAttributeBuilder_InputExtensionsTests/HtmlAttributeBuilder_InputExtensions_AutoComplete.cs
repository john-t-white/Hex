using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilder_InputExtensionsTests
{
	[TestClass]
	public class HtmlAttributeBuilder_InputExtensions_AutoComplete
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.AutoComplete();

			Assert.AreSame( builder, result );

			Assert.AreEqual( AutoCompleteType.On.ToString().ToLower(), builder.Attributes[ HtmlAttributes.AutoComplete ] );
		}

		[TestMethod]
		public void WithBooleanValueTrueAddsAttributeCorrectly()
		{
			bool value = true;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.AutoComplete( value );

			Assert.AreSame( builder, result );

			Assert.AreEqual( AutoCompleteType.On.ToString().ToLower(), builder.Attributes[ HtmlAttributes.AutoComplete ] );
		}

		[TestMethod]
		public void WithBooleanValueFalseAddsAttributeCorrectly()
		{
			bool value = false;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.AutoComplete( value );

			Assert.AreSame( builder, result );

			Assert.AreEqual( AutoCompleteType.Off.ToString().ToLower(), builder.Attributes[ HtmlAttributes.AutoComplete ] );
		}

		[TestMethod]
		public void WithAutoCompleteTypeValueAddsAttributeCorrectly()
		{
			AutoCompleteType value = AutoCompleteType.On;

			HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
			var result = builder.AutoComplete( value );

			Assert.AreSame( builder, result );

			Assert.AreEqual( value.ToString().ToLower(), builder.Attributes[ HtmlAttributes.AutoComplete ] );
		}
	}
}
