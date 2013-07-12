﻿using Hex.ExampleWebsite.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hex.ExampleWebsite.Controllers
{
	public class Html5Controller
		: Controller
	{
		public ActionResult Index()
		{
			return this.View();
		}

		public ActionResult Color()
		{
			var viewModel = new ColorViewModel()
			{
				Color = System.Drawing.Color.Red,
				NullableColor = System.Drawing.Color.Yellow,
				ColorAsString = "#FF0000"
			};

			return this.View( viewModel );
		}

		[HttpPost]
		public ActionResult Color( ColorViewModel viewModel )
		{
			return this.View( viewModel );
		}

		public ActionResult Date()
		{
			var viewModel = new DateViewModel()
			{
				Date = new DateTime( 2000, 12, 1 ),
				NullableDate = new DateTime( 2000, 12,2 ),
				DateAsString = "2000-12-03"
			};

			return this.View( viewModel );
		}

		[HttpPost]
		public ActionResult Date( DateViewModel viewModel )
		{
			return this.View( viewModel );
		}

		public ActionResult Email()
		{
			var viewModel = new EmailViewModel()
			{
				Email = "email@example.com"
			};

			return this.View( viewModel );
		}

		[HttpPost]
		public ActionResult Email( EmailViewModel viewModel )
		{
			return this.View( viewModel );
		}
	}
}