using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Html;
using Hex.Extensions;

namespace Hex.TestProject.Extensions.TimeFormatExtensionsTests
{
	[TestClass]
	public class TimeFormatExtensions_GetStepValue
	{
		[TestMethod]
		public void WithTimeFormatMinuteReturnsCorrectly()
		{
			TimeFormat value = TimeFormat.Minute;

			var result = value.GetStepValue();

			Assert.IsNull( result );
		}

		[TestMethod]
		public void WithTimeFormatSecondReturnsCorrectly()
		{
			TimeFormat value = TimeFormat.Second;

			var result = value.GetStepValue();

			Assert.AreEqual( 1, result );
		}

		[TestMethod]
		public void WithTimeFormatMillisecondReturnsCorrectly()
		{
			TimeFormat value = TimeFormat.Millisecond;

			var result = value.GetStepValue();

			Assert.AreEqual( .001, result );
		}
	}
}
