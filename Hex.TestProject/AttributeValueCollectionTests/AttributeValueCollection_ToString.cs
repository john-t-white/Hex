using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hex.TestProject.AttributeValueCollectionTests
{
	[TestClass]
	public class AttributeValueCollection_ToString
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			string attributeValue1 = "AttributeValue1";
			string attributeValue2 = "AttributeValue2";

			var attributeValueCollection = new AttributeValueCollection();
			attributeValueCollection.Add( attributeValue1 );
			attributeValueCollection.Add( attributeValue2 );

			var result = attributeValueCollection.ToString();

			string expectedResult = string.Format( "{0} {1}", attributeValue1, attributeValue2 );
			Assert.AreEqual( expectedResult, result );
		}

		[TestMethod]
		public void WithNoValuesReturnsCorrectly()
		{
			var attributeValueCollection = new AttributeValueCollection();

			var result = attributeValueCollection.ToString();

			Assert.AreEqual( string.Empty, result );
		}
	}
}
