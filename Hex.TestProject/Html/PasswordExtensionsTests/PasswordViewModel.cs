using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.TestProject.Html.PasswordExtensionsTests
{
	public class PasswordViewModel
	{
		public PasswordViewModel( string passwordValue )
		{
			this.PasswordValue = passwordValue;
		}

		public string PasswordValue { get; set; }
	}
}
