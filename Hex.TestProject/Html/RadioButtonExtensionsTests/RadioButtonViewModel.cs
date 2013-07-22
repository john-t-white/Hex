using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.TestProject.Html.RadioButtonExtensionsTests
{
	public class RadioButtonViewModel
	{
		public RadioButtonViewModel( string radioValue )
		{
			this.RadioValue = radioValue;
		}

		public string RadioValue { get; set; }
	}
}
