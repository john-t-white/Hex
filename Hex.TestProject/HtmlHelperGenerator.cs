using Rhino.Mocks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hex.TestProject
{
	public static class HtmlHelperGenerator
	{
		public const string DefaultController = "Home";
		public const string DefaultAction = "Action";

		public static HtmlHelper<object> CreateHtmlHelper()
		{
			return HtmlHelperGenerator.InternalCreateHtmlHelper<object>( null, null, null, false );
		}

		public static HtmlHelper<object> CreateHtmlHelper( bool enabledUnobtrusiveValidation )
		{
			return HtmlHelperGenerator.InternalCreateHtmlHelper<object>( null, null, null, enabledUnobtrusiveValidation );
		}

		public static HtmlHelper<TViewModel> CreateHtmlHelper<TViewModel>( TViewModel viewModel )
		{
			return HtmlHelperGenerator.InternalCreateHtmlHelper<TViewModel>( null, null, viewModel, false );
		}

		public static HtmlHelper<TViewModel> CreateHtmlHelper<TViewModel>( TViewModel viewModel, bool enabledUnobtrusiveValidation )
		{
			return HtmlHelperGenerator.InternalCreateHtmlHelper<TViewModel>( null, null, viewModel, enabledUnobtrusiveValidation );
		}

		public static HtmlHelper<object> CreateHtmlHelperWithNamedRoute( string routeName, string routeUrl )
		{
			return HtmlHelperGenerator.InternalCreateHtmlHelper<object>( routeName, routeUrl, null, false );
		}

		#region Internal Methods

		public static HtmlHelper<TViewModel> InternalCreateHtmlHelper<TViewModel>( string routeName, string routeUrl, TViewModel viewModel, bool enabledUnobtrusiveValidation )
		{
			HttpContextBase httpContext = HtmlHelperGenerator.CreateHttpContext( null, null, FormMethod.Get, Uri.UriSchemeHttp.ToString(), -1 );
			RouteCollection routeCollection = HtmlHelperGenerator.CreateRouteCollection( routeName, routeUrl );

			RouteData routeData = HtmlHelperGenerator.CreateRouteData();

			ViewDataDictionary viewDataDictionary = new ViewDataDictionary();
			if( viewModel != null )
			{
				viewDataDictionary.Model = viewModel;
			}

			ViewContext viewContext = HtmlHelperGenerator.CreateViewContext( httpContext, routeData, viewDataDictionary, enabledUnobtrusiveValidation );
			IViewDataContainer viewDataContainer = HtmlHelperGenerator.CreateViewDataContainer( viewDataDictionary );

			HtmlHelper<TViewModel> htmlHelper = new HtmlHelper<TViewModel>( viewContext, viewDataContainer, routeCollection );
			return htmlHelper;
		}

		public static HttpContextBase CreateHttpContext( string appPath, string requestPath, FormMethod httpMethod, string protocol, int port )
		{
			HttpContextBase mockHttpContext = MockRepository.GenerateMock<HttpContextBase>();
			HttpRequestBase mockHttpRequest = MockRepository.GenerateMock<HttpRequestBase>();
			HttpResponseBase mockHttpResponse = MockRepository.GenerateMock<HttpResponseBase>();

			mockHttpContext.Stub( o => o.Request ).Return( mockHttpRequest );
			mockHttpContext.Stub( o => o.Response ).Return( mockHttpResponse );

			if( !String.IsNullOrEmpty( appPath ) )
			{
				mockHttpRequest.Stub( o => o.ApplicationPath ).Return( appPath );
				mockHttpRequest.Stub( o => o.RawUrl ).Return( appPath );
			}
			if( !String.IsNullOrEmpty( requestPath ) )
			{
				mockHttpRequest.Stub( o => o.AppRelativeCurrentExecutionFilePath ).Return( requestPath );
			}

			Uri uri;

			if( port >= 0 )
			{
				uri = new Uri( protocol + "://localhost" + ":" + Convert.ToString( port ) );
			}
			else
			{
				uri = new Uri( protocol + "://localhost" );
			}
			mockHttpRequest.Stub( o => o.Url ).Return( uri );
			mockHttpRequest.Stub( o => o.RawUrl ).Return( uri.OriginalString );

			mockHttpRequest.Stub( o => o.PathInfo ).Return( String.Empty );
			mockHttpRequest.Stub( o => o.HttpMethod ).Return( HtmlHelper.GetFormMethodString( httpMethod ) );

			mockHttpContext.Stub( o => o.Session ).Return( ( HttpSessionStateBase )null );
			mockHttpResponse.Stub( o => o.ApplyAppPathModifier( Arg<string>.Is.Anything ) ).Do( ( Func<string, string> )( x => x ) );

			mockHttpContext.Stub( o => o.Items ).Return( new Hashtable() );
			return mockHttpContext;
		}

		private static RouteCollection CreateRouteCollection( string routeName, string routeUrl )
		{
			var routeCollection = new RouteCollection()
			{
				new Route( "{controller}/{action}/{id}", null )
				{
					Defaults = new RouteValueDictionary( new
					{
						controller = "Home",
						action = "Index",
						id = UrlParameter.Optional
					} )
				}
			};

			if( !string.IsNullOrWhiteSpace( routeName ) && !string.IsNullOrWhiteSpace( routeUrl ) )
			{
				routeCollection.Add( routeName, new Route( routeUrl, null ) );
			}

			return routeCollection;
		}

		private static RouteData CreateRouteData()
		{
			RouteData routeData = new RouteData();
			routeData.Values.Add( "controller", DefaultController );
			routeData.Values.Add( "action", DefaultAction );

			return routeData;
		}

		private static ViewContext CreateViewContext( HttpContextBase httpContext, RouteData routeData, ViewDataDictionary viewDataDictionary, bool enabledUnobtrusiveValidation )
		{
			var viewContext = new ViewContext()
			{
				HttpContext = httpContext,
				RouteData = routeData,
				ViewData = viewDataDictionary
			};

			viewContext.UnobtrusiveJavaScriptEnabled = enabledUnobtrusiveValidation;
			viewContext.ClientValidationEnabled = enabledUnobtrusiveValidation;

			StringBuilder viewContextStringBuilder = new StringBuilder();
			StringWriter viewContextWriter = new StringWriter( viewContextStringBuilder );
			viewContext.Writer = viewContextWriter;

			return viewContext;
		}

		public static IViewDataContainer CreateViewDataContainer( ViewDataDictionary viewDataDictionary )
		{
			IViewDataContainer viewDataContainer = MockRepository.GenerateMock<IViewDataContainer>();
			viewDataContainer.Stub( x => x.ViewData ).Return( viewDataDictionary );

			return viewDataContainer;
		}

		#endregion
	}
}
