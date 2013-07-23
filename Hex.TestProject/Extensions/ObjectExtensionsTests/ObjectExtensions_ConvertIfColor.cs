using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using Hex.Extensions;

namespace Hex.TestProject.Extensions.ObjectExtensionsTests
{
	[TestClass]
	public class ObjectExtensions_ConvertIfColor
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			object value = Color.Red;

			var result = value.ConvertIfColor();

			Assert.AreEqual( "#FF0000", result );
		}

		[TestMethod]
		public void NotColorReturnsCorrectly()
		{
			object value = "NotColor";

			var result = value.ConvertIfColor();

			Assert.AreEqual( "NotColor", result );
		}
	}
}
