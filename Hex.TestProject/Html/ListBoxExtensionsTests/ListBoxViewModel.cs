using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.TestProject.Html.ListBoxExtensionsTests
{
	public class ListBoxViewModel
	{
		public ListBoxViewModel()
		{

		}

		public ListBoxViewModel( params string[] selectedValues )
		{
			this.SelectedValues = selectedValues;
		}

		public string[] SelectedValues { get; set; }

		public IEnumerable<SelectListItem> SelectList
		{
			get
			{
				return new SelectListItem[]
				{
					new SelectListItem()
					{
						Text = "Text1",
						Value = "Value1"
					}
				};
			}
		}
	}
}
