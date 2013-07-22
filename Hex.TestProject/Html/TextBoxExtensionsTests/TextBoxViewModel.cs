using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.TestProject.Html.TextBoxExtensionsTests
{
	public class TextBoxViewModel
	{
		public TextBoxViewModel( string textBoxValue )
		{
			this.TextBoxValue = textBoxValue;
		}

		public string TextBoxValue { get; set; }
	}
}
