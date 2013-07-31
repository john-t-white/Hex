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
			string definitionName1 = "DefinitionName1";
			string definitionValue1 = "DefinitionValue1";

			string definitionName2 = "DefinitionName2";
			string definitionValue2 = "DefinitionValue2";

			var styles = new StyleCollection();
			styles.Add( definitionName1, definitionValue1 );
			styles.Add( definitionName2, definitionValue2 );

			var result = styles.ToString();

			string expectedResult = string.Format( "{0}:{1};{2}:{3}", definitionName1, definitionValue1, definitionName2, definitionValue2 );
			Assert.AreEqual( expectedResult, result );
		}

		[TestMethod]
		public void WithNoValuesReturnsCorrectly()
		{
			var styles = new StyleCollection();

			var result = styles.ToString();

			Assert.AreEqual( string.Empty, result );
		}
	}
}
