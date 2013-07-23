using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.TestProject.Html.TelephoneExtensionsTests
{
	public class TelephoneViewModel
	{
		public TelephoneViewModel( string telephoneNumber )
		{
			this.TelephoneNumber = telephoneNumber;
		}

		public string TelephoneNumber { get; set; }
	}
}
