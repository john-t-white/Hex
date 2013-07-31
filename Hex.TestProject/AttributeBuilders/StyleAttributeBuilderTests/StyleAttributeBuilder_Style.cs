using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.StyleAttributeBuilderTests
{
	[TestClass]
	public class StyleAttributeBuilder_Style
	{
		[TestMethod]
		public void AddsAttributeNameValueCorrectly()
		{
			string name = "Name";
			string value = "Value";

			StyleCollection styles = new StyleCollection();
			StyleAttributeBuilder builder = new StyleAttributeBuilder( styles );

			var result = builder.Style( name, value );

			Assert.AreSame( builder, result );
			Assert.AreEqual( value, styles[ name ] );
		}
	}
}
