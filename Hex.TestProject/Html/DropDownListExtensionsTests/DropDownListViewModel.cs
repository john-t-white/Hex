using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.TestProject.Html.DropDownListExtensionsTests
{
	public class DropDownListViewModel
	{
		public DropDownListViewModel()
		{

		}

		public DropDownListViewModel( string selectedValue )
		{
			this.SelectedValue = selectedValue;
		}

		public string SelectedValue { get; set; }

		public IEnumerable<SelectListItem> DropDownList
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
