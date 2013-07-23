using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Extensions;
using Hex.Html;

namespace Hex.TestProject.Extensions.DateTimeExtensionsTests
{
	[TestClass]
	public class DateTimeExtensions_ToString
	{
		[TestMethod]
		public void WithTimeFormatMinuteReturnsCorrectly()
		{
			TimeFormat timeFormat = TimeFormat.Minute;

			DateTime value = DateTime.Now;

			var result = value.ToString( timeFormat );

			Assert.AreEqual( value.ToString( "HH:mm" ), result );
		}

		[TestMethod]
		public void WithTimeFormatSecondReturnsCorrectly()
		{
			TimeFormat timeFormat = TimeFormat.Second;

			DateTime value = DateTime.Now;

			var result = value.ToString( timeFormat );

			Assert.AreEqual( value.ToString( "HH:mm:ss" ), result );
		}

		[TestMethod]
		public void WithTimeFormatMillisecondReturnsCorrectly()
		{
			TimeFormat timeFormat = TimeFormat.Millisecond;

			DateTime value = DateTime.Now;

			var result = value.ToString( timeFormat );

			Assert.AreEqual( value.ToString( "HH:mm:ss.fff" ), result );
		}

		[TestMethod]
		public void WithTimeOnlyFalseReturnsCorrectly()
		{
			TimeFormat timeFormat = TimeFormat.Minute;

			DateTime value = DateTime.Now;

			var result = value.ToString( timeFormat, false );

			Assert.AreEqual( value.ToString( "yyyy-MM-ddTHH:mm" ), result );
		}
	}
}
