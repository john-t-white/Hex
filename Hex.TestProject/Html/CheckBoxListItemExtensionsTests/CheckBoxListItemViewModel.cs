using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Hex.TestProject.Html.CheckBoxListItemExtensionsTests
{
	public class CheckBoxListItemViewModel
	{
		public IEnumerable<string> SelectedCheckBoxValues { get; set; }

		[Required]
		public IEnumerable<string> RequiredSelectedCheckBoxValues { get; set; }
	}
}
