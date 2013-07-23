using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hex.TestProject.AttributeNameValueCollectionTests
{
	[TestClass]
	public class AttributeNameValueCollection_ToString
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			string attributeName1 = "AttributeName1";
			string attributeValue1 = "AttributeValue1";

			string attributeName2 = "AttributeName2";
			string attributeValue2 = "AttributeValue2";

			var attributeNameValueCollection = new AttributeNameValueCollection();
			attributeNameValueCollection.Add( attributeName1, attributeValue1 );
			attributeNameValueCollection.Add( attributeName2, attributeValue2 );

			var result = attributeNameValueCollection.ToString();

			string expectedResult = string.Format( "{0}:{1};{2}:{3}", attributeName1, attributeValue1, attributeName2, attributeValue2 );
			Assert.AreEqual( expectedResult, result );
		}

		[TestMethod]
		public void WithNoValuesReturnsCorrectly()
		{
			var attributeNameValueCollection = new AttributeNameValueCollection();

			var result = attributeNameValueCollection.ToString();

			Assert.AreEqual( string.Empty, result );
		}
	}
}
