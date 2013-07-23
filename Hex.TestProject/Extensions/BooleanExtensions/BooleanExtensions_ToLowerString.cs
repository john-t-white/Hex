using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Extensions;

namespace Hex.TestProject.Extensions.BooleanExtensions
{
	[TestClass]
	public class BooleanExtensions_ToLowerString
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			bool value = true;

			var result = value.ToLowerString();

			Assert.AreEqual( "true", result );
		}
	}
}
