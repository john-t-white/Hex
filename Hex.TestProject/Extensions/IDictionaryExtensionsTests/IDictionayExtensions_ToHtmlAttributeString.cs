using Hex.Extensions;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Hex.TestProject.Extensions.IDictionaryExtensionsTests
{
	[TestClass]
	public class IDictionayExtensions_ToHtmlAttributeString
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			string attributeName1 = "AttributeName1";
			string attributeValue1 = "AttributeValue1";

			string attributeName2 = "AttributeName2";
			string attributeValue2 = "AttributeValue2";

			IDictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add( attributeName1, attributeValue1 );
			dictionary.Add( attributeName2, attributeValue2 );

			var result = dictionary.ToHtmlAttributeString();

			string expectedResult = string.Format( "{0}=\"{1}\" {2}=\"{3}\"", attributeName1, attributeValue1, attributeName2, attributeValue2 );
			Assert.AreEqual( expectedResult, result );
		}

		[TestMethod]
		public void WithEmptyDictionaryReturnsCorrectly()
		{
			IDictionary<string, object> dictionary = new Dictionary<string, object>();

			var result = dictionary.ToHtmlAttributeString();

			Assert.AreEqual( string.Empty, result );
		}
	}
}
