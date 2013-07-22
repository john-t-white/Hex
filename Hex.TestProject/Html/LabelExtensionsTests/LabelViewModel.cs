using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.TestProject.Html.LabelExtensionsTests
{
	public class LabelViewModel
	{
		public LabelViewModel( string labelValue )
		{
			this.LabelValue = labelValue;
		}

		public string LabelValue { get; set; }
	}
}
