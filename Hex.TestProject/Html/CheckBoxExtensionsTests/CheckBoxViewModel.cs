using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.TestProject.Html.CheckBoxExtensionsTests
{
	public class CheckBoxViewModel
	{
		public CheckBoxViewModel( bool checkBox )
		{
			this.CheckBox = checkBox;
		}

		public bool CheckBox { get; set; }
	}
}
