using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Extensions;

namespace Hex.TestProject.Extensions.ObjectExtensionsTests
{
	[TestClass]
	public class ObjectExtensions_ConvertIfUri
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			object value = new Uri( "http://www.example.com", UriKind.Absolute );

			var result = value.ConvertIfUri();

			Assert.AreEqual( "http://www.example.com", result );
		}

		[TestMethod]
		public void NotUriReturnsCorrectly()
		{
			object value = "NotUri";

			var result = value.ConvertIfUri();

			Assert.AreEqual( "NotUri", result );
		}
	}
}
