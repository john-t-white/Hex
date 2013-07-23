using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using Hex.Extensions;

namespace Hex.TestProject.Extensions.ColorExtensionsTests
{
	[TestClass]
	public class ColorExtensions_ToHexadecimal
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			Color value = Color.Red;

			var result = value.ToHexadecimal();

			Assert.AreEqual( "#FF0000", result );
		}
	}
}
