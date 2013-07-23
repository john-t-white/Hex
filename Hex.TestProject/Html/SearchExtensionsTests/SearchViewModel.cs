using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.TestProject.Html.SearchExtensionsTests
{
	public class SearchViewModel
	{
		public SearchViewModel( string searchText )
		{
			this.SearchText = searchText;
		}

		public string SearchText { get; set; }
	}
}
