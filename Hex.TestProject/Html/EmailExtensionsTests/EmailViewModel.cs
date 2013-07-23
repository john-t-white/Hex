using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.TestProject.Html.EmailExtensionsTests
{
	public class EmailViewModel
	{
		public EmailViewModel( string email )
		{
			this.Email = email;
		}

		public string Email { get; set; }
	}
}
