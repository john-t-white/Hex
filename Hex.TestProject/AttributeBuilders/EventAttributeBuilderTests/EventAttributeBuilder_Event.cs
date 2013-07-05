using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.AttributeBuilders;

namespace Hex.TestProject.AttributeBuilders.EventAttributeBuilderTests
{
	[TestClass]
	public class EventAttributeBuilder_Event
	{
		[TestMethod]
		public void AddsAttributeCorrectly()
		{
			string name = "Name";
			string script = "Script";

			var attributes = new AttributeCollection();
			var builder = new EventAttributeBuilder( attributes );

			var result = builder.Event( name, script );

			Assert.AreSame( builder, result );
			Assert.AreEqual( script, attributes[ name ] );
		}

		[TestMethod]
		public void WithNullNameDoesNotAddAttribute()
		{
			string name = null;
			string script = "Script";

			var attributes = new AttributeCollection();
			var builder = new EventAttributeBuilder( attributes );

			var result = builder.Event( name, script );

			Assert.AreSame( builder, result );
			Assert.AreEqual( 0, attributes.Count );
		}

		[TestMethod]
		public void WithEmptyNameDoesNotAddAttribute()
		{
			string name = string.Empty;
			string script = "Script";

			var attributes = new AttributeCollection();
			var builder = new EventAttributeBuilder( attributes );

			var result = builder.Event( name, script );

			Assert.AreSame( builder, result );
			Assert.IsFalse( attributes.ContainsKey( name ) );
		}

		[TestMethod]
		public void WithWhiteSpaceNameDoesNotAddAttribute()
		{
			string name = " ";
			string script = "Script";

			var attributes = new AttributeCollection();
			var builder = new EventAttributeBuilder( attributes );

			var result = builder.Event( name, script );

			Assert.AreSame( builder, result );
			Assert.IsFalse( attributes.ContainsKey( name ) );
		}
	}
}
