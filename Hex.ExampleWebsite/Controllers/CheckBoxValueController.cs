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
			viewModel.StringValues.Add( "Value One" );
			viewModel.StringValues.Add( "Value Two" );
			viewModel.StringValues.Add( "Value Three" );

			viewModel.IntValues.Add( 1 );
			viewModel.IntValues.Add( 2 );
			viewModel.IntValues.Add( 3 );

			viewModel.NestedEntities.Add( new NestedEntity( 1, "Entity One" ) );
			viewModel.NestedEntities.Add( new NestedEntity( 2, "Entity Two" ) );
			viewModel.NestedEntities.Add( new NestedEntity( 3, "Entity Three" ) );

			viewModel.SelectedStringValues = new List<string>();
			viewModel.SelectedStringValues.Add( "Value Three" );

            return View( "Index", viewModel );
        }

		[HttpPost]
		public ActionResult Index( IndexViewModel viewModel )
		{
			viewModel.StringValues.Add( "Value One" );
			viewModel.StringValues.Add( "Value Two" );
			viewModel.StringValues.Add( "Value Three" );

			viewModel.IntValues.Add( 1 );
			viewModel.IntValues.Add( 2 );
			viewModel.IntValues.Add( 3 );

			viewModel.NestedEntities.Add( new NestedEntity( 1, "Entity One" ) );
			viewModel.NestedEntities.Add( new NestedEntity( 2, "Entity Two" ) );
			viewModel.NestedEntities.Add( new NestedEntity( 3, "Entity Three" ) );

			return View( "Index", viewModel );
		}
    }
}
