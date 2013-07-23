using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.TestProject.Html.UrlExtensionsTests
{
	public class UrlViewModel
	{
		public UrlViewModel( string urlAsString )
		{
			this.UrlAsString = urlAsString;
		}

		public UrlViewModel( Uri url )
		{
			this.Url = url;
		}

		public string UrlAsString { get; set; }

		public Uri Url { get; set; }
	}
}
