using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Hex.TestProject.Html.CheckBoxExtensions_WithValueTests
{
	public class CheckBoxViewModel
	{
		public CheckBoxViewModel()
		{

		}

		public IEnumerable<string> SelectedCheckBoxValues { get; set; }

		[Required]
		public IEnumerable<string> RequiredSelectedCheckBoxValues { get; set; }
	}
}
