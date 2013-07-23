using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Extensions;
using Hex.Html;

namespace Hex.TestProject.Extensions.EnumExtensionsTests
{
	[TestClass]
	public class EnumExtensions_ToLowerString
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			AutoCompleteType value = AutoCompleteType.Off;

			var result = value.ToLowerString();

			Assert.AreEqual( AutoCompleteType.Off.ToString().ToLower(), result );
		}
	}
}
