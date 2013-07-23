using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hex.TestProject.AttributeCollectionTests
{
	[TestClass]
	public class AttributeCollection_GetAttributeValue
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			DateTime attributeValue = DateTime.Now;

			var attributeCollection = new AttributeCollection();
			attributeCollection[ attributeName ] = attributeValue;

			var result = attributeCollection.GetAttributeValue<DateTime>( attributeName );

			Assert.AreEqual( result, attributeValue );
		}

		[TestMethod]
		public void WhenNotFoundReturnsDefault()
		{
			var attributeCollection = new AttributeCollection();

			var result = attributeCollection.GetAttributeValue<DateTime>( "NotFound" );

			Assert.AreEqual( result, DateTime.MinValue );
		}
	}
}
