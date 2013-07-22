﻿using Rhino.Mocks;
using System;
using System.Collections;
using System.Collections.Generic;
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
			HttpContextBase httpContext = HtmlHelperGenerator.CreateHttpContext( null, null, FormMethod.Get , Uri.UriSchemeHttp.ToString(), -1 );
			RouteCollection routeCollection = HtmlHelperGenerator.CreateRouteCollection();
			
			RouteData routeData = HtmlHelperGenerator.CreateRouteData();

			ViewDataDictionary viewDataDictionary = new ViewDataDictionary();

			ViewContext viewContext = HtmlHelperGenerator.CreateViewContext( httpContext, routeData, viewDataDictionary );
			IViewDataContainer viewDataContainer = HtmlHelperGenerator.CreateViewDataContainer( viewDataDictionary );

			HtmlHelper<object> htmlHelper = new HtmlHelper<object>( viewContext, viewDataContainer, routeCollection );
			return htmlHelper;
		}

		#region Internal Methods

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

			mockHttpRequest.Stub( o => o.PathInfo ).Return( String.Empty );
			mockHttpRequest.Stub( o => o.HttpMethod ).Return( HtmlHelper.GetFormMethodString( httpMethod ) );

			mockHttpContext.Stub( o => o.Session ).Return( ( HttpSessionStateBase )null );
			mockHttpResponse.Stub( o => o.ApplyAppPathModifier( Arg<string>.Is.Anything ) ).Do( ( Func<string, string> )( x => x ) );

			mockHttpContext.Stub( o => o.Items ).Return( new Hashtable() );
			return mockHttpContext;
		}

		private static RouteCollection CreateRouteCollection()
		{
			//routeCollection.Add( "namedroute", new Route( "named/{controller}/{action}/{id}", null ) { Defaults = new RouteValueDictionary( new { id = "defaultid" } ) } );
			
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

			return routeCollection;
		}

		private static RouteData CreateRouteData()
		{
			RouteData routeData = new RouteData();
			routeData.Values.Add( "controller", DefaultController );
			routeData.Values.Add( "action", DefaultAction );

			return routeData;
		}

		private static ViewContext CreateViewContext( HttpContextBase httpContext, RouteData routeData, ViewDataDictionary viewDataDictionary )
		{
			return new ViewContext()
			{
				HttpContext = httpContext,
				RouteData = routeData,
				ViewData = viewDataDictionary
			};
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
