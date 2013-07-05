using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.FormAttributeBuilderTests
{
	[TestClass]
	public class FormAttributeBuilder_AutoComplete
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			FormAttributeBuilder builder = new FormAttributeBuilder();
			var result = builder.AutoComplete();

			Assert.AreSame( builder, result );

			Assert.AreEqual( AutoCompleteType.On.ToString().ToLower(), builder.Attributes[ HtmlAttributes.AutoComplete ] );
		}

		[TestMethod]
		public void WithBooleanValueAddsAttributeCorrectly()
		{
			bool value = true;

			FormAttributeBuilder builder = new FormAttributeBuilder();
			var result = builder.AutoComplete( value );

			Assert.AreSame( builder, result );

			Assert.AreEqual( AutoCompleteType.On.ToString().ToLower(), builder.Attributes[ HtmlAttributes.AutoComplete ] );
		}

		[TestMethod]
		public void WithAutoCompleteTypeValueAddsAttributeCorrectly()
		{
			AutoCompleteType value = AutoCompleteType.On;

			FormAttributeBuilder builder = new FormAttributeBuilder();
			var result = builder.AutoComplete( value );

			Assert.AreSame( builder, result );

			Assert.AreEqual( value.ToString().ToLower(), builder.Attributes[ HtmlAttributes.AutoComplete ] );
		}
	}
}
