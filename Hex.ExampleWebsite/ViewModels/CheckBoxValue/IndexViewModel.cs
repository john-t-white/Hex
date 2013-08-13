using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hex.ExampleWebsite.ViewModels.CheckBoxValue
{
	public class IndexViewModel
	{
		public IndexViewModel()
		{
			this.StringValues = new List<string>();
			this.IntValues = new List<int>();
		}

		public List<string> StringValues { get; private set; }

		public List<string> SelectedStringValues { get; set; }

		public List<int> IntValues { get; private set; }

		[Required]
		public List<int> SelectedIntValues { get; set; }

		[Required]
		public string RequiredTextBox { get; set; }
	}
}