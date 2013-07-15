using Hex.ExampleWebsite.ViewModels;
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
				NullableColor = null,
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

		public ActionResult Number()
		{
			var viewModel = new NumberViewModel()
			{
				Number = 1,
				NullableNumber = 2,
				NumberAsString = "3"
			};

			return this.View( viewModel );
		}

		[HttpPost]
		public ActionResult Number( NumberViewModel viewModel )
		{
			return this.View( viewModel );
		}

		public ActionResult Search()
		{
			var viewModel = new SearchViewModel()
			{
				Search = "Search"
			};

			return this.View( viewModel );
		}

		[HttpPost]
		public ActionResult Search( SearchViewModel viewModel )
		{
			return this.View( viewModel );
		}

		public ActionResult Telephone()
		{
			var viewModel = new TelephoneViewModel()
			{
				Telephone = "(123) 456-7890"
			};

			return this.View( viewModel );
		}

		[HttpPost]
		public ActionResult Telephone( TelephoneViewModel viewModel )
		{
			return this.View( viewModel );
		}

		[ActionName( "Url" )]
		public ActionResult UrlView()
		{
			var viewModel = new UrlViewModel()
			{
				Url = new Uri( "http://www.example.com?returnUrl=http%3a%2f%2fredirect.example.com%3ftest%3dtest", UriKind.Absolute ),
				UrlAsString = "http://www.example.com"
			};

			return this.View( "url", viewModel );
		}

		[HttpPost]
		[ActionName( "Url" )]
		public ActionResult UrlView( UrlViewModel viewModel )
		{
			return this.View( "url", viewModel );
		}

		public ActionResult Range()
		{
			var viewModel = new RangeViewModel()
			{
				Range = 10
			};

			return this.View( viewModel );
		}

		[HttpPost]
		public ActionResult Range( RangeViewModel viewModel )
		{
			return this.View(  viewModel );
		}

		public ActionResult Time()
		{
			var viewModel = new TimeViewModel()
			{
				Time = new DateTime( 2000, 12, 1, 13, 1, 1 ),
				NullableTime = new DateTime( 2000, 12, 2, 13, 2, 2 ),
				TimeAsString = "13:03:03"
			};

			return this.View( viewModel );
		}

		[HttpPost]
		public ActionResult Time( TimeViewModel viewModel )
		{
			return this.View( viewModel );
		}

		public ActionResult Month()
		{
			var viewModel = new MonthViewModel()
			{
				Month = new DateTime( 2000, 10, 1 ),
				NullableMonth = new DateTime( 2000, 11, 1 ),
				MonthAsString = "2000-12"
			};

			return this.View( viewModel );
		}

		[HttpPost]
		public ActionResult Month( MonthViewModel viewModel )
		{
			return this.View( viewModel );
		}
	}
}