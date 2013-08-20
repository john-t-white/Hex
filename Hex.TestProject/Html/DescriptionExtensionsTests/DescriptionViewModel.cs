using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Hex.TestProject.Html.DescriptionExtensionsTests
{
	public class DescriptionViewModel
	{
		[Display( Description = "Description" )]
		public string WithDescription { get; set; }

		public string WithoutDescription { get; set; }
	}
}
