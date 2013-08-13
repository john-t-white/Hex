using Hex.ExampleWebsite.ViewModels.CheckBoxValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hex.ExampleWebsite.Controllers
{
    public class CheckBoxValueController : Controller
    {
        public ActionResult Index()
        {
			var viewModel = new IndexViewModel();
			viewModel.StringValues.Add( "One" );
			viewModel.StringValues.Add( "Two" );
			viewModel.StringValues.Add( "Three" );

			viewModel.IntValues.Add( 1 );
			viewModel.IntValues.Add( 2 );
			viewModel.IntValues.Add( 3 );

			viewModel.SelectedStringValues = new List<string>();
			viewModel.SelectedStringValues.Add( "Three" );

            return View( "Index", viewModel );
        }

		[HttpPost]
		public ActionResult Index( IndexViewModel viewModel )
		{
			viewModel.StringValues.Add( "One" );
			viewModel.StringValues.Add( "Two" );
			viewModel.StringValues.Add( "Three" );

			viewModel.IntValues.Add( 1 );
			viewModel.IntValues.Add( 2 );
			viewModel.IntValues.Add( 3 );

			return View( "Index", viewModel );
		}
    }
}
