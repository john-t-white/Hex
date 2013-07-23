using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.AttributeBuilders;
using Hex.Extensions;

namespace Hex.TestProject.Extensions.ActionExtensionsTests
{
	[TestClass]
	public class ActionExtensions_GetAttributes
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			Action<HtmlAttributeBuilder> attributeExpression = new Action<HtmlAttributeBuilder>( x => x.Attribute( attributeName, attributeValue ) );

			var result = attributeExpression.GetAttributes();

			Assert.IsNotNull( result );
			Assert.AreEqual( attributeValue, result[ attributeName ] );
		}

		[TestMethod]
		public void WithActionNullReturnsCorrectly()
		{
			Action<HtmlAttributeBuilder> attributeExpression = null;

			var result = attributeExpression.GetAttributes();

			Assert.IsNotNull( result );
			Assert.AreEqual( 0, result.Count );
		}
	}
}
