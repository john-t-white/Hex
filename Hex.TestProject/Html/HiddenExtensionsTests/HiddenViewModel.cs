using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.TestProject.Html.HiddenExtensionsTests
{
	public class HiddenViewModel
	{
		public HiddenViewModel( string hiddenValue )
		{
			this.HiddenValue = hiddenValue;
		}

		public string HiddenValue { get; set; }
	}
}
