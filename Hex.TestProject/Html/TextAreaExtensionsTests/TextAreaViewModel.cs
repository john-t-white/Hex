using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.TestProject.Html.TextAreaExtensionsTests
{
	public class TextAreaViewModel
	{
		public TextAreaViewModel( string textAreaValue )
		{
			this.TextAreaValue = textAreaValue;
		}

		public string TextAreaValue { get; set; }
	}
}
