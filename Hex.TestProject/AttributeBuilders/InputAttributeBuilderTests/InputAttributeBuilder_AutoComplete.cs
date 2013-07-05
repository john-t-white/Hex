using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.InputAttributeBuilderTests
{
	[TestClass]
	public class InputAttributeBuilder_AutoComplete
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			InputAttributeBuilderFake builder = new InputAttributeBuilderFake();
			var result = builder.AutoComplete();

			Assert.AreSame( builder, result );

			Assert.AreEqual( AutoCompleteType.On.ToString().ToLower(), builder.Attributes[ HtmlAttributes.AutoComplete ] );
		}

		[TestMethod]
		public void WithBooleanValueAddsAttributeCorrectly()
		{
			bool value = true;

			InputAttributeBuilderFake builder = new InputAttributeBuilderFake();
			var result = builder.AutoComplete( value );

			Assert.AreSame( builder, result );

			Assert.AreEqual( AutoCompleteType.On.ToString().ToLower(), builder.Attributes[ HtmlAttributes.AutoComplete ] );
		}

		[TestMethod]
		public void WithAutoCompleteTypeValueAddsAttributeCorrectly()
		{
			AutoCompleteType value = AutoCompleteType.On;

			InputAttributeBuilderFake builder = new InputAttributeBuilderFake();
			var result = builder.AutoComplete( value );

			Assert.AreSame( builder, result );

			Assert.AreEqual( value.ToString().ToLower(), builder.Attributes[ HtmlAttributes.AutoComplete ] );
		}
	}
}
