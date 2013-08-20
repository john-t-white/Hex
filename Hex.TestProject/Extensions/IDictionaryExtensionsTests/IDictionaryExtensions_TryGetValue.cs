using Hex.Extensions;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Hex.TestProject.Extensions.IDictionaryExtensionsTests
{
	[TestClass]
	public class IDictionaryExtensions_TryGetValue
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			string key = "AttributeName";
			string value = "AttributeValue";

			IDictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add( key, value );

			string resultValue = null;
			var result = dictionary.TryGetValue<string>( key, out resultValue );

			Assert.IsTrue( result );
			Assert.AreEqual( resultValue, value );
		}

		[TestMethod]
		public void WhenKeyNotFoundReturnsCorrectly()
		{
			string attributeName = "AttributeName";

			IDictionary<string, object> dictionary = new Dictionary<string, object>();

			string resultValue;
			var result = dictionary.TryGetValue<string>( attributeName, out resultValue );

			Assert.IsFalse( result );
			Assert.IsNull( resultValue );
		}

		[TestMethod]
		public void WhenValueIsNotOfTypeReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			IDictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add( attributeName, attributeValue );

			int resultValue;
			var result = dictionary.TryGetValue<int>( attributeName, out resultValue );

			Assert.IsFalse( result );
			Assert.AreEqual( resultValue, 0 );
		}
	}
}
