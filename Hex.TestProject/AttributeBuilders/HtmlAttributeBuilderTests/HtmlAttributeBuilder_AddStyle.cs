using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Hex.Html;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilderTests
{
	[TestClass]
	public class HtmlAttributeBuilder_AddStyle
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			string name = "Name";
			string value = "Value";

			var builder = new HtmlAttributeBuilderFake();
			var result = builder.AddStyle( name, value );

			Assert.AreSame( builder, result );

			AttributeNameValueCollection attributeNameValues = builder.Attributes[ HtmlAttributes.Style ] as AttributeNameValueCollection;
			Assert.IsNotNull( attributeNameValues );
			Assert.AreEqual( value, attributeNameValues[ name ] );
		}

		[TestMethod]
		public void WithNullNameDoesNotAddAttribute()
		{
			string name = null;
			string value = "Value";

			var builder = new HtmlAttributeBuilderFake();
			var result = builder.AddStyle( name, value );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.Style ) );
		}

		[TestMethod]
		public void WithEmptyNameDoesNotAddAttribute()
		{
			string name = string.Empty;
			string value = "Value";

			var builder = new HtmlAttributeBuilderFake();
			var result = builder.AddStyle( name, value );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.Style ) );
		}

		[TestMethod]
		public void WithWhiteSpaceNameDoesNotAddAttribute()
		{
			string name = " ";
			string value = "Value";

			var builder = new HtmlAttributeBuilderFake();
			var result = builder.AddStyle( name, value );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.Style ) );
		}

		[TestMethod]
		public void WithAnonymousValueAddsAttributeCorrectly()
		{
			string name1 = "Name1";
			string value1 = "Value1";

			string name2 = "Name2";
			string value2 = "Value2";

			var styles = new
			{
				Name1 = value1,
				Name2 = value2
			};

			var builder = new HtmlAttributeBuilderFake();
			var result = builder.AddStyle( styles );

			Assert.AreSame( builder, result );

			AttributeNameValueCollection attributeNameValues = builder.Attributes[ HtmlAttributes.Style ] as AttributeNameValueCollection;
			Assert.IsNotNull( attributeNameValues );
			Assert.AreEqual( value1, attributeNameValues[ name1 ] );
			Assert.AreEqual( value2, attributeNameValues[ name2 ] );
		}

		[TestMethod]
		public void WithNullAnonymousValueDoesNotAddAttribute()
		{
			object styles = null;

			var builder = new HtmlAttributeBuilderFake();
			var result = builder.AddStyle( styles );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.Style ) );
		}

		[TestMethod]
		public void WithDictionaryValueAddsAttributeCorrectly()
		{
			string name1 = "Name1";
			string value1 = "Value1";

			string name2 = "Name2";
			string value2 = "Value2";

			var styles = new Dictionary<string, object>();
			styles[ name1 ] = value1;
			styles[ name2 ] = value2;

			var builder = new HtmlAttributeBuilderFake();
			var result = builder.AddStyle( styles );

			Assert.AreSame( builder, result );

			AttributeNameValueCollection attributeNameValues = builder.Attributes[ HtmlAttributes.Style ] as AttributeNameValueCollection;
			Assert.IsNotNull( attributeNameValues );
			Assert.AreEqual( value1, attributeNameValues[ name1 ] );
			Assert.AreEqual( value2, attributeNameValues[ name2 ] );
		}

		[TestMethod]
		public void WithNullDictionaryValueDoesNotAddAttribute()
		{
			Dictionary<string, object> styles = null;

			var builder = new HtmlAttributeBuilderFake();
			var result = builder.AddStyle( styles );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.Style ) );
		}

		[TestMethod]
		public void WithEmptyNameInDictionaryValueOnlyAddsNonNullNameValues()
		{
			string name1 = "Name1";
			string value1 = "Value1";

			string name2 = string.Empty;
			string value2 = "Value2";

			var styles = new Dictionary<string, object>();
			styles[ name1 ] = value1;
			styles[ name2 ] = value2;

			var builder = new HtmlAttributeBuilderFake();
			var result = builder.AddStyle( styles );

			Assert.AreSame( builder, result );

			AttributeNameValueCollection attributeNameValues = builder.Attributes[ HtmlAttributes.Style ] as AttributeNameValueCollection;
			Assert.IsNotNull( attributeNameValues );
			Assert.AreEqual( 1, attributeNameValues.Count );
			Assert.AreEqual( value1, attributeNameValues[ name1 ] );
		}

		[TestMethod]
		public void WithWhiteSpaceNameInDictionaryValueOnlyAddsNonNullNameValues()
		{
			string name1 = "Name1";
			string value1 = "Value1";

			string name2 = " ";
			string value2 = "Value2";

			var styles = new Dictionary<string, object>();
			styles[ name1 ] = value1;
			styles[ name2 ] = value2;

			var builder = new HtmlAttributeBuilderFake();
			var result = builder.AddStyle( styles );

			Assert.AreSame( builder, result );

			AttributeNameValueCollection attributeNameValues = builder.Attributes[ HtmlAttributes.Style ] as AttributeNameValueCollection;
			Assert.IsNotNull( attributeNameValues );
			Assert.AreEqual( 1, attributeNameValues.Count );
			Assert.AreEqual( value1, attributeNameValues[ name1 ] );
		}

		[TestMethod]
		public void WithOnlyWhiteSpaceAndEmptyNameInDictionaryValueDoesNotAddAttribute()
		{
			string name1 = string.Empty;
			string value1 = "Value1";

			string name2 = " ";
			string value2 = "Value2";

			var styles = new Dictionary<string, object>();
			styles[ name1 ] = value1;
			styles[ name2 ] = value2;

			var builder = new HtmlAttributeBuilderFake();
			var result = builder.AddStyle( styles );

			Assert.AreSame( builder, result );
			Assert.IsFalse( builder.Attributes.ContainsKey( HtmlAttributes.Style ) );
		}
	}
}
