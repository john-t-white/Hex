using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hex.TestProject.AttributeCollectionTests
{
	[TestClass]
	public class AttributeCollection_AddOrRemoveMinimizedAttribute
	{
		[TestMethod]
		public void WithValueTrueAddsAttributeCorrectly()
		{
			string attributeName = "AttributeName";
			bool value = true;

			var attributeCollection = new AttributeCollection();

			attributeCollection.AddOrRemoveMinimizedAttribute( attributeName, value );

			Assert.AreEqual( attributeName, attributeCollection[ attributeName ] );
		}

		[TestMethod]
		public void WithValueFalseDoesNotAddAttribute()
		{
			string attributeName = "AttributeName";
			bool value = false;

			var attributeCollection = new AttributeCollection();

			attributeCollection.AddOrRemoveMinimizedAttribute( attributeName, value );

			Assert.IsFalse( attributeCollection.ContainsKey( attributeName ) );
		}

		[TestMethod]
		public void WithValueFalseRemovesAttributeIfAlreadyExists()
		{
			string attributeName = "AttributeName";

			var attributeCollection = new AttributeCollection();

			attributeCollection.AddOrRemoveMinimizedAttribute( attributeName, true );
			attributeCollection.AddOrRemoveMinimizedAttribute( attributeName, false );

			Assert.IsFalse( attributeCollection.ContainsKey( attributeName ) );
		}
	}
}
