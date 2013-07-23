using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using Hex.Extensions;
using Hex.Html;

namespace Hex.TestProject.Extensions.ObjectExtensionsTests
{
	[TestClass]
	public class ObjectExtensions_ConvertIfDateTime
	{
		[TestMethod]
		public void WithTimeFormatReturnsCorrectly()
		{
			object value = DateTime.Now;

			var result = value.ConvertIfDateTime( TimeFormat.Minute );

			string expectedResult = ( ( DateTime )value ).ToString( "HH:mm" );
			Assert.AreEqual( expectedResult, result );
		}

		[TestMethod]
		public void NotDateTimeWithTimeFormatReturnsCorrectly()
		{
			object value = "NotColor";

			var result = value.ConvertIfDateTime( TimeFormat.Minute );

			Assert.AreEqual( "NotColor", result );
		}

		[TestMethod]
		public void WithTimeFormatAndTimeOnlyFalseReturnsCorrectly()
		{
			object value = DateTime.Now;

			var result = value.ConvertIfDateTime( TimeFormat.Minute, false );

			string expectedResult = ( ( DateTime )value ).ToString( "yyyy-MM-ddTHH:mm" );
			Assert.AreEqual( expectedResult, result );
		}

		[TestMethod]
		public void NotDateTimeWithTimeFormatAndTimeOnlyFalseReturnsCorrectly()
		{
			object value = "NotColor";

			var result = value.ConvertIfDateTime( TimeFormat.Minute, false );

			Assert.AreEqual( "NotColor", result );
		}

		[TestMethod]
		public void WithFormatReturnsCorrectly()
		{
			object value = DateTime.Now;

			var result = value.ConvertIfDateTime( "yyyy-MM" );

			string expectedResult = ( ( DateTime )value ).ToString( "yyyy-MM" );
			Assert.AreEqual( expectedResult, result );
		}

		[TestMethod]
		public void NotDateTimeWithFormatReturnsCorrectly()
		{
			object value = "NotColor";

			var result = value.ConvertIfDateTime( "yyyy-MM" );

			Assert.AreEqual( "NotColor", result );
		}
	}
}
