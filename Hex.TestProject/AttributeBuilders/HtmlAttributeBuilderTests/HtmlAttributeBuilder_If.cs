using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hex.TestProject.AttributeBuilders.HtmlAttributeBuilderTests
{
	[TestClass]
	public class HtmlAttributeBuilder_If
	{
		[TestMethod]
		public void ConditionTrueInvokesTrueAttributeExpression()
		{
			bool condition = true;
			string attributeName = "Name";
			string attributeValue = "Value";

			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.If( condition, x => x.Attribute( attributeName, attributeValue ) );

			Assert.AreSame( builder, result );
			Assert.IsTrue( builder.Attributes.ContainsKey( attributeName ) );
		}

		[TestMethod]
		public void NullTrueAttributeExpressionWithConditionTrueReturnsCorrectly()
		{
			bool condition = true;

			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.If( condition, null );

			Assert.AreSame( builder, result );
			Assert.IsTrue( builder.Attributes.Count == 0 );
		}

		[TestMethod]
		public void ConditionTrueDoesNotInvokesFalseAttributeExpression()
		{
			bool condition = true;
			string attributeName = "Name";
			string attributeValue = "Value";

			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.If( condition, null, x => x.Attribute( attributeName, attributeValue ) );

			Assert.AreSame( builder, result );
			Assert.IsTrue( builder.Attributes.Count == 0 );
		}

		[TestMethod]
		public void ConditionFalseInvokesFalseAttributeExpression()
		{
			bool condition = false;
			string attributeName = "Name";
			string attributeValue = "Value";

			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.If( condition, null, x => x.Attribute( attributeName, attributeValue ) );

			Assert.AreSame( builder, result );
			Assert.IsTrue( builder.Attributes.ContainsKey( attributeName ) );
		}

		[TestMethod]
		public void NullFalseAttributeExpressionWithConditionFalseReturnsCorrectly()
		{
			bool condition = false;

			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.If( condition, null, null );

			Assert.AreSame( builder, result );
			Assert.IsTrue( builder.Attributes.Count == 0 );
		}

		[TestMethod]
		public void ConditionFalseDoesNotInvokesTrueAttributeExpression()
		{
			bool condition = false;
			string attributeName = "Name";
			string attributeValue = "Value";

			HtmlAttributeBuilderFake builder = new HtmlAttributeBuilderFake();
			var result = builder.If( condition, x => x.Attribute( attributeName, attributeValue ), null );

			Assert.AreSame( builder, result );
			Assert.IsTrue( builder.Attributes.Count == 0 );
		}
	}
}
